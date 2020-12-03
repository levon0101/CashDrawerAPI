using System.Collections.Generic;
using System.Globalization;
using System.Xml;
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
        
        public IEnumerable<RateDto> GetResponse()
        {
            XmlDocument currencyDoc = new XmlDocument();
            currencyDoc.Load(_url);


            XmlNodeList nodes = currencyDoc.SelectNodes("//*[@currency]");

            if (nodes != null)
            {
                foreach (XmlNode node in nodes)
                {
                    var rate = new RateDto()
                    {
                        Currency = node.Attributes["currency"].Value,
                        Value = double.Parse(node.Attributes["rate"].Value, NumberStyles.Any, new CultureInfo("en-Us"))
                    };
                   yield return rate;
                }
            }
        }
    }
}
