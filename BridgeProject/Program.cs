//Формальное описание
//Abstraction abstraction=new RefinedAbstraction(new ConctreteImplementorA());
//abstraction.Operation();
//abstraction.Implementor=new ConctreteImplementorB();
//abstraction.Operation();
//abstract class Abstraction
//{
//    protected Implementation implementor;
//    public Implementation Implementor
//    {
//        set { implementor = value; }
//    }
//    public Abstraction(Implementation implementor)
//    {
//        this.implementor = implementor;
//    }
//    public virtual void Operation()
//    {
//        implementor.OperationImp();
//    }
//}
//abstract class Implementation
//{
//    public abstract void OperationImp();
//}
//class RefinedAbstraction : Abstraction
//{
//    public RefinedAbstraction(Implementation implementor) : base(implementor)
//    {
//    }
//    public override void Operation()
//    {
//    }
//}
//class ConctreteImplementorA : Implementation
//{
//    public override void OperationImp()
//    {
//    }
//}
//class ConctreteImplementorB : Implementation
//{
//    public override void OperationImp()
//    {
//    }
//}
//программисты

Programmer csharpProgrammer = new FreeLanceProgrammer(new CSharpProgrammer());
csharpProgrammer.DoWork();
csharpProgrammer.EarnMoney();
Programmer javaProgrammer = new CorporationProgrammer(new JavaProgrammer());
javaProgrammer.DoWork();
javaProgrammer.EarnMoney();

interface ILanguage
{
    void Build();
    void Execute();
}
class CSharpProgrammer : ILanguage
{
    public void Build()
    {
        Console.WriteLine("С помощью компилятора компилируем программу в код exe");
    }

    public void Execute()
    {
        Console.WriteLine("JIT компилирует программу в бинарный код");
        Console.WriteLine("CLR выполняет скомпилированный бинарный код");
    }
}
class JavaProgrammer : ILanguage
{
    public void Build()
    {
        Console.WriteLine("С помощью компилятора компилируем программу в байт код");
    }

    public void Execute()
    {
        Console.WriteLine("Запускаем jar файл");
    }
}

abstract class Programmer
{
    protected ILanguage language;
    protected Programmer(ILanguage lang)
    {
        language = lang;    
    }
    public ILanguage Language
    {
        set { language = value; }
    }
    public virtual void DoWork()
    {
        language.Build();
        language.Execute();
    }
    public abstract void EarnMoney();
}
class FreeLanceProgrammer : Programmer
{
    public FreeLanceProgrammer(ILanguage lang):base(lang){}
    public override void EarnMoney()
    {
        Console.WriteLine("Получаем оплату за выполненный заказ");
    }
}
class CorporationProgrammer : Programmer
{
    public CorporationProgrammer(ILanguage lang) : base(lang)
    {
    }

    public override void EarnMoney()
    {
        Console.WriteLine("Получаем в конце месяца");
    }
}