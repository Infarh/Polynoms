namespace Polynoms
{
    public class Polynom
    {
        private static double Pow(double x, int n)
        {
            if (n == 0) return 1;
            if (n < 0) return Pow(1 / x, -n);

            var result = x;

            for (var i = 1; i < n; i++)
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

        public static double GetValueNaive(double[] a, double x)
        {
            double sum = 0;

            for (var i = 0; i < a.Length; i++)
            {
                sum += a[i] * Math.Pow(x, i);
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

        private readonly double[] _A;

        public int Length => _A.Length;

        public int Power => _A.Length - 1;

        public IReadOnlyList<double> Coefficients => _A;

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
            if (p1 is null) throw new ArgumentNullException(nameof(p1));
            if (p2 is null) throw new ArgumentNullException(nameof(p2));

            var p1_length = p1.Length;
            var p2_length = p2.Length;

            if (p1_length > p2_length)
            {
                var result = (double[])p1._A.Clone();
                //var result = new double[p1_length]; // неправильно - надо скопировать остальные элементы высших порядков в результат
                for (var i = 0; i < p2_length; i++)
                    result[i] = p1._A[i] + p2._A[i];

                return new Polynom(result);
            }
            else
            {
                var result = (double[])p2._A.Clone();
                //var result = new double[p2_length];
                for (var i = 0; i < p1_length; i++)
                    result[i] = p1._A[i] + p2._A[i];

                return new Polynom(result);
            }
        }

        public static Polynom operator -(Polynom p1, Polynom p2)
        {
            if (p1 is null) throw new ArgumentNullException(nameof(p1));
            if (p2 is null) throw new ArgumentNullException(nameof(p2));

            var p1_length = p1.Length;
            var p2_length = p2.Length;

            if (p1_length > p2_length)
            {
                var result = (double[])p1._A.Clone();
                //var result = new double[p1_length]; // неправильно - надо скопировать остальные элементы высших порядков в результат
                for (var i = 0; i < p2_length; i++)
                    result[i] = p1._A[i] - p2._A[i];

                return new Polynom(result);
            }
            else
            {
                var result = (double[])p2._A.Clone();
                //var result = new double[p2_length];
                for (var i = 0; i < p1_length; i++)
                    result[i] = p1._A[i] - p2._A[i];

                return new Polynom(result);
            }
        }
    }
}
