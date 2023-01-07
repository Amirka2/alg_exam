namespace ConsoleApp1;

public class InsertSort : Sort
{
    public int Swaps = 0;
    public InsertSort(int[] arr, string name) : base(arr, name)
    {
    }

    public override int[] Sorting()
    {
        if (_arr == null) throw new Exception();

        time.Start();
        for (int i = 1; i < _arr.Length; i++)
        {
            for (int j = i; j > 0 && _arr[j - 1] > _arr[j]; j--)
            {
                Swap(j, j - 1);
            }
        }
        time.Stop();
        TimeInMillis = time.ElapsedMilliseconds;
        
        return _arr;
    }
}