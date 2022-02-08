
using Polynoms;

double[] P = { -3, -7, 2, 5 };

double x = 5;

var y = Polynom.GetValue(P, x);

Console.WriteLine("y(x) = {0}", y);
