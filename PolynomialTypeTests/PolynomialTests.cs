using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolynomialType;


namespace PolynomialTypeTests
{
    [TestClass]
    public class PolynomialTests
    {
        [TestMethod()]
        public void PolynomialSubtractionTest()
        {
            
            Polynomial inst = new Polynomial(2, 2);
            Polynomial inst2 = new Polynomial(1, 4, 5);
            Polynomial expected = new Polynomial(1, -2, -5);
            Polynomial actual = inst - inst2;
            Assert.AreEqual(expected, actual, actual.ToString());
        }

        [TestMethod()]
        public void PolynomialSummationTest()
        {
            Polynomial inst = new Polynomial(2, 2, 0, 0);
            Polynomial inst2 = new Polynomial(1, 4, 5, 0);
            Polynomial expected = new Polynomial(3, 6, 5);
            Polynomial actual = inst + inst2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PolynomialNonEqualityTest()
        {
            Polynomial inst = new Polynomial(2, 2);
            Polynomial inst2 = new Polynomial(2, 3);
            bool expected = true;
            bool actual = inst != inst2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PolynomialEqualityWithTHeSameObjTest()
        {
            Polynomial inst = new Polynomial(2, 2);
            Polynomial inst2 = new Polynomial(2, 2);
            bool expected = true;
            bool actual = inst == inst2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PolynomialGetHashTest()
        {
            Polynomial inst = new Polynomial(2, 2);
            Polynomial inst2 = new Polynomial(2, 2);
            int expected = inst.GetHashCode();
            int actual = inst2.GetHashCode();
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod()]
        public void PolynomialMultiplyingTest()
        {
            Polynomial inst = new Polynomial(2, 2);
            Polynomial inst2 = new Polynomial(1, 4);
            Polynomial expected = new Polynomial(2, 10, 8);
            Polynomial actual = inst * inst2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalculateTest()
        {
            Polynomial inst = new Polynomial(2, 2);
            double x = 12;
            double expected = 26;
            double actual = inst.Calculate(x);
            Assert.AreEqual(expected, actual);
        }



        [TestMethod()]
        public void ToStringTest()
        {
            Polynomial inst = new Polynomial(2, 2);
            string expected = "2 + 2*x";
            string actual = inst.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
