namespace SquareEquation.Tests;
using SquareEquationLib;
public class UnitTest1
{
    const double eps = 1e-9;
    
    [Theory]
    [InlineData(-eps/2, 2, 1)]
    [InlineData(eps/2, 2, 2)]
    [InlineData(0, 2, 1)]
    public void IsAZero(double a, double b, double c)
    {
        Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(a, b, c));
    }
    
    [Fact]
    public void IsANan()
    {
        Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(Double.NaN, 2, 3));
    }

    [Fact]
    public void IsBNan()
    {
        Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(1, Double.NaN, 3));
    }
    [Fact]
    public void IsCNan()
    {
        Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(3, 3, Double.NaN));
    }
    [Fact]
    public void IsAPositiveInfinity()
    {
        Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(Double.PositiveInfinity, 3, 2.1));
    }

    [Fact]
    public void IsANegativeInfinity()
    {
        Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(Double.NegativeInfinity, 3, 2.1));
    }

    [Fact]
    public void IsBPositiveInfinity()
    {
        Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(2, Double.PositiveInfinity, 2.1));
    }

    [Fact]
    public void IsBNegativeInfinity()
    {
        Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(1, Double.NegativeInfinity, 2.1));
    }

    [Fact]
    public void IsCPositiveInfinity()
    {
        Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(1, 1, Double.PositiveInfinity));
    }

    [Fact]
    public void IsCNegativeInfinity()
    {
        Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(3, 2, Double.NegativeInfinity));
    }
    [Fact]
    public void TwoRoots()
    {
        double[] expected = new double[] { -4, 3 };
        double[] actual = SquareEquation.Solve(1, 1, -12);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void OneRoot()
    {
        double[] expected = new double[] { -3 };
        double[] actual = SquareEquation.Solve(1, 6, 9);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DLessThanMinusEps()
    {
        double[] expected = new double[0] {};
        double[] actual = SquareEquation.Solve(1, 1, 10);

        Assert.Equal(expected, actual);
    }   
}