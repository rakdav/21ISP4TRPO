Singlton s = Singlton.getInstance();
Computer comp = new Computer();
comp.Launch("Windows");
Console.WriteLine(comp.Os.Name);

comp.Launch("Linux");
Console.WriteLine(comp.Os.Name);

class Singlton
{
    private static Singlton instance;
    private Singlton(){}
    public static Singlton getInstance()
    {
        if (instance == null)
            instance = new Singlton();
        return instance;
    }
}
class Computer
{
    public OS Os { get; set; }
    public void Launch(string osName)
    {
        Os = OS.getInstance(osName);
    }
}
class OS
{
    private static OS instance;
    public OS(string name)
    {
        this.Name = name;
    }
    public string Name { get; private set; }
    public static OS getInstance(string name) 
    {
        if(instance==null)
            instance = new OS(name);
        return instance;
    }
}

