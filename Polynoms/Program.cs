using Polynoms;

double[] a = Enumerable.Range(0, 51).Select(i => i % 2 == 0 ? (double)i : -i)/*.Reverse()*/.ToArray();

Array.Reverse(a);

const double x0 = 7;

var start_time = DateTime.Now;

var y = Polynom.GetValueNaive(a, x0);

var end_time = DateTime.Now;

var delta_time = end_time - start_time;

Console.WriteLine("Вычисление заняло {0}", delta_time);

Console.ReadLine();