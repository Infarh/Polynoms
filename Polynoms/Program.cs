
using System.Globalization;

using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.ImageSharp;
using OxyPlot.Legends;
using OxyPlot.Series;

using Polynoms;

double[] A = { -3, -7, 2, 5 };
double[] B = { 7, 10, -5, -12 };

var p = new Polynom(A);
var q = new Polynom(B);

const double x1 = -1;
const double x2 = 1;
const int points_count = 101;
const double dx = (x2 - x1) / (points_count - 1);

using var file = File.CreateText("polinom.csv");
//CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
//CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

for (var x = x1; x <= x2; x += dx)
{
    file.WriteLine("{0};{1}",
        x.ToString(CultureInfo.CurrentCulture),
        p.Value(x).ToString(CultureInfo.CurrentCulture));

    //file.WriteLine("{0};{1}",
    //    x.ToString(CultureInfo.InvariantCulture),
    //    p.Value(x).ToString(CultureInfo.InvariantCulture));
}

var plot_model = new PlotModel
{
    Title = "График полинома",
    Background = OxyColors.White,
    Series =
    {
        new FunctionSeries(p.Value, x1, x2, dx)
        {
            Color = OxyColors.Red,
            StrokeThickness = 2,
            LineStyle = LineStyle.Solid,
            Title = "p(x) =   5x^3 + 2x^2 -  7x - 3",
        },
        new FunctionSeries(q.Value, x1, x2, dx)
        {
            Color = OxyColors.Blue,
            StrokeThickness = 2,
            LineStyle = LineStyle.Dash,
            Title = "p(x) = -12x^3 - 5x^2 + 10x + 7",
        },
    },
    Axes =
    {
        new LinearAxis
        {
            Position = AxisPosition.Left,
            MajorGridlineStyle = LineStyle.Dash,
            MinorGridlineStyle = LineStyle.Dot,
            MajorGridlineColor = OxyColors.Gray,
            MinorGridlineColor = OxyColors.LightGray,
        },
        new LinearAxis
        {
            Position = AxisPosition.Bottom,
            MajorGridlineStyle = LineStyle.Dash,
            MinorGridlineStyle = LineStyle.Dot,
            MajorGridlineColor = OxyColors.Gray,
            MinorGridlineColor = OxyColors.LightGray,
        }
    },
    IsLegendVisible = true,
    Legends =
    {
        new Legend
        {
            LegendPosition = LegendPosition.LeftTop,
            LegendBackground = OxyColors.White,
            LegendBorder = OxyColors.Black,
            LegendBorderThickness = 1,
            LegendFontSize = 18,
        }
    },
};

var png_exporter = new PngExporter(800, 600, 90);

using var png_file = File.Create("graph.png");
png_exporter.Export(plot_model, png_file);