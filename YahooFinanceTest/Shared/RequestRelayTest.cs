using System;
using NUnit.Framework;
using YahooFinance.Shared;
using YahooFinance.Shared.Dtos.Requests;

namespace YahooFinanceTest.Shared
{
    [TestFixture]
    public class RequestRelayTest
    {
        public class TestRequestTest : RequestBase<TestResponseTest> { }
        public class TestResponseTest : ResponseBase { }

        [Test]
        public void Execute_NoRequestHandlerExistsForRequest_ThrowsException()
        {
            // Arrange
            var relay = new RequestRelay();

            // Act
            Assert.Throws<Exception>(() => relay.Execute(new TestRequestTest()), "No requesthandler found for request TestRequestTest");

            // Assert
        }

        [Test]
        public void Execute_CanGoFullMonty()
        {
            // Arrange
            var relay = new RequestRelay();

            // Act
            var response = relay.Execute(new AddQuoteRequest());

            // Assert
            Assert.That(response, Is.Not.Null);
        }
    }
}