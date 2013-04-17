using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using YahooFinance.Domain.Model;

namespace YahooFinance.Domain.Mapping
{
    public class InstrumentMap : ClassMapping<Instrument>
    {
        public InstrumentMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Guid));
            Property(x => x.Name);
            Property(x => x.Symbol);
            Bag(x => x.Quotes, c => c.Key(y => y.Column("instrument_id")), r => r.OneToMany());
        }
    }
}