namespace ConsoleApp1;

public class ShakerSort : Sort
{
    public ShakerSort(int[] arr, string name) : base(arr, name)
    {
    }

    public override int[] Sorting()
    {
        if (_arr == null) throw new Exception();
        
        time.Start();

        for (int i = 0; i < _arr.Length / 2; i++)
        {
            var swapFlag = false;
            for (int j = i; j < _arr.Length / 2; j++)
            {
                if (_arr[j] > _arr[j + 1])
                {
                    Swap(j, j + 1);
                    swapFlag = true;
                }
                
            }

            for (int j = _arr.Length - 2 - i; j > i; j--)
            {
                if (_arr[j - 1] > _arr[j])
                {
                    Swap(j - 1, j);
                    swapFlag = true;
                }
            }

            if (!swapFlag)
            {
                break;
            }
        }
        
        time.Stop();
        TimeInMillis = time.ElapsedMilliseconds;

        return _arr;
    }
}