namespace Lists;

public class MyQueue<T>
{
    private MyList<T> list;
    public MyQueue()
    {
        list = new MyList<T>();
    }

    public void Enqueue(T data)
    {
        list.Add(data);
    }

    public T Dequeue()
    {
        if (list.Count == 0) throw new InvalidOperationException("очередь пуста!");
        
        var first = list.GetFirst();
        list.Remove(first);
        
        return first;
    }

    public T Peek()
    {
        if (list.Count == 0) throw new InvalidOperationException("очередь пуста!");
        
        var first = list.GetFirst();
        
        return first;
    }
    
    public bool Contains(T data)
    {
        return list.Contains(data);
    }
}