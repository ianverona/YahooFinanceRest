using System;

namespace YahooFinance.Shared.Dtos.Requests
{
    public class AddQuoteRequest : RequestBase<AddQuoteResponse>
    {
        public Quote Quote { get; set; } 
    }

    public class AddQuoteResponse : ResponseBase
    {
        
    }

    public abstract class RequestBase<TResponseBase> where TResponseBase : ResponseBase
    {

        public TResponseBase CreateLinkedResponse()
        {
            return Activator.CreateInstance<TResponseBase>();
        }
    }

    public abstract class ResponseBase { }
}