using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace YahooFinance
{
    public class StockFetcher
    {
        private readonly Func<JsonStocker> _jsonStocker;
        private readonly IShouldFetchConstraint _fetchConstraint;
        private Timer _timer;
        private bool _fetchedOnce;

        public StockFetcher(Func<JsonStocker> jsonStocker, IShouldFetchConstraint fetchConstraint)
        {
            _jsonStocker = jsonStocker;
            _fetchConstraint = fetchConstraint;
        }

        public void Run()
        {
            _timer = new Timer(delegate { File.AppendAllLines("test.txt", new List<string>{" " + DateTime.Now}); }, this, 0, 300000); // 5 minutes
            _timer = new Timer(
                delegate
                    {
                        if (!_fetchedOnce || ShouldFetch())
                            _jsonStocker().FetchCopenhagenStocks();
                    }
                , this
                , 0                
                , 300000); // 5 minutes
        }

        private bool ShouldFetch()
        {
            return _fetchConstraint.ShouldFetch(DateTime.Now);
        }
    }
}