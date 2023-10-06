Pizza pizza1 = new ItalianPizza("Итальянская пицца");
pizza1=new TomatoPizza(pizza1);
Console.WriteLine($"Название:{pizza1.Name}");
Console.WriteLine($"Стоимость:{pizza1.GetCost()}");

Pizza pizza2 = new ItalianPizza("Итальянская пицца");
pizza2 = new CheesePizza(pizza2);
Console.WriteLine($"Название:{pizza2.Name}");
Console.WriteLine($"Стоимость:{pizza2.GetCost()}");

Pizza pizza3 = new GermanPizza("Немецкая пицца");
pizza3 = new TomatoPizza(pizza3);
Console.WriteLine($"Название:{pizza3.Name}");
Console.WriteLine($"Стоимость:{pizza3.GetCost()}");
abstract class Pizza
{
    protected Pizza(string name)
    {
        Name = name;
    }
    public string Name { get; set; }
    public abstract int GetCost();
}
class ItalianPizza : Pizza
{
    public ItalianPizza(string name) : base(name){}
    public override int GetCost()
    {
        return 10;
    }
}
class GermanPizza : Pizza
{
    public GermanPizza(string name) : base(name){}
    public override int GetCost()
    {
        return 15;
    }
}
abstract class PizzaDecorator : Pizza
{
    protected Pizza pizza;

    protected PizzaDecorator(string name,Pizza pizza) : base(name)
    {
        this.pizza = pizza;
    }
}
class TomatoPizza : PizzaDecorator
{
    public TomatoPizza(Pizza pizza) : base(pizza.Name+" с томатом",pizza){}
    public override int GetCost()
    {
        return pizza.GetCost()+3;
    }
}
class CheesePizza : PizzaDecorator
{
    public CheesePizza(Pizza pizza) : base(pizza.Name + " с сыром", pizza) { }
    public override int GetCost()
    {
        return pizza.GetCost() + 5;
    }
}