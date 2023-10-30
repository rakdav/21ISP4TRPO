//формальное определение
using System.Collections;
//Client clent=new Client();
//clent.Main();
//class Client
//{
//    public void Main()
//    {
//        int states = 22;
//        FlyweightFacrory f=new FlyweightFacrory();

//        FlyWeight? fx = f.GetFlyweight("X");
//        fx!.Operation(--states);

//        FlyWeight? fy = f.GetFlyweight("Y");
//        fy!.Operation(--states);

//        FlyWeight? fz = f.GetFlyweight("D");
//        fz!.Operation(--states);

//        UnsahredFlyweight uf=new UnsahredFlyweight();
//        uf.Operation(--states);
//    }
//}
//class FlyweightFacrory
//{
//    Hashtable flyweights=new Hashtable();
//    public FlyweightFacrory()
//    {
//        flyweights.Add("X",new ConcreteFlyweight());
//        flyweights.Add("Y", new ConcreteFlyweight());
//        flyweights.Add("Z", new ConcreteFlyweight());
//    }
//    public FlyWeight? GetFlyweight(string  key)
//    {
//        if(!flyweights.ContainsKey(key))
//            flyweights.Add(key, new ConcreteFlyweight());
//        return flyweights[key] as FlyWeight;
//    }
//}
//abstract class FlyWeight
//{
//    public abstract void Operation(int state);
//}
//class ConcreteFlyweight : FlyWeight
//{
//    int stateObject;

//    public override void Operation(int state)
//    {
//    }
//}
//class UnsahredFlyweight : FlyWeight
//{
//    int allObject;

//    public override void Operation(int state)
//    {
//        allObject=state;
//    }
//}

//пример
double lon = 54.2, lat = 27.7;
HouseFactory houseFactory = new HouseFactory();
for (int i = 0; i < 5; i++)
{
    House? panelHouse = houseFactory.GetHouse("Panel");
    if (panelHouse != null)
        panelHouse.Build(lon, lat);
    lon += 0.1;
    lat += 0.1;
}

for (int i = 0; i < 3; i++)
{
    House? brickHouse = houseFactory.GetHouse("Brick");
    if (brickHouse != null)
        brickHouse.Build(lon, lat);
    lon += 0.1;
    lat += 0.1;
}

abstract class House
{
    protected int stages;
    public abstract void Build(double longitude,double latitude);
}
class PanelHouse : House
{
    public PanelHouse()
    {
        stages = 16;
    }
    public override void Build(double longitude, double latitude)
    {
        Console.WriteLine($"Построен панельный дом из {stages} этажей;" +
            $" координаты {longitude:F2}:{latitude:F2}");
    }
}
class BrickHouse : House
{
    public BrickHouse()
    {
        stages = 10;
    }

    public override void Build(double longitude, double latitude)
    {
        Console.WriteLine($"Построен кирпичный дом из {stages} этажей;" +
           $" координаты {longitude:F2}:{latitude:F2}");
    }
}
class HouseFactory
{
    Dictionary<string, House> houses = new Dictionary<string, House>();
    public HouseFactory()
    {
        houses.Add("Panel", new PanelHouse());
        houses.Add("Brick", new BrickHouse());
    }
    public House? GetHouse(string key)
    {
        if(houses.ContainsKey(key) )
        {
            return houses[key];
        }
        else
        {
            return null;
        }
    }
}