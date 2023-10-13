//Client client = new Client();
//client.Main();
//class Client
//{
//    public void Main()
//    {
//        Component root=new Composite("Root");
//        Component leaf=new Primitive("Leaf");
//        Composite subtree = new Composite("Subtree");
//        root.Add(leaf);
//        root.Add(subtree);
//        root.Display();
//    }
//}
//abstract class Component
//{
//    protected string? name;
//    protected Component(string? name)
//    {
//        this.name = name;
//    }
//    public abstract void Display();
//    public abstract void Add(Component c);
//    public abstract void Remove(Component c);
//}
//class Composite:Component
//{
//    List<Component> children=new List<Component>();
//    public Composite(string? name) : base(name)
//    {
//    }
//    public override void Add(Component c)
//    {
//        children.Add(c);
//    }
//    public override void Display()
//    {
//        Console.WriteLine(name);
//        foreach (Component c in children)
//        {
//            c.Display();
//        }
//    }
//    public override void Remove(Component c)
//    {
//        children.Remove(c);
//    }
//}
//class Primitive : Component
//{
//    public Primitive(string? name) : base(name)
//    {
//    }

//    public override void Add(Component c)
//    {
//    }

//    public override void Display()
//    {
//        Console.WriteLine(name);
//    }

//    public override void Remove(Component c)
//    {
//    }
//}

Component fileSystem = new Directory("Файловая система");
Component diskC=new Directory("Диск С:");
Component pngFile = new File("1234.png");
Component textFile = new File("little.doc");
diskC.Add(pngFile);
diskC.Add(textFile);
fileSystem.Add(diskC);
fileSystem.Print();
Console.WriteLine();
diskC.Remove(pngFile);
fileSystem.Print();
Component docFolder = new Directory("Мои документы");
Component txtFile = new File("readme.txt");
Component csFile = new File("prigram.cs");
docFolder.Add(txtFile);
docFolder.Add(csFile);
diskC.Add(docFolder);
fileSystem.Print();

abstract class Component
{
    protected string? name;
    protected Component(string? name)
    {
        this.name = name;
    }
    public virtual void Add(Component component) { }
    public virtual void Remove(Component component) { }
    public virtual void Print()
    {
        Console.WriteLine(name);
    }
}
class Directory:Component
{
    private List<Component> components=new List<Component>();
    public Directory(string? name) : base(name){}
    public override void Add(Component component)
    {
        components.Add(component);
    }
    public override void Print()
    {
        Console.WriteLine("Узел "+name);
        Console.WriteLine("Подузлы:");
        for (int i = 0; i < components.Count; i++)
        {
            components[i].Print();
        }
    }
    public override void Remove(Component component)
    {
        components.Remove(component);
    }
}
class File : Component
{
    public File(string? name) : base(name)
    {
    }
}