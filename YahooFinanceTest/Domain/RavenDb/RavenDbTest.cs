using System;
using NUnit.Framework;
using Raven.Client.Document;
using Raven.Client.Extensions;
using YahooFinance.Domain.Model;
using Raven.Client.Linq;
using System.Linq;

namespace YahooFinanceTest.Domain.RavenDb
{
    [TestFixture]
    public class RavenDbTest
    {
        private const string Url = "http://localhost:8080";
        private const string Db = "YahooFinance";

        [Test]
        public void Save()
        {
            using (var docStore = new DocumentStore { Url = Url })
            {
                docStore.Initialize();
                //docStore.DatabaseCommands.EnsureDatabaseExists(Db);
                using (var session = docStore.OpenSession(Db))
                {
                    var quote = new Quote
                        {
                            LastTradePrice = 6365m,
                            PullDate = DateTime.Now
                        };

                    session.Store(quote);
                    session.SaveChanges();
                }
            }
        }

        [Test]
        public void Get()
        {
            using (var docStore = new DocumentStore {Url = Url})
            {
                docStore.Initialize();
                using (var session = docStore.OpenSession(Db))
                {
                    var quote = session.Load<Quote>("quotes/aaa8f5fb-5d46-4572-9dc5-7dfc3e8fbf28");
                    Assert.That(quote, Is.Not.Null);

                    var quotes = session
                        .Query<Quote>()
                        .Where(x => x.LastTradePrice == 14m)
                        .OrderByDescending(x => x.PullDate);
                    Assert.That(quotes.Count(), Is.EqualTo(2));

                    quotes = session
                        .Query<Quote>()
                        .Where(x => x.LastTradePrice > 100);
                    Assert.That(quotes.Count(), Is.EqualTo(1));
                }
            }
        }
    }
}