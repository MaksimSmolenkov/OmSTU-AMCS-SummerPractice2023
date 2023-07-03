namespace spacebattle;
public class SpaceBattle
{
    public static double[] StraightMove(double[] start, double[] speed)
    {
        double[] empty = new double[] {};
        double[] finish = new double[2];
        if (start == empty || speed == empty || start[0] == double.NaN || start[1] == double.NaN || speed[0] == double.NaN || speed[1] == double.NaN || speed[0] == double.PositiveInfinity || speed[1] == double.PositiveInfinity || start[0] == double.PositiveInfinity || start[1] == double.PositiveInfinity || speed[0] == double.NegativeInfinity || speed[1] == double.NegativeInfinity || start[0] == double.NegativeInfinity || start[1] == double.NegativeInfinity)
        {
            throw new System.ArgumentException();
        }
        else
        {
            finish[0] = start[0] + speed[0];
            finish[1] = start[1] + speed[1];
        }
        return finish;
    }
}
