using System;
using NHibernate;
using YahooFinance.Shared.Dtos.Requests;

namespace YahooFinance.Domain.RequestHandlers
{
    public abstract class RequestHandlerBase<TRequestBase> // Marker type
    {
        protected ISession Session { get; private set; }
        public Exception Exception { get; private set; }
        public bool Failed { get { return Exception != null; } }

        public ResponseBase Execute(TRequestBase request)
        {
            try
            {
                Session = NhibernateHelper.OpenSession();
                var result = DoExecute(request);
                Session.Flush();
                return result;
            }
            catch (Exception e)
            {
                // IVA: Some kind of log?
                Exception = e;
            }
            finally
            {
                if (Session != null)
                    Session.Dispose();
            }

            return null;
        }

        protected abstract ResponseBase DoExecute(TRequestBase request);
    }
}