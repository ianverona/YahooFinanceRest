using System;

namespace YahooFinance.Domain.Model
{
    public class Quote
    {
        public virtual Guid Id { get; protected set; }
        public virtual DateTime PullDate { get; set; }
        public virtual decimal LastTradePrice { get; set; }
    }
}