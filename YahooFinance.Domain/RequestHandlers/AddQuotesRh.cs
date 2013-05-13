using Raven.Client;
using YahooFinance.Domain.Model;
using YahooFinance.Shared.Dtos.Requests;
using System.Linq;

namespace YahooFinance.Domain.RequestHandlers
{
    public class AddQuotesRh : RavenRequestHandlerBase<AddQuotesRequest>
    {
        protected override ResponseBase DoExecute(AddQuotesRequest request)
        {
            if (request.Quotes == null || !request.Quotes.Any())
                return request.CreateLinkedResponse();

            foreach (var clQuote in request.Quotes)
            {
                var quote = new Quote
                {
                    LastTradePrice = clQuote.LastTradePriceOnly,
                    PullDate = clQuote.CreationDate,
                    Symbol = clQuote.Symbol,
                    Name = clQuote.Name,
                    Ask = clQuote.Ask,
                    AverageDailyVolume = clQuote.AverageDailyVolume,
                    Bid = clQuote.Bid,
                    BookValue = clQuote.BookValue,
                    Change = clQuote.Change,
                    ChangeFromTwoHundreddayMovingAverage = clQuote.ChangeFromTwoHundreddayMovingAverage,
                    ChangeFromYearHigh = clQuote.ChangeFromYearHigh,
                    ChangeFromYearLow = clQuote.ChangeFromYearLow,
                    ChangeinPercent = clQuote.ChangeinPercent,
                    DaysHigh = clQuote.DaysHigh,
                    DaysLow = clQuote.DaysLow,
                    DividendPayDate = clQuote.DividendPayDate,
                    DividendShare = clQuote.DividendShare,
                    EarningsShare = clQuote.EarningsShare,
                    Ebitda = clQuote.EBITDA,
                    EpsEstimateCurrentYear = clQuote.EPSEstimateCurrentYear,
                    EpsEstimateNextYear = clQuote.EPSEstimateNextYear,
                    ExDividendDate = clQuote.ExDividendDate,
                    FiftydayMovingAverage = clQuote.FiftydayMovingAverage,
                    LastTradeDate = clQuote.LastTradeDate,
                    MarketCapitalization = clQuote.MarketCapitalization,
                    OneyrTargetPrice = clQuote.OneyrTargetPrice,
                    Open = clQuote.Open,
                    PeRatio = clQuote.PERatio,
                    PegRatio = clQuote.PEGRatio,
                    PercebtChangeFromYearHigh = clQuote.PercebtChangeFromYearHigh,
                    PercentChangeFromFiftydayMovingAverage = clQuote.PercentChangeFromFiftydayMovingAverage,
                    PercentChangeFromYearLow = clQuote.PercentChangeFromYearLow,
                    PreviousClose = clQuote.PreviousClose,
                    PriceBook = clQuote.PriceBook,
                    PriceEpsEstimateCurrentYear = clQuote.PriceEPSEstimateCurrentYear,
                    PriceSales = clQuote.PriceSales,
                    ShortRatio = clQuote.ShortRatio,
                    StockExchange = clQuote.StockExchange,
                    TwoHundreddayMovingAverage = clQuote.TwoHundreddayMovingAverage,
                    Volume = clQuote.Volume,
                    YearHigh = clQuote.YearHigh,
                    YearLow = clQuote.YearLow,
                    LastTradeTime = clQuote.LastTradeTime
                };

                // IVA: Få ShouldStore til at virke
                Session.Store(quote);                
            }
           
            return request.CreateLinkedResponse();
        }

        /// <summary>
        /// Returns true if there is a difference
        /// </summary>
        /// <param name="newQuote"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        public static bool ShouldStore(Quote newQuote, IDocumentSession session)
        {
            var lastQuote = GetLastQuote(newQuote.Symbol, session);
            return lastQuote.ToStringValue() != newQuote.ToStringValue();
        }

        private static Quote GetLastQuote(string symbol, IDocumentSession session)
        {
            return session
                    .Query<Quote>()
                    .Where(x => x.Symbol == symbol)
                    .OrderByDescending(x => x.PullDate)
                    .Take(1)
                    .FirstOrDefault();
        }
    }    
}