using System.Collections.Generic;

namespace YahooFinance.Shared.Dtos.Requests
{
    public class AddQuotesRequest : RequestBase<AddQuotesResponse>
    {
        public List<Quote> Quotes { get; set; } 
    }

    public class AddQuotesResponse : ResponseBase
    {
        
    }

}