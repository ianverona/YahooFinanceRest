using System.Collections.Generic;
using Newtonsoft.Json;
using YahooFinance.Shared.Dtos;

namespace YahooFinance
{
    public class RootQueryResult
    {
        [JsonProperty("query")]
        public Query Query { get; set; }
    }

    public class Query
    {
        [JsonProperty("lang")]
        public string Language { get; set; }

        [JsonProperty("results")]
        public QuoteContainer Result { get; set; }
    }

    public class QuoteContainer
    {
        [JsonProperty("quote")]
        public List<Quote> Quotes { get; set; }
    }
}