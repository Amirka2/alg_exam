
using System.Collections;
using System.Threading.Tasks.Dataflow;
using ConsoleApp1;

void Swap(int[] arr, int i, int j)
{
    var temp = arr[i];
    arr[i] = arr[j];
    arr[j] = temp;
}

int[] Bubblesort(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        for (int j = i; j < arr.Length; j++)
        {
            if (arr[i] > arr[j])
            {
                Swap(arr, i, j);
            }
        }
    }

    return arr;
}







int[] Insertsort(int[] arr)
{
    for (int i = 1; i < arr.Length; i++)
    {
        for (int j = i; j > 0 && arr[j] < arr[i - 1]; j--)
        {
            Swap(arr, j, j - 1);
        }
    }

    return arr;
}








int[] Selectsort(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        int min = i;
        for (int j = i; j < arr.Length; j++)
        {
            if (arr[j] < arr[min])
            {
                min = j;
            }
        }
        Swap(arr, i, min);
    }

    return arr;
}








int[] Cocktailsort(int[] arr)
{
    for (int i = 0; i < arr.Length / 2; i++)
    {
        bool swap = false;
        for (int j = i; j < arr.Length - 1 - i; j++)
        {
            if (arr[j] > arr[j + 1])
            {
                Swap(arr, j, j + 1);
                swap = true;
            }
        }

        for (int j = arr.Length - 1 - i; j > i; j--)
        {
            if (arr[j - 1] > arr[j])
            {
                Swap(arr, j, j - 1);
                swap = true;
            }
        }

        if (!swap)
        {
            foreach (var e in arr)
            {
                Console.WriteLine(e + " ");
            }
            return arr;
        }
    }

    return arr;
}






int[] Shellsort(int[] arr)
{
    int d = arr.Length / 2;
    while (d >= 1)
    {
        for (int i = d; i < arr.Length; i++)
        {
            for (int j = i; j >= d && arr[j - d] > arr[j]; j -= d)
            {
                Swap(arr, j - d, j);
            }
        }

        d /= 2;
    }

    return arr;
}







int[] Quicksort(int[] arr, int left, int right)
{
    int pivot = arr[right / 2];
    int i = left;
    int k = right;

    while (arr[i] < pivot)
    {
        i++;
    }

    while (arr[k] > pivot)
    {
        k--;
    }

    if (i <= k)
    {
        Swap(arr, i, k);
        i++;
        k--;
    }

    if (left < k)
    {
        Quicksort(arr, left, k);
    }

    if (i < right)
    {
        Quicksort(arr, i, right);
    }
    
    return arr;
}







int[] Radixsort(int[] arr, int range, int length)
{
    List<int>[] lists = new List<int>[range];
    for (int i = 0; i < range; i++)
    {
        lists[i] = new List<int>();
    }

    for (int step = 1; step <= length; step++)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            int temp = GetDigit(arr[i], step);
            lists[temp].Add(arr[i]);
        }

        int k = 0;
        for (int i = 0; i < range; i++)
        {
            for (int j = 0; j < lists[i].Count; j++)
            {
                arr[k++] = lists[i][j];
            }
        }

        for (int i = 0; i < range; i++)
        {
            lists[i].Clear();
        }
    }

    return arr;
}

int GetDigit(int num, int pos) 
{
    while (pos > 1)
    {
        num /= 10;
        pos--;
    }
    
    return num % 10;
}





int BinarySearch(int[] arr, int item)
{
    int left = 0, right = arr.Length - 1;
    int mid = arr.Length / 2;
    while (left <= right)
    {
        if (item < arr[mid])
        {
            right = mid - 1;
        }
        else if (item > arr[mid])
        {
            left = mid + 1;
        }
        else if (arr[mid] == item)
        {
            return mid;
        }
        mid = (left + right) / 2;
    }

    return -1;
}





int[] Treesort(int[] arr)
{
    var node = new TreeNode(arr[0]);
    for (int i = 1; i < arr.Length; i++)
    {
        node.Insert(new TreeNode(arr[i]));
    }

    return node.Transform();
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
            if (Left == null)
            {
                Left = node;
            }
            else
            {
                Left.Insert(node);
            }
        }
        else
        {
            if (Right == null)
            {
                Right = node;
            }
            else
            {
                Right.Insert(node);
            }
        }
    }

    public int[] Transform(List<int> elements = null)
    {
        if (elements == null)
        {
            elements = new List<int>();
        }

        if (Left != null)
        {
            Left.Transform(elements);
        }
        
        elements.Add(Data);

        if (Right != null)
        {
            Right.Transform(elements);
        }

        return elements.ToArray();
    }
}





