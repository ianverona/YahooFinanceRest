using System;
using System.Globalization;

namespace YahooFinance.Shared.Dtos
{
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
        }

        public string ToSemicommaSeperatedHeaders()
        {
            return "CreationDate;Symbol;Name;Ask;Bid;AverageDailyVolume;BookValue;Change;" +
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