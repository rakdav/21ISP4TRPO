//формальное определение паттерна
abstract class Product { }
class ConcreteProductA:Product { }
class ConcreteProductB:Product { }
abstract class Creator {
    public abstract Product FactoryMethod();
}
class ConcreteCreatorA : Creator
{
    public override Product FactoryMethod()
    {
        throw new NotImplementedException();
    }
}
class ConcreteCreatorB : Creator
{
    public override Product FactoryMethod()
    {
        throw new NotImplementedException();
    }
}
//пример
abstract class Developer
{
    public string Name { get; set; }
    protected Developer(string name)
    {
        Name = name;
    }
    abstract public House Create();
}

class WoodDeveloper : Developer
{
    public WoodDeveloper(string name) : base(name)
    {
    }

    public override House Create()
    {
        return new WoodHouse();
    }
}
class StoneDeveloper : Developer
{
    public StoneDeveloper(string name) : base(name)
    {
    }
    public override House Create()
    {
        return new StoneHouse();
    }
}
abstract class House
{

}
class WoodHouse : House
{
    public WoodHouse()
    {
        Console.WriteLine("Лошарик Матросов построил деревянный дом");
    }
}
class StoneHouse:House
{
    public StoneHouse()
    {
        Console.WriteLine("Матрfсов построил каменный дом");
    }
}