using YahooFinance.Domain.Model;
using YahooFinance.Shared.Dtos.Requests;

namespace YahooFinance.Domain.RequestHandlers
{
    public class AddQuoteRh : RavenRequestHandlerBase<AddQuoteRequest>
    {
        protected override ResponseBase DoExecute(AddQuoteRequest request)
        {
            // IVA: Du er kommet hertil, hvor du skal til at gemme i DB'en!!
            if (request.Quote == null)
                return request.CreateLinkedResponse();

            var quote = new Quote
                {
                    LastTradePrice = request.Quote.LastTradePriceOnly,
                    PullDate = request.Quote.CreationDate
                };

            Session.Store(quote);

            return request.CreateLinkedResponse();
        }
    }    
}