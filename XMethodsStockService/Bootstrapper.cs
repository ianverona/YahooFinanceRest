using System;
using Ninject;

namespace YahooFinance
{
    public class Bootstrapper
    {
        public readonly IKernel Kernel;

        public Bootstrapper()
        {
            Kernel = new StandardKernel();

            Kernel.Bind<IShouldFetchConstraint>().To<CopenhagenExchangeTradeConstraint>();
            Kernel.Bind<Func<JsonStocker>>().ToMethod(x => (() => x.Kernel.Get<JsonStocker>()));
        }

        public StockFetcher Run()
        {
            return Kernel.Get<StockFetcher>();
        }
    }
}