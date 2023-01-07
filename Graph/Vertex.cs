namespace Graph;

public class Vertex
{
    public int Weight { get; set; }
    public int Num { get; private set; }
    public bool Visited { get; set; }

    public Vertex(int num)
    {
        this.Num = num;
        this.Weight = 1;
    }
    
    public Vertex(int num, int weight)
    {
        this.Num = num;
        this.Weight = weight;
    }

    public override string ToString()
    {
        return Num.ToString();
    }
}