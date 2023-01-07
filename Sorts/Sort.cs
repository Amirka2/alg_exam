using System.Diagnostics;

namespace ConsoleApp1;

public abstract class Sort
{
    public int Swaps = 0;
    protected int[] _arr;
    public long TimeInMillis;
    protected Stopwatch time = new Stopwatch();
    public string Name;

    public Sort(int[] arr, string name)
    {
        Name = name;
        _arr = new int[arr.Length];
        Array.Copy(arr, _arr, arr.Length);
    }

    protected void Swap(int i, int j)
    {
        int temp = _arr[i];
        _arr[i] = _arr[j];
        _arr[j] = temp;
        Swaps++;
    }

    public abstract int[] Sorting();
}