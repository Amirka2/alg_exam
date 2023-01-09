namespace ConsoleApp1;

public class QuickSort : Sort
{
    public QuickSort(int[] arr, string name) : base(arr, name)
    {
    }

    public override int[] Sorting()
    {
        time.Start();
        QuickSorting(0, _arr.Length - 1);
        time.Stop();
        TimeInMillis = time.ElapsedMilliseconds;

        return _arr;
    }

    private void QuickSorting(int left, int right)
    {
        var i = left;
        var j = right;
        var pivot = _arr[left];

        while (i <= j)
        {
            while (_arr[i] < pivot)
            {
                i++;
            }

            while (_arr[j] > pivot)
            {
                j--;
            }

            if (i <= j)
            {
                Swap(i, j);
                i++;
                j--;
            }
        }

        if (left < j)
        {
            QuickSorting(left, j);
        }

        if (i < right)
        {
            QuickSorting(i, right);
        }
    }
}