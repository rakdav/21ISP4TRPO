//Facade facade=new Facade(new SubSystemA(), new SubSystemB(),
//    new SubSystemC());
//facade.Operation1();
//facade.Operation2();
//class SubSystemA
//{
//    public void A1() { }
//}
//class SubSystemB
//{
//    public void B1() { }
//}
//class SubSystemC
//{
//    public void C1() { }
//}
//class Facade
//{
//    SubSystemA subSystemA;
//    SubSystemB subSystemB;
//    SubSystemC subSystemC;

//    public Facade(SubSystemA subSystemA, SubSystemB subSystemB, SubSystemC subSystemC)
//    {
//        this.subSystemA = subSystemA;
//        this.subSystemB = subSystemB;
//        this.subSystemC = subSystemC;
//    }
//    public void Operation1()
//    {
//        subSystemA.A1();
//        subSystemB.B1();
//        subSystemC.C1();
//    }
//    public void Operation2()
//    {
//        subSystemB.B1();
//        subSystemC.C1();
//    }
//}
TextEditor textEditor = new TextEditor();
Compiler compiler= new Compiler();
CLR clr= new CLR();
VisualStudioFacade ide=new VisualStudioFacade(textEditor,compiler,clr);
Programmer programmer= new Programmer();
programmer.CreateApplication(ide);
class TextEditor
{
    public void CreateCode()
    {
        Console.WriteLine("Написание кода");
    }
    public void Save() 
    {
        Console.WriteLine("Сохранение кода");
    }
}
class Compiler
{
    public void Compile()
    {
        Console.WriteLine("Компиляция приложения");
    }
}
class CLR
{
    public void Execute()
    {
        Console.WriteLine("Выполнение приложения");
    }
    public void Finish()
    {
        Console.WriteLine("завершение работы");
    }
}
class VisualStudioFacade
{
    TextEditor textEditor;
    Compiler compiler;
    CLR clr;
    public VisualStudioFacade(TextEditor textEditor, Compiler compiler, CLR clr)
    {
        this.textEditor = textEditor;
        this.compiler = compiler;
        this.clr = clr;
    }
    public void Start()
    {
        textEditor.CreateCode();
        textEditor.Save();
        compiler.Compile();
        clr.Execute();
    }
    public void Finish()
    {
        clr.Finish();
    }
}
class Programmer
{
    public void CreateApplication(VisualStudioFacade facade)
    {
        facade.Start();
        facade.Finish();
    }
}
