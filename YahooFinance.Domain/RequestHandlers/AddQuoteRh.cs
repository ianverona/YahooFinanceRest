using YahooFinance.Shared.Dtos.Requests;

namespace YahooFinance.Domain.RequestHandlers
{
    public class AddQuoteRh : RequestHandlerBase<AddQuoteRequest>
    {
        protected override ResponseBase DoExecute(AddQuoteRequest request)
        {
            // IVA: Du er kommet hertil, hvor du skal til at gemme i DB'en!!
            if (request.Quote == null)
                return request.CreateLinkedResponse();

            return null;
        }
    }    
}