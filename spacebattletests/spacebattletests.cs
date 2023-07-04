namespace spacebattletests;
using TechTalk.SpecFlow;
using spacebattle;

[Binding]
public class StraightMoveTest
{
    private double[] res = new double[2];
    private double[] start = new double[2];
    private double[] speed = new double[2];
    private double[] badstart = new double[2];
    private double[] badspeed = new double[2];
    public bool CanMove = true;
    public bool ErrorTypeMove, ErrorTypeRotate;
    private double FuelReserve, FuelConsumption, remains;
    private Exception excep = new Exception();
    private Exception excep1 = new Exception();
    public bool CanTurn = true;
    private double angle, change_angle, res_angle;

    [When(@"происходит вращение вокруг собственной оси")]
    public void ShipTurns()
    {
        try
        {
            res_angle = SpaceBattle.Turn(angle, change_angle, CanTurn);
        }
        catch (Exception e)
        {
            excep1 = e;
        }
    }

    [Given(@"космический корабль имеет угол наклона (.*) град к оси OX")]
    public void StartAngle(double a)
    {
        angle = a;
    }
    
    [Given(@"космический корабль, угол наклона которого невозможно определить")]
    public void NoStartAngle()
    {
        angle = Double.NaN;
        ErrorTypeRotate = true;
    }

    [Given(@"имеет мгновенную угловую скорость (.*) град")]
    public void AngVelocity(double a)
    {
        change_angle = a;
    }

    [Given(@"мгновенную угловую скорость невозможно определить")]
    public void NoAngVelocity()
    {
        change_angle = Double.NaN;
        ErrorTypeRotate = true;
    }
    
    [Given(@"невозможно изменить уголд наклона к оси OX космического корабля")]
    public void CantChangeAngle()
    {      
        CanTurn = false;
        ErrorTypeRotate = true;
    }

    [Then(@"угол наклона космического корабля к оси OX составляет (.*) град")]
    public void ShipAngle(double p)
    {
        double excepted = p;
        Assert.Equal(excepted, res_angle);
    }
    
    [When("происходит прямолинейное равномерное движение без деформации")]
    public void Move()
    {
        try
        {
            res = SpaceBattle.StraightMove(start, speed, CanMove);
            remains = SpaceBattle.Fuel(FuelConsumption, FuelReserve);
        }
        catch (Exception e)
        {
            excep = e;
        }
    }

    [Given(@"космический корабль имеет топливо в объеме (.*) ед")]
    public void HaveFuel(double f)
    {
        FuelReserve = f;
    }

    [Given(@"имеет скорость расхода топлива при движении (.*) ед")]
    public void ВuelСonsumption(double a)
    {
        FuelConsumption = a;
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
        badstart[0] = Double.NaN;
        badstart[1] = Double.NaN;
        ErrorTypeMove = true;
    }
    
    [Given(@"скорость корабля определить невозможно")]
    public void NoSpeed()
    {
        badspeed[0] = Double.NaN;
        badspeed[1] = Double.NaN;
        ErrorTypeMove = true;
    }
    
    [Given(@"изменить положение в пространстве космического корабля невозможно")]
    public void NoMove()
    {
        CanMove = false;
        ErrorTypeMove = true;
    }
    
    [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
    public void Finish(double f0, double f1)
    {
        double[] expected = new double[]{f0, f1};
        Assert.Equal(expected, res);
    }

    [Then(@"новый объем топлива космического корабля равен (.*) ед")]
    public void FuelRemains(double e)
    {
        double excepted = e;
        Assert.Equal(excepted, remains);
    }

    [Then(@"возникает ошибка Exception")]
    public void Error()
    {
        if (ErrorTypeMove)
        {
            Assert.Throws<ArgumentException>(() => SpaceBattle.StraightMove(badstart, badspeed, CanMove));
        }
        else if (ErrorTypeRotate)
        {
            Assert.Throws<ArgumentException>(() => SpaceBattle.Turn(angle, change_angle, CanTurn));
        }
        else if (FuelReserve <= FuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => SpaceBattle.Fuel(FuelConsumption, FuelReserve));
        }
    }
}
