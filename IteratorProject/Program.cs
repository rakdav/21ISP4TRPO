//using System.Collections;

//abstract class Iterator
//{
//    public abstract object First();
//    public abstract object Next();
//    public abstract bool IsDone();
//    public abstract object Current();
//}
//class ConcreteIterator : Iterator
//{
//    private readonly Aggregate _aggregate;
//    public int _current;
//    public ConcreteIterator(Aggregate aggregate)
//    {
//        _aggregate = aggregate;
//    }
//    public override object Current()
//    {
//        return _aggregate[_current];
//    }
//    public override object First()
//    {
//        return _aggregate[0];
//    }
//    public override bool IsDone()
//    {
//        return _current>=_aggregate.Count;
//    }
//    public override object Next()
//    {
//        object? ret = null;
//        _current++;
//        if(_current<_aggregate.Count)
//        {
//            ret= _aggregate[_current];
//        }
//        return ret!;
//    }
//}
//abstract class Aggregate
//{
//    public abstract Iterator CreateIterator();
//    public abstract int Count { get; protected set; }
//    public abstract object this[int index] { get; set; }
//}
//class ConcreteAggregate : Aggregate
//{
//    private readonly ArrayList _item = new ArrayList();
//    public override object this[int index]
//    {
//        get { return _item[index]!; }
//        set { _item.Insert(index, value); }
//    }
//    public override int Count
//    {
//        get { return _item.Count; }
//        protected set { }
//    }
//    public override Iterator CreateIterator()
//    {
//        return new ConcreteIterator(this);
//    }
//}

//class Client
//{
//    public void Main()
//    {
//        Aggregate a=new ConcreteAggregate();
//        Iterator i = a.CreateIterator();
//        object item = i.Next();
//        while(!i.IsDone())
//        {
//            item = i.Next();
//        }
//    }
//}

Library library = new Library();
Reader reader= new Reader();
reader.SeeBook(library);

interface IBookIterator
{
    bool HasNext();
    Book Next();
}
interface IBookNumerable
{
    IBookIterator CreateNumerator();
    int Count { get; }
    Book this[int index] { get; }
}
class Book
{
    public string? Name { get; set; }
}
class Reader
{
    public void SeeBook(Library library)
    {
        IBookIterator iterator = library.CreateNumerator();
        while (iterator.HasNext())
        {
            Book book = iterator.Next();
            Console.WriteLine(book.Name);
        }
    }
}
class Library : IBookNumerable
{
    private Book[]? books;
    public Library()
    {
        books = new Book[]
        {
            new Book{Name="Яйлян любит морковь"},
            new Book{Name="Яйлян - снежный человек"}
        };
    }
    public Book this[int index]
    {
        get
        {
            return books![index];
        }
    }
    public int Count { get { return books!.Length; } }

    public IBookIterator CreateNumerator()
    {
        return new LibraryNumerator(this);
    }
}
class LibraryNumerator : IBookIterator
{
    IBookNumerable? aggregate;
    int index = 0;

    public LibraryNumerator(IBookNumerable? a)
    {
        this.aggregate = a;
    }

    public bool HasNext()
    {
        return index<aggregate!.Count;
    }

    public Book Next()
    {
        return aggregate![index++];
    }
}
