namespace spacebattletests;
using TechTalk.SpecFlow;
using spacebattle;

[Binding]
public class UnitTest1
{
    private double[] res = new double[2];
    private double[] start = new double[2];
    private double[] speed = new double[2];
    private Exception excep = new Exception();
    
    [When("происходит прямолинейное равномерное движение без деформации")]
    public void Move()
    {
        try
        {
            res = SpaceBattle.StraightMove(start, speed);
        }
        catch (Exception e)
        {
            excep = e;
        }
    }

    [Given(@"космический корабль находится в точке пространства с координатами \((.*), (.*)\)")]
    public void StartCoord(double x, double y)
    {
        start[0] = x;
        start[1] = y;
    }

    [Given(@"имеет мгновенную скорость \((.*), (.*)\)")]
    public void Speed(double v1, double v2)
    {
        speed[0] = v1;
        speed[1] = v2;
    }

    [Given(@"космический корабль, положение в пространстве которого невозможно определить")]
    public void NoStart()
    {
        start[0] = Double.PositiveInfinity;
        start[1] = Double.PositiveInfinity;
    }
    
    [Given(@"скорость корабля определить невозможно")]
    public void NoSpeed()
    {
        speed[0] = Double.PositiveInfinity;
        speed[1] = Double.PositiveInfinity;
    }
    
    [Given(@"изменить положение в пространстве космического корабля невозможно")]
    public void NoMove()
    {
        res[0] = Double.PositiveInfinity;
        res[1] = Double.PositiveInfinity;
    }
    
    [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
    public void Finish(double f0, double f1)
    {
        double[] expected = new double[]{f0, f1};
        Assert.Equal(expected, res);
    }

    [Then(@"возникает ошибка Exception")]
    public void Error()
    {
        Assert.Throws<ArgumentException>(() => SpaceBattle.StraightMove(start, speed));
    }
}
