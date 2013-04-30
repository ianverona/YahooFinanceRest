using System;

namespace YahooFinance.Shared.Dtos.Requests
{
    public abstract class ResponseBase { }

    public abstract class RequestBase<TResponseBase> where TResponseBase : ResponseBase
    {
        public TResponseBase CreateLinkedResponse()
        {
            return Activator.CreateInstance<TResponseBase>();
        }
    }
}