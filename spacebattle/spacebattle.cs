namespace spacebattle;
public class SpaceBattle
{
    public static double[] StraightMove(double[] start, double[] speed)
    {
        double[] empty = new double[] {};
        double[] finish = new double[2];
        if (start == empty || Double.IsNaN(start[0]) || Double.IsNaN(start[1]) || start[0] == Double.PositiveInfinity || start[1] == Double.PositiveInfinity || start[0] == Double.NegativeInfinity || start[1] == Double.NegativeInfinity)
        {
            throw new System.ArgumentException();
        }
        else if (speed == empty || Double.IsNaN(speed[0]) || Double.IsNaN(speed[1]) || speed[0] == Double.PositiveInfinity || speed[1] == Double.PositiveInfinity || speed[0] == Double.NegativeInfinity || speed[1] == Double.NegativeInfinity)
        {
            throw new System.ArgumentException();
        }
        else 
        {
            finish[0] = start[0] + speed[0];
            finish[1] = start[1] + speed[1];
        }
        if (finish == empty || Double.IsNaN(finish[0]) || Double.IsNaN(finish[1])| finish[0] == double.PositiveInfinity || finish[1] == double.PositiveInfinity || finish[0] == double.NegativeInfinity || finish[1] == double.NegativeInfinity)
        {
            throw new System.ArgumentException();
        }
        else
        {
            return finish;
        }
    }
}
