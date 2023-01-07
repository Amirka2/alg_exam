// See https://aka.ms/new-console-template for more information

using Lists;

Console.WriteLine("Hello, World!");

MyQueue<int> l = new MyQueue<int>();
l.Enqueue(1);
l.Enqueue(2);
l.Enqueue(3);

l.Contains(1);
l.Contains(3);

for (int i = 0; i < 4; i++)
{
    Console.WriteLine(l.Dequeue());
}

l.Contains(1);
l.Contains(3);

