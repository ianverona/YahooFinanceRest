using System;

namespace YahooFinance.Domain.Model
{
    public class Quote
    {
        public Guid Id { get; set; }
        public virtual DateTime PullDate { get; set; }
        public virtual decimal LastTradePrice { get; set; }
    }
}