using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CabInvoiceGenerator;

namespace CabInvoiceGeneratorTest
{
    [TestClass]
    public class CabInvoiceGenUnitTest
    {
        public CabInvoiceGen generateNormalFare;
        [TestInitialize]
        public void Setup()
        {
            generateNormalFare = new CabInvoiceGen(RideType.NORMAL);
        }
        [TestMethod]
        public void GivenProperDistanceAndTimeShouldResturnFare()
        {
            double expected = 160;
            int time = 10;
            double distance = 15;
            double actual = generateNormalFare.CalculateFare(time, distance);
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void GivenImproperTimeDistanceShouldThrowException()
        {
            var invalidTimeException = Assert.ThrowsException<CabInvoiceGeneratorException>(() => generateNormalFare.CalculateFare(0, 5));
            Assert.AreEqual(CabInvoiceGeneratorException.ExceptionType.INVALID_TIME, invalidTimeException.exceptionType);
            var invalidDistanceException = Assert.ThrowsException<CabInvoiceGeneratorException>(() => generateNormalFare.CalculateFare(12, 0));
            Assert.AreEqual(CabInvoiceGeneratorException.ExceptionType.INVALID_DISTANCE, invalidDistanceException.exceptionType);
        }
    }
}
