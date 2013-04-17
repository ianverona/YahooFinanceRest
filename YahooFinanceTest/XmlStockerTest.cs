using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NUnit.Framework;
using YahooFinance;

namespace YahooFinanceTest
{    
    [TestFixture]
    public class XmlStockerTest
    {
        [Test]
        public void InitialYahooFinanceConnectionTest()
        {
            // Arrange
            var stocker = new XmlStocker();

            // Act
            var doc = stocker.QuerySymbols(new ObservableCollection<string> { "BAVA.CO", "PNDORA.CO", "VWS.CO", });
            var results = doc.Root.Element("results");            

            // Assert
            PrintResults(results);            
        }

        private void PrintResults(XElement results)
        {
            foreach (var q in results.Elements("quote"))
            {
                Debug.Print("**************** SYMBOL ****************");
                Debug.Print(q.Attribute("symbol").Value);
                Debug.Print("Ask " + XmlStocker.GetDecimal(q.Element("Ask").Value).ToString());
                Debug.Print("Bid " + XmlStocker.GetDecimal(q.Element("Bid").Value).ToString());
                Debug.Print("AverageDailyVolume " + XmlStocker.GetDecimal(q.Element("AverageDailyVolume").Value).ToString());
                Debug.Print("BookValue " + XmlStocker.GetDecimal(q.Element("BookValue").Value).ToString());
                Debug.Print("Change " + XmlStocker.GetDecimal(q.Element("Change").Value).ToString());
                Debug.Print("DividendShare " + XmlStocker.GetDecimal(q.Element("DividendShare").Value).ToString());
                Debug.Print("LastTradeDate " + XmlStocker.GetDateTime(q.Element("LastTradeDate").Value).ToString());
                Debug.Print("EarningsShare " + XmlStocker.GetDecimal(q.Element("EarningsShare").Value).ToString());
                Debug.Print("EPSEstimateCurrentYear " + XmlStocker.GetDecimal(q.Element("EPSEstimateCurrentYear").Value).ToString());
                Debug.Print("EPSEstimateNextYear " + XmlStocker.GetDecimal(q.Element("EPSEstimateNextYear").Value).ToString());
                Debug.Print("DaysLow " + XmlStocker.GetDecimal(q.Element("DaysLow").Value).ToString());
                Debug.Print("DaysHigh " + XmlStocker.GetDecimal(q.Element("DaysHigh").Value).ToString());
                Debug.Print("YearLow " + XmlStocker.GetDecimal(q.Element("YearLow").Value).ToString());
                Debug.Print("YearHigh " + XmlStocker.GetDecimal(q.Element("YearHigh").Value).ToString());
                Debug.Print("MarketCapitalization " + XmlStocker.GetDecimal(q.Element("MarketCapitalization").Value).ToString());
                Debug.Print("EBITDA " + XmlStocker.GetDecimal(q.Element("EBITDA").Value).ToString());
                Debug.Print("ChangeFromYearLow " + XmlStocker.GetDecimal(q.Element("ChangeFromYearLow").Value).ToString());
                Debug.Print("PercentChangeFromYearLow " + XmlStocker.GetDecimal(q.Element("PercentChangeFromYearLow").Value).ToString());
                Debug.Print("ChangeFromYearHigh " + XmlStocker.GetDecimal(q.Element("ChangeFromYearHigh").Value).ToString());
                Debug.Print("LastTradePriceOnly " + XmlStocker.GetDecimal(q.Element("LastTradePriceOnly").Value).ToString());
                Debug.Print("PercebtChangeFromYearHigh " + XmlStocker.GetDecimal(q.Element("PercebtChangeFromYearHigh").Value).ToString());
                Debug.Print("FiftydayMovingAverage " + XmlStocker.GetDecimal(q.Element("FiftydayMovingAverage").Value).ToString());
                Debug.Print("TwoHundreddayMovingAverage " + XmlStocker.GetDecimal(q.Element("TwoHundreddayMovingAverage").Value).ToString());
                Debug.Print("ChangeFromTwoHundreddayMovingAverage " + XmlStocker.GetDecimal(q.Element("ChangeFromTwoHundreddayMovingAverage").Value).ToString());
                Debug.Print("PercentChangeFromFiftydayMovingAverage " + XmlStocker.GetDecimal(q.Element("PercentChangeFromFiftydayMovingAverage").Value).ToString());
                Debug.Print("Name " + q.Element("Name").Value);
                Debug.Print("Open " + XmlStocker.GetDecimal(q.Element("Open").Value).ToString());
                Debug.Print("PreviousClose " + XmlStocker.GetDecimal(q.Element("PreviousClose").Value).ToString());
                Debug.Print("ChangeinPercent " + XmlStocker.GetDecimal(q.Element("ChangeinPercent").Value).ToString());
                Debug.Print("PriceSales " + XmlStocker.GetDecimal(q.Element("PriceSales").Value).ToString());
                Debug.Print("PriceBook " + XmlStocker.GetDecimal(q.Element("PriceBook").Value).ToString());
                Debug.Print("ExDividendDate " + XmlStocker.GetDateTime(q.Element("ExDividendDate").Value).ToString());
                Debug.Print("PERatio " + XmlStocker.GetDecimal(q.Element("PERatio").Value).ToString());
                Debug.Print("DividendPayDate " + XmlStocker.GetDateTime(q.Element("DividendPayDate").Value).ToString());
                Debug.Print("PEGRatio " + XmlStocker.GetDecimal(q.Element("PEGRatio").Value).ToString());
                Debug.Print("PriceEPSEstimateCurrentYear " + XmlStocker.GetDecimal(q.Element("PriceEPSEstimateCurrentYear").Value).ToString());
                Debug.Print("ShortRatio " + XmlStocker.GetDecimal(q.Element("ShortRatio").Value).ToString());
                Debug.Print("OneyrTargetPrice " + XmlStocker.GetDecimal(q.Element("OneyrTargetPrice").Value).ToString());
                Debug.Print("Volume " + XmlStocker.GetDecimal(q.Element("Volume").Value).ToString());
                Debug.Print("StockExchange " + q.Element("StockExchange").Value);
            }
        }
    }
}
