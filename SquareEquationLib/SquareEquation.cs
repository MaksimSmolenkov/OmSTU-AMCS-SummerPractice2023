namespace SquareEquationLib;
public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double[] answer;
        double eps= 1e-9;

        if ((-eps < a && a < eps) || Double.IsNaN(a) || Double.IsNaN(b) || Double.IsNaN(c) || Double.IsPositiveInfinity(a) || Double.IsPositiveInfinity(b)|| Double.IsPositiveInfinity(c) || Double.IsNegativeInfinity(a) || Double.IsNegativeInfinity(b) || Double.IsNegativeInfinity(c))
        {
            throw new System.ArgumentException();
        }
        double d = b*b - 4 * c;
             
        if (d>=eps)
        {
            answer = new double[2];
            if (b==0)
            {
                answer[0] = Math.Sqrt(d) / 2;
                answer[1] = c / answer[0];
            }
            else
            {
                answer[0] = (-(b + Math.Sign(b) * Math.Sqrt(d)) / 2);
                answer[1] = c / answer[0];
            }
        }

        else if (Math.Abs(d)<eps)
        {
            answer = new double[1];
            answer[0] = (-b/(2*a));

        }
        else 
        {
           answer = new double[0];
        }     
        return answer;
    }
}
    
