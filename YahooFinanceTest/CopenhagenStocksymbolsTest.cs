using System.Diagnostics;
using NUnit.Framework;
using YahooFinance;

namespace YahooFinanceTest
{
    [TestFixture]
    public class CopenhagenStocksymbolsTest
    {
        [Test]
        public void CanReadSymbolsFile()
        {
            // Arrange

            // Act
            var symbols = CopenhagenStocksymbols.SymbolsFromFile();

            // Assert
            foreach (var symbol in symbols)
            {
                Debug.Print(symbol);
            }
        }
    }
}