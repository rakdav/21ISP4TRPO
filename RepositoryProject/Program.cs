//interface IObservable
//{
//    void AddObserver(IObserver o);
//    void RemoveObserver(IObserver o);
//    void NotifyObserver();
//}
//class ConcreteObservable:IObservable
//{
//    private List<IObserver> observes;
//    public ConcreteObservable()
//    {
//        observes = new List<IObserver>();
//    }
//    public void AddObserver(IObserver o)
//    {
//        observes.Add(o);
//    }
//    public void NotifyObserver()
//    {
//        foreach (IObserver i in observes) {
//            i.Update();
//        }
//    }
//    public void RemoveObserver(IObserver o)
//    {
//        throw new NotImplementedException();
//    }
//}
//interface IObserver
//{
//    void Update();
//}
//class ConctreteObserver : IObserver
//{
//    public void Update()
//    {
//        throw new NotImplementedException();
//    }
//}

Stock stock=new Stock();
Bank bank = new Bank("Машкин банк", stock);
Broker broker=new Broker("Кабанова Маша",stock);
stock.Market();
broker.StopTrade();
stock.Market();

interface IObserver
{
    void Update(Object o);
}
interface IObservable
{
    void RegisterOdserver(IObserver o);
    void DeleteObserver(IObserver o);
    void NotifyObservers();
}
class Stock:IObservable
{
    StockInfo? sInfo;
    List<IObserver> observers;
    public Stock()
    {
        observers = new List<IObserver>();
        sInfo = new StockInfo();
    }
    public void DeleteObserver(IObserver o)
    {
        observers.Remove(o);    
    }
    public void NotifyObservers()
    {
        foreach(IObserver o in observers)
        {
            o.Update(sInfo!);
        }
    }
    public void RegisterOdserver(IObserver o)
    {
        observers.Add(o);
    }
    public void Market()
    {
        Random rnd = new Random();
        sInfo!.USD = rnd.Next(80, 120);
        sInfo!.Euro = rnd.Next(90, 150);
        NotifyObservers();
    }
}
class Broker : IObserver
{
    public string? Name { get; set; }
    IObservable? stock;

    public Broker(string? name, IObservable? stock)
    {
        Name = name;
        this.stock = stock;
        this.stock?.RegisterOdserver(this);
    }

    public void Update(object o)
    {
        StockInfo sInfo = (StockInfo)o;
        if (sInfo.USD > 100)
            Console.WriteLine($"Брокер {this.Name} начинает продавать доллары по курсу {sInfo.USD}");
        else 
            Console.WriteLine($"Брокер {this.Name} начинает покупать доллары по курсу {sInfo.USD}");
    }
    public void StopTrade()
    {
        stock?.RegisterOdserver(this);
        stock = null;
    }
}
class Bank : IObserver
{
    public string? Name { get; set; }
    IObservable? stock;
    public Bank(string? name, IObservable? stock)
    {
        Name = name;
        this.stock = stock;
        stock?.RegisterOdserver(this);
    }
    public void Update(object o)
    {
        StockInfo? sInfo=(StockInfo?)o;
        if (sInfo.USD > 100)
            Console.WriteLine($"Банк {this.Name} начинает продавать доллары по курсу {sInfo.USD}");
        else
            Console.WriteLine($"Банк {this.Name} начинает покупать доллары по курсу {sInfo.USD}");
    }
}
class StockInfo
{
    public int USD { get; set; }
    public int Euro { get; set; }
}