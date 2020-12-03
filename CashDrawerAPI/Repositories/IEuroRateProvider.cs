using System.Collections.Generic;
using Dtos;

namespace CashDrawerAPI.Repositories
{
    public interface IEuroRateProvider
    {
        IEnumerable<RateDto> CurrentRates();
        double ConvertMoney(string from, string to, double money);

        double ConvertMoney(string currencyCode, double money);
    }
}