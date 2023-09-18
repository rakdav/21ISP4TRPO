//общее определение
//using System;

//abstract class AbstractFactory
//{
//    public abstract AbstractProductA CreateProductA();
//    public abstract AbstractProductB CreateProductB();
//}
//class ConcreteFactory1 : AbstractFactory
//{
//    public override AbstractProductA CreateProductA()
//    {
//        return new ProductA1();
//    }

//    public override AbstractProductB CreateProductB()
//    {
//        return new ProductB1();
//    }
//}

//class ConcreteFactory2 : AbstractFactory
//{
//    public override AbstractProductA CreateProductA()
//    {
//        return new ProductA2();
//    }

//    public override AbstractProductB CreateProductB()
//    {
//        return new ProductB2();
//    }
//}
//abstract class AbstractProductA { }
//abstract class AbstractProductB { }

//class ProductA1:AbstractProductA {}
//class ProductA2 : AbstractProductA {}
//class ProductB1 : AbstractProductB { }
//class ProductB2 : AbstractProductB { }

//class Client
//{
//    private AbstractProductA abstractProductA;
//    private AbstractProductB abstractProductB;

//    public Client(AbstractFactory factory)
//    {
//        this.abstractProductA = factory.CreateProductA();
//        this.abstractProductB = factory.CreateProductB();
//    }
//    public void Run()
//    {

//    }
//}

//эльфы - летают и стреляет из лука
//орк - бегает и управляет мячем


Hero elf = new Hero(new Elf());
elf.Hit();
elf.Run();

Hero ork = new Hero(new Ork());
ork.Hit();
ork.Run();

abstract class HeroFactory
{
    public abstract Motion CreateMotion();
    public abstract Weapon CreateWeapon();
}

abstract class Motion
{
    public abstract void Move();
}

abstract class Weapon
{
    public abstract void Hit();
}
class Bow : Weapon
{
    public override void Hit()
    {
        Console.WriteLine("Стреляю из лука");
    }
}
class Sword : Weapon
{
    public override void Hit()
    {
        Console.WriteLine("Дерусь мечом");
    }
}

class Fly : Motion
{
    public override void Move()
    {
        Console.WriteLine("Я летаю");
    }
}
class Run : Motion
{
    public override void Move()
    {
        Console.WriteLine("Я бегаю");
    }
}

class Elf : HeroFactory
{
    public override Motion CreateMotion()
    {
        return new Fly();
    }

    public override Weapon CreateWeapon()
    {
        return new Bow();
    }
}
class Ork : HeroFactory
{
    public override Motion CreateMotion()
    {
        return new Run();
    }

    public override Weapon CreateWeapon()
    {
        return new Sword();
    }
}

class Hero
{
    private Weapon weapon;
    private Motion motion;

    public Hero(HeroFactory factory)
    {
        weapon = factory.CreateWeapon();
        motion = factory.CreateMotion();
    }
    public void Run()
    {
        motion.Move();
    }
    public void Hit()
    {
        weapon.Hit();
    }
}
