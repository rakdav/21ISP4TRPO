//Handler h1 = new ConcreteHandler1();
//Handler h2 = new ConcreteHandler2();
//h1.Successor = h2;
//h2.HandleRequest(2);
//abstract class Handler
//{
//    public Handler? Successor { get; set; }
//    public abstract void HandleRequest(int condition);
//}
//class ConcreteHandler1 : Handler
//{
//    public override void HandleRequest(int condition)
//    {
//        if (condition == 1)
//        {

//        }
//        else if(Successor!=null) 
//        {
//            Successor.HandleRequest(condition);
//        }
//    }
//}
//class ConcreteHandler2 : Handler
//{
//    public override void HandleRequest(int condition)
//    {
//        if (condition == 2)
//        {

//        }
//        else if (Successor != null)
//        {
//            Successor.HandleRequest(condition);
//        }
//    }
//}
Receiver reciever = new Receiver(false, false, true);
PaymentHandler bankPaymentHandler = new BankPaymentHandler();
PaymentHandler maneyPaymentHandler=new ManeyPaymentHandler();
PaymentHandler payPaymentHandler=new PayPaymentHandler();
bankPaymentHandler.Success= maneyPaymentHandler;
maneyPaymentHandler.Success=payPaymentHandler;
bankPaymentHandler.Handle(reciever);
class Receiver
{
    public bool BankTransfer { get; set; }
    public bool ManeyTransfer {  get; set; }
    public bool PayTransfer {  get; set; }
    public Receiver(bool b, bool m, bool p)
    {
        BankTransfer = b;
        ManeyTransfer = m;
        PayTransfer = p;
    }
}
abstract class PaymentHandler
{
    public PaymentHandler? Success { get; set; }
    public abstract void Handle(Receiver r);
}
class BankPaymentHandler : PaymentHandler
{
    public override void Handle(Receiver r)
    {
        if (r.BankTransfer==true)
        {
            Console.WriteLine("Выполняем банковский перевод");
        }
        else if (Success != null) Success.Handle(r);
    }
}
class ManeyPaymentHandler : PaymentHandler
{
    public override void Handle(Receiver r)
    {
        if (r.ManeyTransfer==true)
        {
            Console.WriteLine("Выполняем денежный перевод");
        }
        else if (Success != null) Success.Handle(r);
    }
}
class PayPaymentHandler : PaymentHandler
{
    public override void Handle(Receiver r)
    {
        if (r.PayTransfer==true)
        {
            Console.WriteLine("Выполняем перевод через PayPal");
        }
        else if (Success != null) Success.Handle(r);
    }
}



