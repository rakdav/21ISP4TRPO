Abstraction abstraction=new RefinedAbstraction(new ConctreteImplementorA());
abstraction.Operation();
abstraction.Implementor=new ConctreteImplementorB();
abstraction.Operation();
abstract class Abstraction
{
    protected Implementation implementor;
    public Implementation Implementor
    {
        set { implementor = value; }
    }
    public Abstraction(Implementation implementor)
    {
        this.implementor = implementor;
    }
    public virtual void Operation()
    {
        implementor.OperationImp();
    }
}
abstract class Implementation
{
    public abstract void OperationImp();
}
class RefinedAbstraction : Abstraction
{
    public RefinedAbstraction(Implementation implementor) : base(implementor)
    {
    }
    public override void Operation()
    {
    }
}
class ConctreteImplementorA : Implementation
{
    public override void OperationImp()
    {
    }
}
class ConctreteImplementorB : Implementation
{
    public override void OperationImp()
    {
    }
}
