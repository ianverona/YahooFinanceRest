using System;
using NHibernate;
using Raven.Client;
using Raven.Client.Document;
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

    public abstract class RavenRequestHandlerBase<TRequestBase>
    {
        private const string Url = "http://localhost:8080";
        private const string Db = "YahooFinance";

        private DocumentStore _docStore;
        protected IDocumentSession Session { get; private set; }
        public Exception Exception { get; private set; }
        public bool Failed { get { return Exception != null; } }

        public ResponseBase Execute(TRequestBase request)
        {
            try
            {
                _docStore = new DocumentStore { Url = Url };
                _docStore.Initialize();
                Session = _docStore.OpenSession(Db);
                var result = DoExecute(request);
                Session.SaveChanges();
                return result;
            }
            catch (Exception e)
            {
                // IVA: Some kind of log?
                Exception = e;
            }
            finally
            {
                //if (Session != null)
                //{
                //    Session.Dispose();
                //    Session = null;
                //}

                //if (_docStore != null)
                //{
                //    _docStore.Dispose();
                //    _docStore = null;
                //}
            }

            return null;
        }

        protected abstract ResponseBase DoExecute(TRequestBase request);
    }
}