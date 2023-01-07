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
        foreach (var e in _arr)
        {
            Console.Write(e + ", ");
        }
        while (d >= 1)
        {
            Console.WriteLine($"d = {d}");
            for (int i = d; i < _arr.Length; i++)
            {
                int j = i;
                while ((j >= d) && (_arr[j - d] > _arr[j]))
                {
                    Console.Write($"поменяли местами: {_arr[j - d]} и {_arr[j]}. ");

                    Swap(j - d, j);
                    j -= d;
                    foreach (var e in _arr)
                    {
                        Console.Write(e + ", ");
                    }

                    Console.WriteLine();
                }
            }

            d /= 2;
        }
        time.Stop();
        TimeInMillis = time.ElapsedMilliseconds;
        
        return _arr;
    }
}