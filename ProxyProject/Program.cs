class Class
{
    void Main()
    {
        Subject subject=new Proxy();
        subject.Dolt();
    }
}
abstract class Subject
{
    public abstract void Dolt();
}
class RealSubject : Subject
{
    public override void Dolt()
    {
       
    }
}
class Proxy : Subject
{
    RealSubject? realSubject;
    public override void Dolt()
    {
        if(realSubject == null)
        {
            realSubject = new RealSubject();
        }
        realSubject.Dolt();
    }
}
