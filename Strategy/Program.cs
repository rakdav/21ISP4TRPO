//public interface IStrategy
//{
//    void Algorithm();
//}
//public class ConcreteStrategy1 : IStrategy
//{
//    public void Algorithm(){}
//}
//public class ConcreteStrategy2 : IStrategy
//{
//    public void Algorithm() { }
//}
//public class Context
//{
//    public IStrategy? ContextStrategy { get; set;}
//    public Context(IStrategy? contextStrategy)
//    {
//        ContextStrategy = contextStrategy;
//    }
//    public void ExecuteAlgirithm()
//    {
//        ContextStrategy!.Algorithm();
//    }
//}

Car? auto = new Car(4, "Volve", new OilMove());
auto.Move();
auto.Moveable = new ElectricMove();
auto.Move();
interface IMoveable
{
    void Move();
}
class OilMove : IMoveable
{
    public void Move()
    {
        Console.WriteLine("Перемещение на бензине");
    }
}
class ElectricMove : IMoveable
{
    public void Move()
    {
        Console.WriteLine("Перемещение на электричестве");
    }
}
class Car
{
    protected int passenges;
    protected string? model;
    public IMoveable? Moveable { private get; set; }

    public Car(int passenges, string? model, IMoveable? moveable)
    {
        this.passenges = passenges;
        this.model = model;
        Moveable = moveable;
    }
    public void Move()
    {
        Moveable!.Move();
    }
}
