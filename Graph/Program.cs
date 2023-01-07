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
    g.AddVertex(i);
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
// g.GetOstKruscala();
// g.GetOstPrima();