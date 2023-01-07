namespace ConsoleApp1;

public class SelectionSort : Sort
{
    public SelectionSort(int[] arr, string name) : base(arr, name)
    {
    }

    public override int[] Sorting()
    {
        if (_arr == null) throw new Exception();
        
        time.Start();
        for (int i = _arr.Length - 1; i > 0; i--)
        {
            int max = 0;
            for (int j = i; j > 0; j--)
            {
                if (_arr[max] < _arr[j]) max = j;
            }
            Swap(max, i);
        }
        time.Stop();
        TimeInMillis = time.ElapsedMilliseconds;

        return _arr;
    }
}