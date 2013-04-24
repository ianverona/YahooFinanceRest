using System;
using System.Collections.Generic;

namespace YahooFinance.Domain.Model
{
    public class Instrument
    {
        public virtual Guid Id { get; set; }
        public virtual string Symbol { get; set; }
        public virtual string Name { get; set; }

        public virtual List<Quote> Quotes { get; set; }
    }
}