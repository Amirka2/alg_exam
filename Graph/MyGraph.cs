namespace Graph;

public class MyGraph
{
    public List<Vertex> Vertexes { get; private set; }
    public List<Edge> Edges { get; private set; }

    public MyGraph()
    {
        Vertexes = new List<Vertex>();
        Edges = new List<Edge>();
    }

    public void AddVertex(int num, int weight = 1)
    {
        Vertex v = new Vertex(num, weight);
        Vertexes.Add(v);
    }

    public void AddEdge(Vertex from, Vertex to, int weight = 1)
    {
        Edge e = new Edge(from, to, weight);
        Edges.Add(e);
    }
    
    public void AddEdge(int from, int to, int weight = 1)
    {
        Vertex fromTemp = null, toTemp = null;
        for (int i = 0; i < Vertexes.Count; i++)
        {
            if (Vertexes[i].Num == from) fromTemp = Vertexes[i];
            if (Vertexes[i].Num == to) toTemp = Vertexes[i];
        }

        if (fromTemp != null && toTemp != null)
        {
            Edge e = new Edge(fromTemp, toTemp, weight);
            Edges.Add(e);
        }
        else
        {
            throw new InvalidDataException("Не найдено нужной вершины");
        }
    }

    public void GetOstPrima()
    {
        Edges.Sort();
        this.BFS();
        foreach (var v in Vertexes)
        {
            if (!v.Visited) Vertexes.Remove(v);
        }
        List<Vertex> connectedVer = new List<Vertex>();
        List<Edge> resEdges = new List<Edge>();
        
        connectedVer.Add(Vertexes[0]);
        foreach (var edge in Edges)
        {
            if (connectedVer.Contains(edge.From) && !connectedVer.Contains(edge.To)) 
            {
                resEdges.Add(edge);
                connectedVer.Add(edge.To);
            }
            else if (connectedVer.Contains(edge.To) && !connectedVer.Contains(edge.From))
            {
                resEdges.Add(edge);
                connectedVer.Add(edge.From);
            }
        }
        
        Console.Write("edges weight = ");
        foreach (var e in resEdges)
        {
            Console.Write(e + " + ");
        }
    }

    public void GetOstKruscala()
    {
        Edges.Sort();
        this.BFS();
        foreach (var v in Vertexes)
        {
            if (!v.Visited) Vertexes.Remove(v);
        }
        List<Vertex> connectedVer = new List<Vertex>();
        List<Edge> resEdges = new List<Edge>();

        foreach (var edge in Edges)
        {
            if (!connectedVer.Contains(edge.From) && !connectedVer.Contains(edge.To))
            {
                connectedVer.Add(edge.From);
                connectedVer.Add(edge.To);
                resEdges.Add(edge);
            }
            else if (connectedVer.Contains(edge.From))
            {
                if (!connectedVer.Contains(edge.To))
                {
                    resEdges.Add(edge);
                    connectedVer.Add(edge.To);
                }
                    
            }
            else if (connectedVer.Contains(edge.To))
            {
                if (!connectedVer.Contains(edge.From))
                {
                    resEdges.Add(edge);
                    connectedVer.Add(edge.From);
                }
            }
        }
        Console.Write("edges weight = ");
        foreach (var e in resEdges)
        {
            Console.Write(e + " + ");
        }
    }

    public void BFS()
    {
        Console.WriteLine();
        foreach (var v in Vertexes)
        {
            v.Visited = false;
        }
        
        Queue<Vertex> queue = new Queue<Vertex>();
        Random rnd = new Random();
        int n = rnd.Next(1, Vertexes.Count);

        queue.Enqueue(Vertexes[n]);//step 1

        while (queue.Count > 0)//step 2
        {
            Vertex ver = queue.Dequeue();
            ver.Visited = true;//помечаем опорную вершину посещенной
            Console.WriteLine(ver.Num + " is visited!");

            for (int i = 0; i < Edges.Count; i++)
            {
                if (Edges[i].From != ver && Edges[i].To != ver) continue;

                if (Edges[i].From == ver && !Edges[i].To.Visited && !queue.Contains(Edges[i].To))//находим все смежные с опорной вершины
                {
                    queue.Enqueue(Edges[i].To);//добавляем в очередь смежные вершины
                }
                if (Edges[i].To == ver && !Edges[i].From.Visited && !queue.Contains(Edges[i].From))//находим все смежные с опорной вершины
                {
                    queue.Enqueue(Edges[i].From);//добавляем в очередь смежные вершины
                }
            }
        }
    }

    public void DepthFirstSeacrh()
    {
        foreach (var v in Vertexes)
        {
            v.Visited = false;
        }
        
        Stack<Vertex> stack = new Stack<Vertex>();
        Random rnd = new Random();
        int n = rnd.Next(1, Vertexes.Count);
        stack.Push(Vertexes[n]);

        recSearch(stack);
    }
    private void recSearch(Stack<Vertex> s)
    {
        if (s.Count == 0) return;
        Vertex ver = s.Pop();
        ver.Visited = true;
        Console.WriteLine(ver.Num + " is visited!");

        for (int i = 0; i < Edges.Count; i++)
        {
            if (Edges[i].From != ver && Edges[i].To != ver) continue;

            if (Edges[i].From == ver && !Edges[i].To.Visited)//находим все смежные с опорной вершины
            {
                s.Push(Edges[i].To);
            }
            if (Edges[i].To == ver && !Edges[i].From.Visited)//находим все смежные с опорной вершины
            {
                s.Push(Edges[i].From);
            }
            recSearch(s);
        }
    }

    public void Dijkstra(int verNumber)
    {
        foreach (var v in Vertexes)
        {
            v.Weight = 10000;
        }
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