namespace Polynoms;

public static class NormalDistribution
{
    public static double Distribution(double x, double mu = 0, double sigma = 1)
    {
        var xx = (x - mu) / sigma;
        return Math.Exp(-0.5 * xx * xx) / (sigma * Math.Sqrt(Math.PI * 2));
    }
}