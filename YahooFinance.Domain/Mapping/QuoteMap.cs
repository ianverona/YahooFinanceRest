using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using YahooFinance.Domain.Model;

namespace YahooFinance.Domain.Mapping
{
    public class QuoteMap : ClassMapping<Quote>
    {
        public QuoteMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Guid));
            Property(x => x.LastTradePrice);
            Property(x => x.PullDate);
            Property(x => x.LastTradePrice);
        }
    }
}