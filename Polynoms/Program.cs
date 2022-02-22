using System.Diagnostics;
using Polynoms;

double[] a = Enumerable.Range(0, 51).Select(i => i % 2 == 0 ? (double)i : -i)/*.Reverse()*/.ToArray();

Array.Reverse(a);

const double x0 = 7;

var start_time = DateTime.Now;
//var ticks_count_from_system_start = Environment.TickCount; // количество времени в тиках (тактах), прошедшее с момента запуска системы
var timer = new Stopwatch();

#region "Разогрев" тестируемого кода - устранение переходных процессов: компиляция, выделения памяти и пр.

for (var i = 0; i < 1000; i++)
{
    var y = Polynom.GetValueNaive(a, x0);
} 

#endregion

const int count = 1_000_000;

var sum_len = 0.0;
for (var i = 0; i < count; i++)
{
    timer.Start();
    var y = Polynom.GetValueNaive(a, x0);
    timer.Stop();
    sum_len += y;
}

Console.WriteLine(sum_len);

var delta_time = DateTime.Now - start_time;
var delta_time2 = timer.Elapsed;

Console.WriteLine("Вычисление заняло {0} мс", delta_time2.TotalMilliseconds / count);

Console.ReadLine();