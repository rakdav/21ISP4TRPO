//class Client
//{
//    void Main()
//    {
//        Context context= new Context();
//        var expression = new CompaundExpression();
//        expression.Interpret(context);
//    }
//}
//class Context{}
//abstract class AbstractExprtession
//{
//    public abstract void Interpret(Context context);
//}
//class TerminalException : AbstractExprtession
//{
//    public override void Interpret(Context context)
//    {

//    }
//}
//class CompaundExpression : AbstractExprtession
//{
//    AbstractExprtession? expression1;
//    AbstractExprtession? expression2;
//    public override void Interpret(Context context)
//    {

//    }
//}

//x+y-z
class Context
{
    Dictionary<string, int> variable;
    public Context()
    {
        this.variable = new Dictionary<string, int>();
    }
    public int GetVariable(string name)
    {
        return variable[name];
    }
    public void SetVariable(string name, int value)
    {
        if(variable.ContainsKey(name))
            variable[name] = value;
        else
            variable.Add(name, value);
    }
}
interface IExpression
{
    int Interpret(Context context);
}
class NumberExpression : IExpression
{
    string name;

    public NumberExpression(string name)
    {
        this.name = name;
    }

    public int Interpret(Context context)
    {
        return context.GetVariable(name);
    }
}
class AddExpression : IExpression
{
    IExpression leftExpression;
    IExpression rightExpression;
    public AddExpression(IExpression left, IExpression right)
    {
        this.leftExpression = left;
        this.rightExpression = right;
    }
    public int Interpret(Context context)
    {
        return leftExpression.Interpret(context)+
            rightExpression.Interpret(context);
    }
}
