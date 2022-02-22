using Polynoms;

double[] a = Enumerable.Range(0, 51).Select(i => i % 2 == 0 ? (double)i : -i)/*.Reverse()*/.ToArray();

Array.Reverse(a);

const double x0 = 7;

var start_time = DateTime.Now;

const int count = 1_000_000;

for (var i = 0; i < count; i++)
{
    var y = Polynom.GetValueNaive(a, x0);
}

var end_time = DateTime.Now;

var delta_time = end_time - start_time;

Console.WriteLine("Вычисление заняло {0} мс", delta_time.TotalMilliseconds / count);

Console.ReadLine();