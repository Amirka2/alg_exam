namespace ConsoleApp1;

public class TreeSort : Sort
{
    public TreeSort(int[] arr, string name) : base(arr, name)
    {
    }

    public override int[] Sorting()
    {
        time.Start();
        var node = new TreeNode(_arr[0]);
        for (int i = 1; i < _arr.Length; i++)
        {
            node.Insert(new TreeNode(_arr[i]));
        }

        time.Stop();
        TimeInMillis = time.ElapsedMilliseconds;
        return node.Transform();
    }
}

public class TreeNode
{
    public int Data { get; private set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }

    public TreeNode(int data)
    {
        Data = data;
    }

    public void Insert(TreeNode node)
    {
        if (node.Data < this.Data)
        {
            if (this.Left == null)
            {
                this.Left = node;
            }
            else
            {
                Left.Insert(node);
            }
        }
        else
        {
            if (this.Right == null)
            {
                this.Right = node;
            }
            else
            {
                this.Right.Insert(node);
            }
        }
    }

    public int[] Transform(List<int> elements = null)
    {
        if (elements == null)
        {
            elements = new List<int>();
        }
        if (this.Left != null)
        {
            this.Left.Transform(elements);
        }
        elements.Add(this.Data);

        if (this.Right != null)
        {
            this.Right.Transform(elements);
        }

        return elements.ToArray();
    }
}