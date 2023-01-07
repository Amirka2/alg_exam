namespace Lists;

public class Node<T>
{
    public Node<T> Next { get; set; }
    public Node<T> Prev { get; set; }
    public T Data { get; private set; }
    
    public Node(T data)
    {
        this.Data = data;
    }
}