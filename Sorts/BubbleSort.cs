namespace ConsoleApp1;

public class BubbleSort : Sort
{
    public BubbleSort(int[] arr, string name) : base(arr, name)
    {
    }

    public override int[] Sorting()
    {
        if (_arr == null) throw new Exception();
        
        time.Start();
        for (int i = 0; i < _arr.Length; i++)
        {
            for (int j = i; j < _arr.Length; j++)
            {
                if (_arr[i] < _arr[j])
                {
                    Swap(i, j);
                }
            }
        }
        time.Stop();
        TimeInMillis = time.ElapsedMilliseconds;
        
        return _arr;
    }
}