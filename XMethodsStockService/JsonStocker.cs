using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace YahooFinance
{
    public class JsonStocker
    {
        private const string BaseUrl =           
            "http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.quotes%20where%20symbol%20in%20({0})&format=json&env=http://datatables.org/alltables.env";

        public RootQueryResult QuerySymbols(IEnumerable<string> symbols)
        {
            var symbolList = String.Join("%2C", symbols.Select(w => "%22" + w + "%22").ToArray());
            var url = string.Format(BaseUrl, symbolList);

            var json = new WebClient().DownloadString(url);
            var queryResult = JsonConvert.DeserializeObject<RootQueryResult>(json);

            return queryResult;
        }

        private void WriteToFiles(IEnumerable<Quote> quotes)
        {
            const string folderName = "csv";
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }

            foreach (var quote in quotes)
            {
                var fileName = folderName + "\\" + GetSymboltextFileName(quote);
                EnsureFile(fileName, quote);
                TryAppendLine(fileName, quote);
            }
        }

        private static void TryAppendLine(string fileName, Quote quote)
        {
            var fileLines = File.ReadAllLines(fileName).ToList();

            // Similar line already exists
            if (fileLines.Any(x => x.Contains(quote.ToSemicommaSeperatedValuesOriginalOnly())))
                return;

            File.AppendAllLines(fileName, new List<string> {quote.ToSemicommaSeperatedValues()});
        }

        private void EnsureFile(string fileName, Quote quote)
        {
            if (File.Exists(fileName))
                return;

            File.AppendAllLines(fileName, new List<string> { quote.ToSemicommaSeperatedHeaders() });
        }

        private string GetSymboltextFileName(Quote quote)
        {
            return string.Format("{0}.csv", quote.Symbol);
        }

        public void FetchCopenhagenStocks()
        {
            var result = QuerySymbols(CopenhagenStocksymbols.SymbolsFromFile());

            // IVA: Some kind of logging
            if (result.Query.Result != null)
                WriteToFiles(result.Query.Result.Quotes);
        }
    }

    public class RootQueryResult
    {
        [JsonProperty("query")]
        public Query Query { get; set; }
    }

    public class Query
    {
        [JsonProperty("lang")]
        public string Language { get; set; }

        [JsonProperty("results")]
        public QuoteContainer Result { get; set; }
    }

    public class QuoteContainer
    {
        [JsonProperty("quote")]
        public List<Quote> Quotes { get; set; }
    }

    public class Quote
    {
        public readonly DateTime CreationDate = DateTime.Now;

        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal Ask { get; set; }
        public decimal Bid { get; set; }
        public decimal AverageDailyVolume { get; set; }
        public decimal BookValue { get; set; }
        public decimal Change { get; set; }
        public decimal DividendShare { get; set; }
        public DateTime LastTradeDate { get; set; }
        public decimal EarningsShare { get; set; }
        public decimal EPSEstimateCurrentYear { get; set; }
        public decimal EPSEstimateNextYear { get; set; }
        public decimal DaysLow { get; set; }
        public decimal DaysHigh { get; set; }
        public decimal YearLow { get; set; }
        public decimal YearHigh { get; set; }
        public decimal? MarketCapitalization { get; set; }
        public decimal EBITDA { get; set; }
        public decimal ChangeFromYearLow { get; set; }
        public string PercentChangeFromYearLow { get; set; }
        public decimal ChangeFromYearHigh { get; set; }
        public decimal LastTradePriceOnly { get; set; }
        public string PercebtChangeFromYearHigh { get; set; }
        public decimal FiftydayMovingAverage { get; set; }
        public decimal TwoHundreddayMovingAverage { get; set; }
        public decimal? ChangeFromTwoHundreddayMovingAverage { get; set; }
        public string PercentChangeFromFiftydayMovingAverage { get; set; }
        public decimal Open { get; set; }
        public decimal PreviousClose { get; set; }
        public string ChangeinPercent { get; set; }
        public decimal? PriceSales { get; set; }
        public decimal? PriceBook { get; set; }
        public DateTime? ExDividendDate { get; set; }
        public decimal? PERatio { get; set; }
        public DateTime? DividendPayDate { get; set; }
        public decimal? PEGRatio { get; set; }
        public decimal? PriceEPSEstimateCurrentYear { get; set; }
        public decimal? ShortRatio { get; set; }
        public decimal? OneyrTargetPrice { get; set; }
        public decimal Volume { get; set; }
        public string StockExchange { get; set; }

        public string ToSemicommaSeperatedValuesOriginalOnly()
        {
            return string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15};{16};{17};{18};{19};{20};{21};{22};{23};{24};{25};{26};{27};{28};{29};{30};{31};{32};{33};{34};{35};{36};{37};{38};{39};{40}"
                                 , Symbol
                                 , Name
                                 , Ask
                                 , Bid
                                 , AverageDailyVolume
                                 , BookValue
                                 , Change
                                 , DividendShare
                                 , LastTradeDate
                                 , EarningsShare
                                 , EPSEstimateCurrentYear
                                 , EPSEstimateNextYear
                                 , DaysLow
                                 , DaysHigh
                                 , YearLow
                                 , YearHigh
                                 , MarketCapitalization
                                 , EBITDA
                                 , ChangeFromYearLow
                                 , PercentChangeFromYearLow
                                 , ChangeFromYearHigh
                                 , LastTradePriceOnly
                                 , PercebtChangeFromYearHigh
                                 , FiftydayMovingAverage
                                 , TwoHundreddayMovingAverage
                                 , ChangeFromTwoHundreddayMovingAverage
                                 , Open
                                 , PercentChangeFromFiftydayMovingAverage
                                 , PreviousClose
                                 , ChangeinPercent
                                 , PriceSales
                                 , PriceBook
                                 , ExDividendDate
                                 , PERatio
                                 , DividendPayDate
                                 , PEGRatio
                                 , PriceEPSEstimateCurrentYear
                                 , ShortRatio
                                 , OneyrTargetPrice
                                 , Volume
                                 , StockExchange);
        }

        public string ToSemicommaSeperatedValues()
        {
            return string.Format("{0};{1}"
                , CreationDate.ToString(CultureInfo.InvariantCulture)
                , ToSemicommaSeperatedValuesOriginalOnly());
            
            // CLEANUP
            //return string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15};{16};{17};{18};{19};{20};{21};{22};{23};{24};{25};{26};{27};{28};{29};{30};{31};{32};{33};{34};{35};{36};{37};{38};{39};{40};{41}"
            //                     , CreationDate.ToString(CultureInfo.InvariantCulture)
            //                     , Symbol
            //                     , Name
            //                     , Ask
            //                     , Bid
            //                     , AverageDailyVolume
            //                     , BookValue
            //                     , Change
            //                     , DividendShare
            //                     , LastTradeDate
            //                     , EarningsShare
            //                     , EPSEstimateCurrentYear
            //                     , EPSEstimateNextYear
            //                     , DaysLow
            //                     , DaysHigh
            //                     , YearLow
            //                     , YearHigh
            //                     , MarketCapitalization
            //                     , EBITDA
            //                     , ChangeFromYearLow
            //                     , PercentChangeFromYearLow
            //                     , ChangeFromYearHigh
            //                     , LastTradePriceOnly
            //                     , PercebtChangeFromYearHigh
            //                     , FiftydayMovingAverage
            //                     , TwoHundreddayMovingAverage
            //                     , ChangeFromTwoHundreddayMovingAverage
            //                     , Open
            //                     , PercentChangeFromFiftydayMovingAverage
            //                     , PreviousClose
            //                     , ChangeinPercent
            //                     , PriceSales
            //                     , PriceBook
            //                     , ExDividendDate
            //                     , PERatio
            //                     , DividendPayDate
            //                     , PEGRatio
            //                     , PriceEPSEstimateCurrentYear
            //                     , ShortRatio
            //                     , OneyrTargetPrice
            //                     , Volume
            //                     , StockExchange);
        }

        public string ToSemicommaSeperatedHeaders()
        {
            return  "CreationDate;Symbol;Name;Ask;Bid;AverageDailyVolume;BookValue;Change;" +
                    "DividendShare;LastTradeDate;EarningsShare;EPSEstimateCurrentYear;EPSEstimateNextYear;DaysLow;DaysHigh;" +
                    "YearLow;YearHigh;MarketCapitalization;EBITDA;ChangeFromYearLow;PercentChangeFromYearLow;ChangeFromYearHigh;" +
                    "LastTradePriceOnly;PercebtChangeFromYearHigh;FiftydayMovingAverage;TwoHundreddayMovingAverage;ChangeFromTwoHundreddayMovingAverage;" +
                    "Open;PercentChangeFromFiftydayMovingAverage;PreviousClose;ChangeinPercent;PriceSales;PriceBook;" +
                    "ExDividendDate;PERatio;DividendPayDate;PEGRatio;PriceEPSEstimateCurrentYear;ShortRatio;" +
                    "OneyrTargetPrice;Volume;StockExchange;";
        }

        public override string ToString()
        {
            return string.Format("Symbol: {0}, " +
                                 "Name: {1}, " +
                                 "Ask: {2}, " +
                                 "Bid: {3}, " +
                                 "AverageDailyVolume: {4}, " +
                                 "BookValue: {5}, " +
                                 "Change: {6}, " +
                                 "DividendShare: {7}, " +
                                 "LastTradeDate: {8}, " +
                                 "EarningsShare: {9}, " +
                                 "EPSEstimateCurrentYear: {10}, " +
                                 "EPSEstimateNextYear: {11}, " +
                                 "DaysLow: {12}, " +
                                 "DaysHigh: {13}, " +
                                 "YearLow: {14}, " +
                                 "YearHigh: {15}, " +
                                 "MarketCapitalization: {16}, " +
                                 "EBITDA: {17}, " +
                                 "ChangeFromYearLow: {18}, " +
                                 "PercentChangeFromYearLow: {19}, " +
                                 "ChangeFromYearHigh: {20}, " +
                                 "LastTradePriceOnly: {21}, " +
                                 "PercebtChangeFromYearHigh: {22}, " +
                                 "FiftydayMovingAverage: {23}, " +
                                 "TwoHundreddayMovingAverage: {24}, " +
                                 "ChangeFromTwoHundreddayMovingAverage: {25}, " +
                                 "Open: {26}, " +
                                 "PercentChangeFromFiftydayMovingAverage: {27}, " +
                                 "PreviousClose: {28}, " +
                                 "ChangeinPercent: {29}, " +
                                 "PriceSales: {30}, " +
                                 "PriceBook: {31}, " +
                                 "ExDividendDate: {32}, " +
                                 "PERatio: {33}, " +
                                 "DividendPayDate: {34}, " +
                                 "PEGRatio: {35}, " +
                                 "PriceEPSEstimateCurrentYear: {36}, " +
                                 "ShortRatio: {37}, " +
                                 "OneyrTargetPrice: {38}, " +
                                 "Volume: {39}, " +
                                 "StockExchange: {40}"
                                 , Symbol
                                 , Name
                                 , Ask
                                 , Bid
                                 , AverageDailyVolume
                                 , BookValue
                                 , Change
                                 , DividendShare
                                 , LastTradeDate
                                 , EarningsShare
                                 , EPSEstimateCurrentYear
                                 , EPSEstimateNextYear
                                 , DaysLow
                                 , DaysHigh
                                 , YearLow
                                 , YearHigh
                                 , MarketCapitalization
                                 , EBITDA
                                 , ChangeFromYearLow
                                 , PercentChangeFromYearLow
                                 , ChangeFromYearHigh
                                 , LastTradePriceOnly
                                 , PercebtChangeFromYearHigh
                                 , FiftydayMovingAverage
                                 , TwoHundreddayMovingAverage
                                 , ChangeFromTwoHundreddayMovingAverage
                                 , Open
                                 , PercentChangeFromFiftydayMovingAverage
                                 , PreviousClose
                                 , ChangeinPercent
                                 , PriceSales
                                 , PriceBook
                                 , ExDividendDate
                                 , PERatio
                                 , DividendPayDate
                                 , PEGRatio
                                 , PriceEPSEstimateCurrentYear
                                 , ShortRatio
                                 , OneyrTargetPrice
                                 , Volume
                                 , StockExchange);
        }
    }
}