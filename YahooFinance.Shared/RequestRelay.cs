using System;
using System.IO;
using System.Linq;
using System.Reflection;
using YahooFinance.Shared.Dtos.Requests;

namespace YahooFinance.Shared
{
    public class RequestRelay
    {
        /// <summary>
        /// Finds the coresponding requesthandler for a given request.
        /// By convention the can only be one request per requesthandler
        /// </summary>
        /// <typeparam name="TResponseBase"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public TResponseBase Execute<TResponseBase>(RequestBase<TResponseBase> request) where TResponseBase : ResponseBase
        {
            if (request == null)
                throw new Exception("Cannot work with null requests!");

            var currentPath = Directory.GetCurrentDirectory();
            var filePath = Path.Combine(currentPath, "YahooFinance.Domain.dll");

            var assembly = Assembly.LoadFile(filePath);
            foreach (var type in assembly.GetTypes())
            {
                var info = type.GetTypeInfo();
                if (info.BaseType != null)
                {
                    var generics = info.BaseType.GenericTypeArguments;
                    if (generics.Length == 1 && generics.First() == request.GetType())
                    {
                        var requestHandler = Activator.CreateInstance(type);
                        var executeMethod = type.GetMethod("Execute");
                        return (TResponseBase)executeMethod.Invoke(requestHandler, new object[] { request });
                    }
                }
            }

            throw new Exception(string.Format("No requesthandler found for request {0}", request.GetType()));
        }        
    }
}