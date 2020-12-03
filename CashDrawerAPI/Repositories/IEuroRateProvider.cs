using System.Collections.Generic;
using Dtos;

namespace CashDrawerAPI.Repositories
{
    public interface IEuroRateProvider
    {
        IEnumerable<RateDto> GetResponse();
    }
}