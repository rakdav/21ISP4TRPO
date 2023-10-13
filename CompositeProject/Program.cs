Client client = new Client();
client.Main();
class Client
{
    public void Main()
    {
        Component root=new Composite("Root");
        Component leaf=new Primitive("Leaf");
        Composite subtree = new Composite("Subtree");
        root.Add(leaf);
        root.Add(subtree);
        root.Display();
    }
}
abstract class Component
{
    protected string? name;
    protected Component(string? name)
    {
        this.name = name;
    }
    public abstract void Display();
    public abstract void Add(Component c);
    public abstract void Remove(Component c);
}
class Composite:Component
{
    List<Component> children=new List<Component>();
    public Composite(string? name) : base(name)
    {
    }
    public override void Add(Component c)
    {
        children.Add(c);
    }
    public override void Display()
    {
        Console.WriteLine(name);
        foreach (Component c in children)
        {
            c.Display();
        }
    }
    public override void Remove(Component c)
    {
        children.Remove(c);
    }
}
class Primitive : Component
{
    public Primitive(string? name) : base(name)
    {
    }

    public override void Add(Component c)
    {
    }

    public override void Display()
    {
        Console.WriteLine(name);
    }

    public override void Remove(Component c)
    {
    }
}