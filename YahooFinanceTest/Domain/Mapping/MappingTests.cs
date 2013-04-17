using System;
using System.Xml.Serialization;
using NHibernate.Mapping.ByCode;
using NUnit.Framework;
using YahooFinance.Domain.Mapping;

namespace YahooFinanceTest.Domain.Mapping
{
    [TestFixture]
    public class MappingTests
    {
        [Test]
        public void TestMappings()
        {
            // Arrange
            var mapper = new ModelMapper();
            mapper.AddMapping<QuoteMap>();
            mapper.AddMapping<InstrumentMap>();

            // Act
            var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            var xmlSerializer = new XmlSerializer(mapping.GetType());
            xmlSerializer.Serialize(Console.Out, mapping);

            // Assert

        }
    }
}