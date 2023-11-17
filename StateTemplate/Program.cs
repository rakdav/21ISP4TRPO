//Context context = new Context(new StateA());
//context.Request();
//context.Request();
//abstract class State
//{
//    public abstract void Handle(Context context);
//}
//class StateA : State
//{
//    public override void Handle(Context context)
//    {
//        context.State = new StateA();
//    }
//}
//class StateB : State
//{
//    public override void Handle(Context context)
//    {
//        context.State = new StateB();
//    }
//}
//class Context
//{
//    public State? State { get; set; }
//    public Context(State? state)
//    {
//        State = state;
//    }
//    public void Request()
//    {
//        this.State?.Handle(this);
//    }
//}

Water water = new Water(new LiquidState());
water.Heat();
water.Frost();
water.Frost();
water.Heat();
interface IWaterState
{
    void Heat(Water water);
    void Frost(Water water);
}
class Water
{
    public IWaterState? State { get; set; }
    public Water(IWaterState? state)
    {
        State = state;
    }
    public void Heat()
    {
        State?.Heat(this);
    }
    public void Frost()
    {
        State?.Frost(this);
    }
}

class SolidWaterState : IWaterState
{
    public void Frost(Water water)
    {
        Console.WriteLine("Продолжаем замораживать");
    }
    public void Heat(Water water)
    {
        Console.WriteLine("Превращение льда в жидкость");
        water.State = new LiquidState();
    }
}
class LiquidState : IWaterState
{
    public void Frost(Water water)
    {
        Console.WriteLine("Превращение воды в лед");
        water.State=new SolidWaterState();
    }

    public void Heat(Water water)
    {
        Console.WriteLine("Превращение воды в газ");
        water.State = new GasState();
    }
}

class GasState : IWaterState
{
    public void Frost(Water water)
    {
        Console.WriteLine("Превращение газа в жидкость");
        water.State = new LiquidState();
    }
    public void Heat(Water water)
    {
        Console.WriteLine("Дальнейшее нагревание газа");
    }
}
