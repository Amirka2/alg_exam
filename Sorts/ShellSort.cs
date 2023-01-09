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
                int j = i;
                while ((j >= d) && (_arr[j - d] > _arr[j]))
                {
                    Swap(j - d, j);
                    j -= d;
                }
            }

            d /= 2;
        }
        time.Stop();
        TimeInMillis = time.ElapsedMilliseconds;
        
        return _arr;
    }
}