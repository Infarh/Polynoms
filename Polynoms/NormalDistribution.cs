namespace Polynoms;

public static class NormalDistribution
{
    public static double Distribution(double x, double mu = 0, double sigma = 1)
    {
        var xx = (x - mu) / sigma;
        return Math.Exp(-0.5 * xx * xx) / (sigma * Math.Sqrt(Math.PI * 2));
    }

    public static double NextNormal(this Random rnd, double sigma = 1, double mu = 0)
    {
        var u1 = rnd.NextDouble();
        var u2 = rnd.NextDouble();
        var normal = Math.Sqrt(-2 * Math.Log(u1)) * Math.Sin(2 * Math.PI * u2);
        return mu + sigma * normal;
    }
}