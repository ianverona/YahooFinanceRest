using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;

namespace YahooFinance
{
    public class XmlStocker
    {
        private const string BaseUrl =
            "http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.quotes%20where%20symbol%20in%20({0})&env=http://datatables.org/alltables.env";        

        public XDocument QuerySymbols(ObservableCollection<string> symbols) 
        {
            var symbolList = String.Join("%2C", symbols.Select(w => "%22" + w+ "%22").ToArray());
            var url = string.Format(BaseUrl, symbolList);
            var doc = XDocument.Load(url);

            if (doc == null || doc.Root == null)
                throw new NullReferenceException("Query for sybol not successfull");

            return doc;
        }

        public static decimal? GetDecimal(string input)
        {
            if (input == null) return null;

            input = input.Replace("%", "");

            decimal value;

            if (Decimal.TryParse(input, out value)) return value;
            return null;
        }

        public static DateTime? GetDateTime(string input)
        {
            if (input == null) return null;

            DateTime value;

            if (DateTime.TryParse(input, out value)) return value;
            return null;
        }
    }    
}