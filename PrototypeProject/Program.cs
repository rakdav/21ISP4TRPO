//формальная структура
//class Client
//{
//    public void Operation()
//    {
//        Prototype prototype=new ConcretePrototype1(1);
//        Prototype clone=prototype.Clone();
//        prototype=new ConcretePrototype2(2);
//        clone = prototype.Clone();
//    }
//}
//abstract class Prototype
//{
//    public int Id { get; private set; }

//    protected Prototype(int id)
//    {
//        Id = id;
//    }
//    public abstract Prototype Clone();
//}
//class ConcretePrototype1 : Prototype
//{
//    public ConcretePrototype1(int id) : base(id)
//    {
//    }

//    public override Prototype Clone()
//    {
//        return new ConcretePrototype1(Id);
//    }
//}
//class ConcretePrototype2 : Prototype
//{
//    public ConcretePrototype2(int id) : base(id)
//    {
//    }

//    public override Prototype Clone()
//    {
//        return new ConcretePrototype2(Id);
//    }
//}
//пример
IFigure figure = new Rectangle(30, 40);
IFigure clonedRec=figure.Clone();
figure.GetInfo();
clonedRec.GetInfo();

figure = new Circle(50);
clonedRec=figure.Clone();
figure.GetInfo();
clonedRec.GetInfo();

interface IFigure
{
    IFigure Clone();
    void GetInfo();
}
class Rectangle:IFigure
{
    int width,height;

    public Rectangle(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public IFigure Clone()
    {
        return new Rectangle(this.width,this.height);
    }

    public void GetInfo()
    {
        Console.WriteLine("Прямоугольник длиной {0} и ширирной {1}",width,height);
    }
}
class Circle:IFigure
{
    private int radius;

    public Circle(int radius)
    {
        this.radius = radius;
    }

    public IFigure Clone()
    {
        return new Circle(this.radius);
    }

    public void GetInfo()
    {
        Console.WriteLine("Круг радиусом {0}",radius);
    }
}

//Имеются две модели "Грузовик" и "Легковой автомобиль". Написать программу создания новых объектов на основе уже созданных
