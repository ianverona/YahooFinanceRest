using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace YahooFinance
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = HostFactory.New(x =>
                {
                    x.Service<StockFetcherService>();
                    x.SetServiceName("StockFetcherService");
                    x.SetDisplayName("StockFetcherService");
                    x.SetInstanceName("StockFetcherService");
                    x.SetDescription("Stock fetching service using Yahoo REST API");
                });

            host.Run();
        }
    }

    public class StockFetcherService : ServiceControl
    {
        private StockFetcher _stockFetcher;

        public bool Start(HostControl hostControl)
        {
            _stockFetcher = new Bootstrapper().Run();
            _stockFetcher.Run();
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            // IVA: kontrol for om den er i gang!
            return true;
        }
    }
}
