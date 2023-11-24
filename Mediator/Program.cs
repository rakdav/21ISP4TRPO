abstract class Mediator
{
    public abstract void Send(string message,Collegue collegue);
}
abstract class Collegue
{
    protected Mediator mediator;

    protected Collegue(Mediator mediator)
    {
        this.mediator = mediator;
    }
}
class ConcreteCollegue1 : Collegue
{
    public ConcreteCollegue1(Mediator mediator) : base(mediator)
    {
    }
    public void Send(string message)
    {
        mediator.Send(message, this);
    }
    public void Notify(string message) { }
}
class ConcreteCollegue2 : Collegue
{
    public ConcreteCollegue2(Mediator mediator) : base(mediator)
    {
    }
    public void Send(string message)
    {
        mediator.Send(message,this);
    }
    public void Notify(string message) { }
}

class ConcreteMediator : Mediator
{
    public ConcreteCollegue1 concrete1 { get; set; }
    public ConcreteCollegue2 concrete2 { get; set; }

    public override void Send(string message, Collegue collegue)
    {
        if (concrete1 == collegue)
            concrete2.Notify(message);
        else
            concrete1.Notify(message);
    }
}
