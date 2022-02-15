
using System.Globalization;
using Polynoms;

double[] A = { -3, -7, 2, 5 };

var p = new Polynom(A);

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
        x.ToString(CultureInfo.InvariantCulture),
        p.Value(x).ToString(CultureInfo.InvariantCulture));
}