using System;
using System.Text;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using YahooFinance.Domain;

namespace YahooFinanceTest.Domain.Mapping
{
    [TestFixture]
    public class SchemaTest
    {
        [Test]
        public void TryGenerateUpdateScript()
        {
            // Tables must not exists for it to output!!
            var schemaUpdate = new SchemaUpdate(NhibernateHelper.Configuration);
            schemaUpdate.Execute(Console.WriteLine, true);           
        }
    }
}