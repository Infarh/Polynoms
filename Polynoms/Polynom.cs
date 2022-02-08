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

        public static double GetValueHorner(double[] a, double x)
        {
            double sum = a[a.Length - 1];

            for (var i = a.Length - 2; i >= 0; i--)
            {
                sum = sum * x + a[i];
            }

            return sum;
        }

        private double[] _A;

        public Polynom(double[] A)
        {
            _A = A;
        }

        public double Value(double x)
        {
            return GetValueHorner(_A, x);
        }

        public static Polynom operator +(Polynom p1, Polynom p2)
        {
            var C = new double[p1._A.Length];

            for (var i = 0; i < C.Length; i++)
            {
                C[i] = p1._A[i] + p2._A[i];
            }

            return new Polynom(C);
        }
    }
}
