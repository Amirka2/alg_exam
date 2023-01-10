// See https://aka.ms/new-console-template for more information
using Graph;


var g = new MyGraph();
// g.AddVertex(1);
// g.AddVertex(2);
// g.AddVertex(3);
// g.AddVertex(4);
// g.AddEdge(1, 2, 10);
// g.AddEdge(1, 3, 3);
// g.AddEdge(2, 1, 2);
// g.AddEdge(2, 3, 5);
// g.AddEdge(3, 1, 45);
// g.AddEdge(4, 2, 2);

for (int i = 1; i < 6; i++)
{
    g.AddVertex();
}
g.AddEdge(1, 2, 10);
g.AddEdge(1, 3, 30);
g.AddEdge(1, 4, 50);
g.AddEdge(1, 5, 10);
g.AddEdge(3, 5, 10);
g.AddEdge(4, 2, 40);
g.AddEdge(4, 3, 20);
g.AddEdge(5, 1, 10);
g.AddEdge(5, 3, 10);
g.AddEdge(5, 4, 30);

g.Dijkstra(1);

// g.DepthFirstSeacrh();
// g.BFS();
//g.GetOstKruscal();
//g.GetOstPrima();

public class Vertex
{
    public int Num { get; set; }
    public int Weight { get; set; }
    public bool Visited { get; set; }
    public List<Edge> Connected { get; set; }

    public Vertex(int num, int weight = 1)
    {
        Num = num;
        Weight = weight;
        Connected = new List<Edge>();
    }

    public override string ToString()
    {
        return Num.ToString() + ", " + Weight.ToString();
    }
}

public class Edge : IComparable
{
    public Vertex From { get; private set; }
    public Vertex To { get; private set; }
    public int Weight { get; private set; }

    public Edge()
    {
        
    }
    public Edge(Vertex from, Vertex to, int weight = 1)
    {
        From = from;
        To = to;
        Weight = weight;
    }

    public override string ToString()
    {
        return $"{From} -> {To}. Weight = {Weight}";
    }

    public int CompareTo(object? obj)
    {
        if (obj == null) throw new NullReferenceException();
        Edge item = (Edge)obj;
        
        return this.Weight - item.Weight;
    }
}

public class MyGraph
{
    public List<Vertex> Vertexes { get; private set; }
    public List<Edge> Edges { get; private set; }
    private int _vertexesCount = 0;

    public MyGraph()
    {
        Vertexes = new List<Vertex>();
        Edges = new List<Edge>();
    }
    public void AddVertex(int weight = 1)
    {
        Vertexes.Add(new Vertex(++_vertexesCount, weight));
    }

    public void AddEdge(int vertexFromNum, int vertexToNum, int weight = 1)
    {
        var from = FindVertex(vertexFromNum);
        var to = FindVertex(vertexToNum);
        var e = new Edge(from, to, weight);
        Edges.Add(e);
        from.Connected.Add(e);
        to.Connected.Add(e);
    }

    private Vertex FindVertex(int num)
    {
        foreach (var v in Vertexes)
        {
            if (v.Num == num) return v;
        }
        return new Vertex(num);
    }

    public void DFS()
    {
        Vertex ver = Vertexes[0];
        Stack<Vertex> s = new Stack<Vertex>();
        s.Push(ver);

        RecSearch(s);
    }

    private void RecSearch(Stack<Vertex> s)
    {
        if (s.Count == 0) return;
        
        var ver = s.Pop();
        ver.Visited = true;

        for (int i = 0; i < Edges.Count; i++)
        {
            if (Edges[i].To != ver && Edges[i].From != ver) 
                continue;
                
            if (Edges[i].From == ver && !Edges[i].To.Visited)
            {
                s.Push(Edges[i].To);
            }
            if (Edges[i].To == ver && !Edges[i].From.Visited)
            {
                s.Push(Edges[i].From);
            }
        }
        RecSearch(s);
    }

    public void BFS()
    {
        Queue<Vertex> q = new Queue<Vertex>();
        q.Enqueue(Vertexes[0]);

        while (q.Count > 0)
        {
            var ver = q.Dequeue();
            ver.Visited = true;

            for (int i = 0; i < Edges.Count; i++)
            {
                if (Edges[i].From != ver && Edges[i].To != ver) continue;

                if (Edges[i].From == ver && !Edges[i].To.Visited && !q.Contains(Edges[i].To))
                {
                    q.Enqueue(Edges[i].To);
                }
                if (Edges[i].To == ver && !Edges[i].From.Visited && !q.Contains(Edges[i].From))
                {
                    q.Enqueue(Edges[i].From);
                }
            }
        }
    }

    public int GetOstKruscal() // переделать под новую логику
    {
        Edges.Sort();
        List<Vertex> connectedV = new List<Vertex>();
        int sum = 0;

        for (int i = 0; i < Edges.Count; i++)
        {
            if (!connectedV.Contains(Edges[i].From) && !connectedV.Contains(Edges[i].To))
            {
                connectedV.Add(Edges[i].To);
                connectedV.Add(Edges[i].From);
                sum += Edges[i].Weight;
                Console.WriteLine($"выбрали ребро {Edges[i]}");
            }
            if (connectedV.Contains(Edges[i].From) && !connectedV.Contains(Edges[i].To))
            {
                connectedV.Add(Edges[i].To);
                sum += Edges[i].Weight;
                Console.WriteLine($"выбрали ребро {Edges[i]}");
            }
            else if (connectedV.Contains(Edges[i].To) && !connectedV.Contains(Edges[i].From))
            {
                connectedV.Add(Edges[i].From);
                sum += Edges[i].Weight;
                Console.WriteLine($"выбрали ребро {Edges[i]}");
            }
        }

        Console.WriteLine("sum = " + sum);
        return sum;
    }

    public int GetOstPrima()
    {
        Edges.Sort();
        List<Vertex> connectedV = new List<Vertex>();
        List<Edge> currentEdges = new List<Edge>();
        int sum = 0;

        connectedV.Add(Vertexes[0]);
        Console.WriteLine($"первая вершина = {Vertexes[0]}");

        while (connectedV.Count < Vertexes.Count)
        {
            foreach (var v in connectedV) 
            {
                foreach (var e in v.Connected)
                {
                    if (!currentEdges.Contains(e))
                    {
                        currentEdges.Add(e); //добавляем все ребра доступные для добавленных вершин
                    }
                }
            }
            currentEdges.Sort();
            
            List<Edge> reduntantEdges = new List<Edge>();
            foreach (var e in currentEdges)
            {
                if (connectedV.Contains(e.To) && connectedV.Contains(e.From))
                {
                    reduntantEdges.Add(e); 
                }
            }

            foreach (var e in reduntantEdges)
            {
                currentEdges.Remove(e); //удаляем ребра соединяющие добавленные вершины
            }

            var chosenEdge = currentEdges[0];
            if (connectedV.Contains(chosenEdge.To))
            {
                connectedV.Add(chosenEdge.From);
                currentEdges.Remove(chosenEdge);
                Console.WriteLine($"выбрали ребро {chosenEdge}, добавили вершину: {chosenEdge.From}");
            }
            else if (connectedV.Contains(chosenEdge.From))
            {
                connectedV.Add(chosenEdge.To);
                currentEdges.Remove(chosenEdge);
                Console.WriteLine($"выбрали ребро {chosenEdge}, добавили вершину: {chosenEdge.To}");
            }
            sum += chosenEdge.Weight;
        }

        Console.WriteLine($"sum = {sum}");
        return sum;
    }

    public void Dijkstra(int verNumber)
    {
        foreach (var v in Vertexes)
        {
            v.Weight = 10000;
        }
        Edges.Sort();
        Queue<Vertex> q = new Queue<Vertex>();
        var ver = Vertexes[verNumber - 1];
        ver.Weight = 0;

        while (true)
        {
            bool flag = false;
            foreach (var v in Vertexes)
            {
                if (!v.Visited) flag = true;
            }
            if (!flag) break;

            foreach (var edge in Edges)
            {
                if (edge.From == ver)
                {
                    q.Enqueue(edge.To);
                    if (edge.To.Weight > edge.Weight + edge.From.Weight)
                    {
                        edge.To.Weight = edge.Weight + edge.From.Weight;
                    }
                }
            }

            ver = q.Dequeue();
            ver.Visited = true;
        }

        foreach (var v in Vertexes)
        {
            Console.Write($"v{v.Num}: {v.Weight}\n");
        }
    }
}









