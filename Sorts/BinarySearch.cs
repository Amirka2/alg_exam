namespace ConsoleApp1;

public static class BinarySearch
{
    public static void Search(int[] arr, int num)
    {
        int left = 0, right = arr.Length - 1;
        int mid = right / 2;

        while (left <= right)
        {
            if (arr[mid] > num)
            {
                right = mid - 1;
            } else if (arr[mid] < num)
            {
                left = mid + 1;
            } else if (arr[mid] == num)
            {
                Console.WriteLine("Найдено");
                return;
            }
            mid = (left + right) / 2;
        }
        Console.WriteLine("Не найдено");
    }
}