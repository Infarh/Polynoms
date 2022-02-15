using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polynoms.Tests
{
    [TestClass]
    public class PolynomTests
    {
        [TestMethod]
        public void Value_of_3_5_7_at_1_Equals_15()
        {
            double[] a = { 3, 5, 7 };

            const double x0 = 1;
            const double expected_y = 15;

            var polynom = new Polynom(a);

            var actual_y = polynom.Value(x0);

            Assert.AreEqual(expected_y, actual_y);
        }

        [TestMethod]
        public void Value_of_3_5_7_at_7_Equals_381()
        {
            double[] a = { 3, 5, 7 };

            const double x0 = 7;
            const double expected_y = 381;

            var polynom = new Polynom(a);

            var actual_y = polynom.Value(x0);

            Assert.AreEqual(expected_y, actual_y);
        }



        [TestMethod]
        public void Value_of_3_5_7()
        {
            double[] a = { 3, 5, 7 };

            double ExpectedValue(double x)
            {
                var sum = 0.0;

                for (var i = 0; i < a.Length; i++)
                {
                    sum += a[i] * Math.Pow(x, i);
                }

                return sum;
            }

            for (var i = 0; i < 1000; i++)
            {
                var x0 = (Random.Shared.NextDouble() - 0.5) * 10;
                var expected_y = ExpectedValue(x0);

                var polynom = new Polynom(a);

                var actual_y = polynom.Value(x0);

                Assert.AreEqual(expected_y, actual_y, 1e-12);
            }
        }
    }
}
