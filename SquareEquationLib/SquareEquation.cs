namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double[] answer;
        double eps= 1e-9;
        if (a = 0)
        {
            throw new System.ArgumentException();
        }
        if ((-eps < a && a < eps)||Double.IsNaN(a) || Double.IsNaN(b) || Double.IsNaN(c) || Double.IsPositiveInfinity(a)|| Double.IsPositiveInfinity(b)|| Double.IsPositiveInfinity(c) || Double.IsNegativeInfinity(a)|| Double.IsNegativeInfinity(b)|| Double.IsNegativeInfinity(c))
        {
            throw new System.ArgumentException();
        }
        double d = b*b - 4 * c;
        
        if (d < -eps)                   
        {
            answer = new double[0];
        }
        else if (-eps < d && d < eps)   
        {
            answer = new double[1];
            answer[0] = -b / 2;
        }
        else                            
        {
            answer = new double[2];
            answer[0] = -(b + Math.Sign(b) * Math.Sqrt(d)) / 2;
            answer[1] = c / answer[0];
        }
        
        return answer;
    }
}
    
