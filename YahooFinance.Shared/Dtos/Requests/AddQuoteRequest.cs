namespace YahooFinance.Shared.Dtos.Requests
{
    public class AddQuoteRequest : RequestBase<AddQuoteResponse>
    {
        public Quote Quote { get; set; } 
    }

    public class AddQuoteResponse : ResponseBase
    {
        
    }

}