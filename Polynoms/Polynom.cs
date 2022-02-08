using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynoms
{
    class Polynom
    {
        public static double GetValue(double[] a, double x)
        {
            double sum = 0;

            for (var i = 0; i < a.Length; i++)
            {
                var value = a[i] * Math.Pow(x, i);

                sum = sum + value;
            }

            return sum;
        }
    }
}
