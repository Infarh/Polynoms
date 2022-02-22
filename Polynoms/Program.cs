
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

    samples[i] = x / 5;
}


const int intervals_count = 20;
var histogram = new Histogram(samples, intervals_count);


Console.WriteLine();