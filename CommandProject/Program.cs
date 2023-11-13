abstract class Command
{
    public abstract void Execute();
    public abstract void Undo();
}
class ConcreteCommand : Command
{
    Receiver receiver;
    public ConcreteCommand(Receiver receiver)
    {
        this.receiver = receiver;
    }
    public override void Execute()
    {
        receiver.Operation();
    }
    public override void Undo()
    {
        throw new NotImplementedException();
    }
}
class Receiver
{
    public void Operation() { }
}
class Invoker
{
    Command command;
    public void SetCommand(Command c) 
    {
        command = c;
    }
    public void Run() 
    {
        command.Execute();
    }
    public void Cancel() 
    {
        command.Undo();
    }
}
class Client
{
    void Main()
    {
        Invoker invoker=new Invoker();
        Receiver receiver=new Receiver();
        ConcreteCommand concreteCommand = new ConcreteCommand(receiver);
        invoker.SetCommand(concreteCommand);
        invoker.Run();
    }
}