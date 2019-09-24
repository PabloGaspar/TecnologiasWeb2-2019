using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using testapp;

namespace UnitTest
{

    [TestClass]
    public class UnitTest1
    {
        int counter = 0;
        int counterClass = 0;

        [ClassInitialize]
        public void InitializeClass()
        {
            counterClass += 10;
        }

        [ClassCleanup]
        public void CleanUpClass()
        {
            counterClass *= 10;
        }

        [TestInitialize]
        public void Initialize()
        {
            counter++;
        }

        [TestCleanup]
        public void CleanUp()
        {
            counter *= 10;
        }

        [TestMethod]
        public void Should_Add_Two_Numbers()
        {
            //arrange
            int num1 = 10;
            int num2 = 22;
            var calc = new Calculator();
            //act
            int result = calc.Sum(num1, num2);
            //assert
            Assert.AreEqual(32, result);
        }

        [TestMethod]
        public void Should_Divide_Two_Numbers()
        {
            //arrange
            int num1 = 10;
            int num2 = 5;
            var calc = new Calculator();
            //act
            decimal result = calc.Divide(num1, num2);
            //assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Should_Throw_Exception_Divide_By_Zero()
        {
            //arrange
            int num1 = 10;
            int num2 = 0;
            var calc = new Calculator();
            //act
            decimal result = calc.Divide(num1, num2);
            //assert
            Assert.Fail();
        }
    }
}
