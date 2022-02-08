
using Polynoms;

double[] A = { -3, -7, 2, 5 };
double[] B = {  7, 10, 1, 1 };

double x = 5;

Polynom p1 = new Polynom(A);
Polynom p2 = new Polynom(B);

Polynom p3 = p1 + p2;

//var y = Polynom.GetValueHorner(A, x);

var y1 = p1.Value(5);
var y2 = p2.Value(5);
var y3 = p3.Value(5);

Console.WriteLine("y1(x) = {0}", y1);
Console.WriteLine("y2(x) = {0}", y2);
Console.WriteLine("y1(x) + y2(x) = {0}", y1 + y2);
Console.WriteLine("y3(x) = {0}", y3);
