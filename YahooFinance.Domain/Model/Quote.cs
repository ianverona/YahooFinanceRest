using System;

namespace YahooFinance.Domain.Model
{
    public class Quote
    {
        public virtual Guid Id { get; protected set; }
        public virtual DateTime PullDate { get; set; }
        public virtual decimal LastTradePrice { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal? Ask { get; set; }
        public decimal? Bid { get; set; }
        public decimal AverageDailyVolume { get; set; }
        public decimal BookValue { get; set; }
        public decimal Change { get; set; }
        public decimal DividendShare { get; set; }
        public DateTime? LastTradeDate { get; set; }
        public decimal EarningsShare { get; set; }
        public decimal EpsEstimateCurrentYear { get; set; }
        public decimal EpsEstimateNextYear { get; set; }
        public decimal? DaysLow { get; set; }
        public decimal? DaysHigh { get; set; }
        public decimal YearLow { get; set; }
        public decimal YearHigh { get; set; }
        public decimal? MarketCapitalization { get; set; }
        public decimal Ebitda { get; set; }
        public decimal? ChangeFromYearLow { get; set; }
        public string PercentChangeFromYearLow { get; set; }
        public decimal? ChangeFromYearHigh { get; set; }
        public string PercebtChangeFromYearHigh { get; set; }
        public decimal FiftydayMovingAverage { get; set; }
        public decimal TwoHundreddayMovingAverage { get; set; }
        public decimal? ChangeFromTwoHundreddayMovingAverage { get; set; }
        public string PercentChangeFromFiftydayMovingAverage { get; set; }
        public decimal? Open { get; set; }
        public decimal? PreviousClose { get; set; }
        public string ChangeinPercent { get; set; }
        public decimal? PriceSales { get; set; }
        public decimal? PriceBook { get; set; }
        public DateTime? ExDividendDate { get; set; }
        public decimal? PeRatio { get; set; }
        public DateTime? DividendPayDate { get; set; }
        public decimal? PegRatio { get; set; }
        public decimal? PriceEpsEstimateCurrentYear { get; set; }
        public decimal? ShortRatio { get; set; }
        public decimal? OneyrTargetPrice { get; set; }
        public decimal Volume { get; set; }
        public string StockExchange { get; set; }
        public string LastTradeTime { get; set; }
    }
}