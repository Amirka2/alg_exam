namespace Graph;

public class Edge : IComparable
{
    public int Weight { get; private set; }
    public Vertex To { get; private set; }
    public Vertex From { get; private set; }

    public Edge(Vertex from, Vertex to)
    {
        this.From = from;
        this.To = to;
        this.Weight = 1;
    }
    
    public Edge(Vertex from, Vertex to, int weight)
    {
        this.From = from;
        this.To = to;
        this.Weight = weight;
    }

    public int CompareTo(object? obj)
    {
        if (obj == null) throw new NullReferenceException();
        
        Edge e = (Edge)obj;

        return this.Weight - e.Weight;
    }

    public override string ToString()
    {
        return Weight.ToString();
    }
}