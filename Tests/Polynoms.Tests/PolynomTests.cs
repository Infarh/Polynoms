using System;
using System.Linq;
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

        [TestMethod]
        public void op_Sum_Polynom_Polynom()
        {
            double[] a = { 3, 5, 7 };
            double[] b = { 2, 4, 6, 8, 10 };

            double[] expected_sum = { 5, 9, 13, 8, 10 };

            var p = new Polynom(a);
            var q = new Polynom(b);

            var sum = p + q;

            var actual_sum_coefficients = sum.Coefficients.ToArray();

            CollectionAssert.AreEqual(expected_sum, actual_sum_coefficients);
        }
    }
}
