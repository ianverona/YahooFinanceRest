using System.Collections.Generic;
using NUnit.Framework;
using YahooFinance.Shared;
using YahooFinance.Shared.Dtos;
using YahooFinance.Shared.Dtos.Requests;

namespace YahooFinanceTest.Domain.RequestHandler
{
    [TestFixture]
    public class AddQuoteRhTest
    {
        [Test]
        public void Execute_OneQuoteToSave_SavesWithNoException()
        {
            // Arrange
            var request = new AddQuotesRequest
                {
                    Quotes = new List<Quote>
                        {
                            new Quote
                                {
                                    LastTradePriceOnly = 33
                                }
                        }
                };
            
            // Act
            var result = new RequestRelay().Execute(request);

            // Assert

        }
    }
}