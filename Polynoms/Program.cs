
using OxyPlot;
using OxyPlot.ImageSharp;
using OxyPlot.Series;

using Polynoms;

var rnd = new Random();

const int count = 100_000;

var samples = new double[count];

for (var i = 0; i < count; i++)
{
    var x = (rnd.NextDouble() * 2 - 1)
        + (rnd.NextDouble() * 2 - 1)
        + (rnd.NextDouble() * 2 - 1)
        + (rnd.NextDouble() * 2 - 1)
        + (rnd.NextDouble() * 2 - 1)
        ;

    samples[i] = x / 1.3;
}


const int intervals_count = 20;
var histogram = new Histogram(samples, intervals_count);

var histogram_values = new HistogramItem[intervals_count];
for (var i = 0; i < intervals_count; i++)
{
    var min = histogram.Min + i * histogram.dx;
    var max = min + histogram.dx;
    histogram_values[i] = new HistogramItem(min, max, histogram[i], 0);
}

var plot = new PlotModel
{
    Title = "Гистограмма выборки случайной величины",
    Background = OxyColors.White,
    Series =
    {
        new HistogramSeries
        {
            FillColor = OxyColors.Blue,
            StrokeColor = OxyColors.DarkBlue,
            StrokeThickness = 1,
            ItemsSource = histogram_values
        },
        new FunctionSeries(x => NormalDistribution.Distribution(x), histogram.Min, histogram.Max, histogram.dx / 20)
        {
            Color = OxyColors.Red,
        }
    }
};


var exporter = new PngExporter(800, 600);

using(var histogram_file = File.Create("histogram.png"))
    exporter.Export(plot, histogram_file);

//Console.WriteLine();