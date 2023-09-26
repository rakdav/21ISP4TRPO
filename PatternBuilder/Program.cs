using System.Text;

//Builder builder=new ConcreteBuilder();
//Director dirtector=new Director(builder);
//dirtector.Construct();
//Product product=builder.GetResult();
//abstract class Builder
//{
//    public abstract void BiuldPartA();
//    public abstract void BiuldPartB();
//    public abstract void BiuldPartC();
//    public abstract Product GetResult();
//}
//class Product
//{
//    List<object> parts=new List<object>();
//    public void Add(string part)
//    {
//        parts.Add(part);
//    }
//}
//class ConcreteBuilder:Builder
//{
//    Product product=new Product();

//    public override void BiuldPartA()
//    {
//        product.Add("Part A");
//    }

//    public override void BiuldPartB()
//    {
//        product.Add("Part B");
//    }

//    public override void BiuldPartC()
//    {
//        product.Add("Part C");
//    }

//    public override Product GetResult()
//    {
//        return product;
//    }
//}
//class Director
//{
//    Builder builder;
//    public Director(Builder builder)
//    {
//        this.builder = builder;
//    }
//    public void Construct()
//    {
//        builder.BiuldPartA();
//        builder.BiuldPartB();
//        builder.BiuldPartC();
//    }
//}

//Изготовление хлеба
Baker baker = new Baker();
BreadBuilder builder = new BlackBuilder();
Bread blackBread = baker.Bake(builder);
Console.WriteLine(blackBread);

builder = new WhiteBuilder();
Bread white = baker.Bake(builder);
Console.WriteLine(white);
abstract class BreadBuilder
{
    public Bread Bread { get; private set; }
    public void CreateBread()
    {
        Bread = new Bread();
    }
    public abstract void SetFlour();
    public abstract void SetSalt();
    public abstract void SetAddities();
}
class Flour
{
    public string Sort { get; set; }
}
class Salt { }
class Additives
{
    public string Name { get; set; }
}
class Bread
{
    public Flour Flour { get; set; }
    public Salt Salt { get; set; }
    public Additives Additivies { get; set; }

    public override string? ToString()
    {
        StringBuilder sb = new StringBuilder();
        if (Flour != null)
            sb.Append(Flour.Sort + "\n");
        if (Salt != null)
            sb.Append("Соль \n");
        if (Additivies != null)
            sb.Append("Добавки "+Additivies.Name+" \n");
        return sb.ToString();
    }
}
class Baker
{
    public Bread Bake(BreadBuilder breadBuilder)
    {
        breadBuilder.CreateBread();
        breadBuilder.SetFlour();
        breadBuilder.SetSalt();
        breadBuilder.SetAddities();
        return breadBuilder.Bread;
    }
}
class BlackBuilder : BreadBuilder
{
    public override void SetAddities()
    {
    }

    public override void SetFlour()
    {
        this.Bread.Flour = new Flour { Sort = "Ржаная мука" };
    }

    public override void SetSalt()
    {
        this.Bread.Salt = new Salt();
    }
}
class WhiteBuilder : BreadBuilder
{
    public override void SetAddities()
    {
        this.Bread.Additivies = new Additives { Name = "Тмин" };
    }

    public override void SetFlour()
    {
        this.Bread.Flour = new Flour { Sort = "Мука белая" };
    }

    public override void SetSalt()
    {
        this.Bread.Salt = new Salt();
    }
}
