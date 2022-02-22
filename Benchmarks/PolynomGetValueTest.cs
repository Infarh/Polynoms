using BenchmarkDotNet.Attributes;
using Polynoms;

namespace Benchmarks;

public class PolynomGetValueTest
{
    private static readonly double[] __A = Enumerable.Range(0, 51).Select(i => i % 2 == 0 ? (double)i : -i).Reverse().ToArray();
    private const double __X0 = 7;

    [Benchmark]
    public void GetValue()
    {
        var y = Polynom.GetValue(__A, __X0);
    }

    [Benchmark]
    public void GetValueNaive()
    {
        var y = Polynom.GetValueNaive(__A, __X0);

    }

    [Benchmark]
    public void GetValueHorner()
    {
        var y = Polynom.GetValueHorner(__A, __X0);
    }
}