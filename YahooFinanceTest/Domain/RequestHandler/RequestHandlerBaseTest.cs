using System;
using NUnit.Framework;
using YahooFinance.Domain.Model;
using YahooFinance.Domain.RequestHandlers;

namespace YahooFinanceTest.Domain.RequestHandler
{
    [TestFixture]
    public class RequestHandlerBaseTest
    {
        [Test]
        public void Execute_DoExecuteThrowsError_ExceptionIsCatchedAndStored()
        {
            // IVA: Fix me!!
            // Arrange
            //var rh = new TestRequestHandlerBase();

            // Act
            //rh.Execute();

            //// Assert
            //Assert.That(rh.Failed, Is.True);
            //Assert.That(rh.Exception.Message, Is.EqualTo("Weee"));
        }

        //public class TestRequestHandlerBase : RequestHandlerBase
        //{
        //    protected override void DoExecute()
        //    {
        //        throw new Exception("Weee");
        //    }
        //}
    }
}