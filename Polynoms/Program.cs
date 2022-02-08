
using Polynoms;

double[] P = { -3, -7, 2, 5 };

double x = 5;

Polynom p = new Polynom(P);

var y = Polynom.GetValueHorner(P, x);
var y2 = p.Value(5);

Console.WriteLine("y(x) = {0}", y);
Console.WriteLine("y2(x) = {0}", y2);
