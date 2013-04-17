using System;
using NUnit.Framework;
using YahooFinance;

namespace YahooFinanceTest
{
    [TestFixture]
    public class CopenhagenExchangeTradeConstraintTest
    {
        [Test]
        public void AllExamplesReturnsFalse()
        {
            // Arrange
            var saturday = new DateTime(2013, 4, 20, 12, 0, 0);
            var sunday = new DateTime(2013, 4, 21, 12, 0, 0);
            var mondayBeforeNine = new DateTime(2013, 4, 22, 8, 59, 0);
            var mondayAfterFive = new DateTime(2013, 4, 22, 17, 16, 0);

            var constraint = new CopenhagenExchangeTradeConstraint();

            // Act
            // Assert
            Assert.That(constraint.ShouldFetch(saturday), Is.False);
            Assert.That(constraint.ShouldFetch(sunday), Is.False);
            Assert.That(constraint.ShouldFetch(mondayBeforeNine), Is.False);
            Assert.That(constraint.ShouldFetch(mondayAfterFive), Is.False);
        }

        [Test]
        public void AllExamplesReturnsTrue()
        {
            // Arrange
            var mondayNine = new DateTime(2013, 4, 22, 9, 0, 0);
            var mondayFive = new DateTime(2013, 4, 22, 17, 15, 0);

            var wednesdayAroundNine = new DateTime(2013, 4, 24, 9, 32, 30);
            var wednesdayAroundFour = new DateTime(2013, 4, 24, 16, 15, 59);

            var constraint = new CopenhagenExchangeTradeConstraint();

            // Act
            // Assert
            Assert.That(constraint.ShouldFetch(mondayNine), Is.True);
            Assert.That(constraint.ShouldFetch(mondayFive), Is.True);
            Assert.That(constraint.ShouldFetch(wednesdayAroundNine), Is.True);
            Assert.That(constraint.ShouldFetch(wednesdayAroundFour), Is.True);
        }
    }
}