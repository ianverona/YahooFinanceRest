using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using NUnit.Framework;
using YahooFinance;

namespace YahooFinanceTest
{
    [TestFixture]
    public class JsonStockerTest
    {
        [Test]
        public void QuerySymbols_CanRetireveQuotes()
        {
            // Arrange
            var stocker = new JsonStocker();

            // Actu
            stocker.FetchCopenhagenStocks();

            // Assert
        }
    }
}