using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Xml;
using CashDrawerApi.Exceptions;
using Dtos;

namespace CashDrawerAPI.Repositories
{
    public class EuroRateProvider : IEuroRateProvider
    {
        private readonly string _url;

        public EuroRateProvider(string url)
        {
            _url = url;
        }

        public IEnumerable<RateDto> CurrentRates()
        {
            var currencyDoc = new XmlDocument();
            currencyDoc.Load(_url);


            var nodes = currencyDoc.SelectNodes("//*[@currency]");

            if (nodes == null) yield break;

            foreach (XmlNode node in nodes)
            {
                if (node.Attributes == null) continue;


                var rate = new RateDto
                {
                    Currency = node.Attributes["currency"].Value,
                    Value = double.Parse(node.Attributes["rate"].Value, NumberStyles.Any, new CultureInfo("en-Us"))
                };

                yield return rate;
            }
        }


        public double ConvertMoney(string from, string to, double money)
        {
            var rates = CurrentRates();

            var fromRate = CurrentRate(rates, from);

            var toRate = CurrentRate(rates, to);

            if (fromRate == null || toRate == null) throw new RateNotFoundException();

            return money / fromRate.Value * toRate.Value;

        }


        public double ConvertMoney(string currencyCode, double money)
        {
            var rates = CurrentRates();
            var currentRate = CurrentRate(rates, currencyCode);

            if (currentRate == null) throw new RateNotFoundException();

            return money / currentRate.Value;
        }
        private double? CurrentRate(IEnumerable<RateDto> rates, string currencyCode)
        {
            return currencyCode == "EUR" ? 1 : rates?.FirstOrDefault(r => r.Currency.Equals(currencyCode))?.Value;
        }

    }
}
