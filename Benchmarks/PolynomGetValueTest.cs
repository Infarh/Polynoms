using BenchmarkDotNet.Attributes;
using Polynoms;

namespace Benchmarks;

[MemoryDiagnoser]
[RPlotExporter]
public class PolynomGetValueTest
{
    private static readonly double[] __A = Enumerable.Range(0, 51).Select(i => i % 2 == 0 ? (double)i : -i).Reverse().ToArray();
    private const double __X0 = 7;

    [Benchmark]
    public double GetValue()
    {
        var y = Polynom.GetValue(__A, __X0);
        return y;
    }

    [Benchmark]
    public double GetValueNaive()
    {
        var y = Polynom.GetValueNaive(__A, __X0);
        return y;
    }

    [Benchmark(Baseline = true)]
    public double GetValueHorner()
    {
        var y = Polynom.GetValueHorner(__A, __X0);
        return y;
    }

    [Benchmark]
    public double GetPolynomValue()
    {
        var p = new Polynom(__A);
        return p.Value(__X0);
    }
}