namespace ConsoleApp1;

public class ShellSort : Sort
{
    public ShellSort(int[] arr, string name) : base(arr, name)
    {
    }

    public override int[] Sorting()
    {
        time.Start();
        int d = _arr.Length / 2;
        while (d >= 1)
        {
            for (int i = d; i < _arr.Length; i++)
            {
                int k = i;
                while ((k >= d) && (_arr[k - d] > _arr[k]))
                {
                    Swap(k - d, k);
                    k -= d;
                }
            }

            d /= 2;
        }
        time.Stop();
        TimeInMillis = time.ElapsedMilliseconds;
        
        return _arr;
    }
}