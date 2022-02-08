using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynoms
{
    class Polynom
    {
        private static double Pow(double x, int n)
        {
            var result = 1d;

            for (var i = 0; i < n; i++) 
                result *= x;

            return result;
        }

        public static double GetValue(double[] a, double x)
        {
            double sum = 0;

            for (var i = 0; i < a.Length; i++)
            {
                sum += a[i] * Pow(x, i);
            }

            return sum;
        }
    }
}
