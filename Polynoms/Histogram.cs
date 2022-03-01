namespace Polynoms;

public class Histogram
{
    private readonly int[] _Counts;

    public int IntervalsCount { get; }
    public int SamplesCount { get; }

    public double Min { get; }
    public double Max { get; }

    public double IntervalLength => Max - Min;

    public double dx { get; }

    public double Mean { get; }
    public double Variance { get; }
    public double StdDev { get; }

    public IReadOnlyList<int> Counts => _Counts;

    public double this[int index] => _Counts[index] / (double)SamplesCount;

    public Histogram(double[] Samples, int IntervalsCount)
    {
        this.IntervalsCount = IntervalsCount;
        SamplesCount = Samples.Length;

        var min = double.PositiveInfinity;
        var max = double.NegativeInfinity;

        var sum = 0d;
        var sum2 = 0d;

        foreach (var x in Samples)
        {
            if (x < min)
                min = x;

            if (x > max)
                max = x;

            sum += x;
            sum2 += x * x;
        }

        var average = sum / Samples.Length;                         // мат.ожидание (среднее по выборке)
        var variance = sum2 / Samples.Length - average * average;   // дисперсия
        var stddev = Math.Sqrt(variance);                           // СКО

        Min = min;
        Max = max;
        Mean = average;
        Variance = variance;
        StdDev = stddev;

        var dx = IntervalLength / IntervalsCount;
        this.dx = dx;

        var counts = new int[IntervalsCount];
        _Counts = counts;
        foreach (var x in Samples)
        {
            if(x != max)
            {
                var index = (int)((x - min) / dx);
                counts[index]++;
            }
            else
            {
                var index = (int)((x - min) / dx) - 1;
                counts[index]++;
            }


            //for (var i = 0; i < IntervalsCount; i++)
            //{

            //    var interval_min = min + i * dx;
            //    var interval_max = interval_min + dx;

            //    if (i < IntervalsCount - 1)
            //    {
            //        if (x >= interval_min && x < interval_max)
            //        {
            //            counts[i]++;
            //            continue;
            //        }
            //    }
            //    else
            //    {
            //        if (x >= interval_min && x <= interval_max)
            //        {
            //            counts[i]++;
            //            continue;
            //        }
            //    }
            //}
        }

    }
}