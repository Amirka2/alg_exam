namespace Lists;

public class MyList<T>
{
    public Node<T> Head;
    public Node<T> Tail;
    public int Count { get; private set; }
    
    public MyList()
    {
    }

    public void Add(T data)
    {
        Node<T> item = new Node<T>(data);

        if (Head == null)
        {
            Head = item;
            Tail = item;
        }
        else if (Head == Tail)
        {
            Head.Next = item;
            item.Prev = Head;
            Tail = item;
        }
        else
        {
            item.Prev = Tail;
            Tail.Next = item;
            Tail = item;
        }

        Count++;
    }

    public bool Remove(T data)
    {
        var current = Head;
        while (current != null)
        {
            if (current.Data.Equals(data))
            {
                if (current == Head && current != Tail)
                {
                    Head = Head.Next;
                    Head.Prev = null;
                    return true;
                }
                else if (current == Head && current == Tail)
                {
                    Head = null;
                    Tail = null;
                    return true;
                }
                else if (current == Tail)
                {
                    Tail = Tail.Prev;
                    Tail.Next = null;
                    return true;
                }
                else
                {
                    current.Prev.Next = current.Next;
                    current.Next.Prev = current.Prev;
                    return true;
                }

                Count--;
            }
            
            current = current.Next;
        }

        return false;
    }

    public bool Contains(T data)
    {
        var current = Head;

        while (current != null)
        {
            if (current.Data.Equals(data))
            {
                return true;
            }
            
            current = current.Next;
        }

        return false;
    }

    public T GetLast()
    {
        var current = Head;
        T data = current.Data;
        while (current != null)
        {
            data = current.Data;
            current = current.Next;
        }

        return data;
    }

    public T GetFirst()
    {
        return Head.Data;
    }
}