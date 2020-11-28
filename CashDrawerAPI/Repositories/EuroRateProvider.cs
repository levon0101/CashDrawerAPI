namespace CashDrawerAPI.Repositories
{
    public class EuroRateProvider : IEuroRateProvider
    {
        private readonly string _url;

        public EuroRateProvider(string url)
        {
            _url = url;
        }
    }
}
