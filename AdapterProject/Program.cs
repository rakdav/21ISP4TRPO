//class Client
//{
//    public void Request(Target target)
//    {
//        target.Request();
//    }
//}
////объекты, которые используются клиентом
//class Target
//{
//    public virtual void Request() { }
//}
////класс, к котрому надо адаптировать другой класс
//class Adapter:Target
//{
//    private Adaptee adapter=new Adaptee();

//    public override void Request()
//    {
//        adapter.SpecificRequest();
//    }
//}
////адаптируемый класс
//class Adaptee
//{
//    public void SpecificRequest() { }
//}
Driver driver = new Driver();
Auto auto = new Auto();
driver.Travel(auto);
Camel camel = new Camel();
ITransport camelTransport = new CamelToTransportAdapter(camel);
driver.Travel(camelTransport);

interface ITransport
{
    void Drive();
}
class Auto : ITransport
{
    public void Drive()
    {
        Console.WriteLine("Управляю машиной");
    }
}
class Driver
{
    public void Travel(ITransport transport)
    {
        transport.Drive();
    }
}
interface IAnimal
{
    void Move();
}
class Camel : IAnimal
{
    public void Move()
    {
        Console.WriteLine("Еду на вербдлюде");
    }
}

class CamelToTransportAdapter : ITransport
{
    Camel camel;

    public CamelToTransportAdapter(Camel camel)
    {
        this.camel = camel;
    }

    public void Drive()
    {
        camel.Move();
    }
}

