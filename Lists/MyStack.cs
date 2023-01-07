namespace Lists;

public class MyStack<T>
{
    private MyList<T> list;
    public MyStack()
    {
        list = new MyList<T>();
    }

    public void Push(T data)
    {
        list.Add(data);
    }

    public T Pop()
    {
        if (list.Count == 0) throw new InvalidOperationException("стек пуст!");
        
        var last = list.GetLast();
        list.Remove(last);
        
        return last;
    }

    public T Peek()
    {
        if (list.Count == 0) throw new InvalidOperationException("стек пуст!");

        var last = list.GetLast();

        return last;
    }
    public bool Contains(T data)
    {
        return list.Contains(data);
    }
}