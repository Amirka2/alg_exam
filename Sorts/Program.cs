
using ConsoleApp1;


int[] arr1 = { 2, 1, 0, 7, 8, 10, -10, 3, 5};
var s = new QuickSort(arr1, "q");
var arr = s.Sorting();
foreach (var el in arr)
{
    Console.Write(el + " ");
}
// int[] arr = { 2, 1, 0, 7, 8, 10, -10, 3, 5};
// var rnd = new Random();
// List<int> nums = new List<int>();
// for (int i = 0; i < 1000; i++)
// {
//     nums.Add(rnd.Next(-1000, 1000));
// }
//
// arr = nums.ToArray();
//
// List<Sort> sorts = new List<Sort>();
// sorts.Add(new BubbleSort(arr, "bubble"));
// sorts.Add(new ShakerSort(arr, "shaker"));
// sorts.Add(new InsertSort(arr, "insert"));
// sorts.Add(new SelectionSort(arr, "select"));
// sorts.Add(new ShellSort(arr, "shell"));
//
//
// foreach (var sort in sorts)
// {
//     sort.Sorting();
// }
//
// foreach (var sort in sorts)
// {
//     Console.WriteLine($"{sort.Name}: time = {sort.TimeInMillis} \tswaps = {sort.Swaps}");
// }
//
//


// foreach (var e in new ShellSort(arr, "shell").Sorting())
// {
//     Console.WriteLine(e);
// }


