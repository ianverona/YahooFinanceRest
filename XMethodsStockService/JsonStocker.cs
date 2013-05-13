using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using YahooFinance.Shared;
using YahooFinance.Shared.Dtos;
using YahooFinance.Shared.Dtos.Requests;
using ErrorEventArgs = Newtonsoft.Json.Serialization.ErrorEventArgs;

namespace YahooFinance
{
    public class JsonStocker
    {
        private const string BaseUrl =           
            "http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.quotes%20where%20symbol%20in%20({0})&format=json&env=http://datatables.org/alltables.env";

        public RootQueryResult QuerySymbols(IEnumerable<string> symbols)
        {
            var symbolList = String.Join("%2C", symbols.Select(w => "%22" + w + "%22").ToArray());
            var url = string.Format(BaseUrl, symbolList);

            var json = new WebClient().DownloadString(url);
            var queryResult = JsonConvert.DeserializeObject<RootQueryResult>(json, new JsonSerializerSettings {  Error = OnJsonError });

            return queryResult;
        }

        private void OnJsonError(object sender, ErrorEventArgs e)
        {
            throw e.ErrorContext.Error;
        }

        public void FetchCopenhagenStocks()
        {
            var result = QuerySymbols(CopenhagenStocksymbols.SymbolsFromFile());

            // IVA: Some kind of logging
            if (result.Query.Result != null)
            {
                SendToServer(result.Query.Result.Quotes);                
            }
        }

        private void SendToServer(List<Quote> quotes)
        {
            var request = new AddQuotesRequest
                {
                    Quotes = quotes
                };

            var result = new RequestRelay().Execute(request); // IVA: Error handling for returned request
        }
    }    

    public static class StockFileWriter
    {
        public static void WriteToFiles(IEnumerable<Quote> quotes)
        {
            const string folderName = "csv";
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }

            foreach (var quote in quotes)
            {
                var fileName = folderName + "\\" + GetSymboltextFileName(quote);
                EnsureFile(fileName, quote);
                TryAppendLine(fileName, quote);
            }
        }

        private static void TryAppendLine(string fileName, Quote quote)
        {
            var fileLines = File.ReadAllLines(fileName).ToList();

            // Similar line already exists
            if (fileLines.Any(x => x.Contains(quote.ToSemicommaSeperatedValuesOriginalOnly())))
                return;

            File.AppendAllLines(fileName, new List<string> { quote.ToSemicommaSeperatedValues() });
        }

        private static void EnsureFile(string fileName, Quote quote)
        {
            if (File.Exists(fileName))
                return;

            File.AppendAllLines(fileName, new List<string> { quote.ToSemicommaSeperatedHeaders() });
        }

        private static string GetSymboltextFileName(Quote quote)
        {
            return String.Format("{0}.csv", quote.Symbol);
        }
    }
}