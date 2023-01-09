using System.Collections;

namespace ConsoleApp1;

public class RadixSort : Sort
{
    public RadixSort(int[] arr, string name) : base(arr, name)
    {
    }

    public override int[] Sorting()
    {
        return RadixSorting(10, 2);
    }

    private int[] RadixSorting(int range, int length) // количество доступных символов, максимальная длина элемента 
    {
        ArrayList[] list = new ArrayList[range];
        for (int i = 0; i < range; i++)
        {
            list[i] = new ArrayList();
        }

        for (int step = 0; step < length; step++) //разряд
        {
            for (int i = 0; i < _arr.Length; i++) //распределение элементов массива
            {
                int temp = (_arr[i] % (int)Math.Pow(range, step + 1) / (int)Math.Pow(range, step)); //получение цифры в разряде

                list[temp].Add(_arr[i]); //добавление элемента в список по цифре разряда
            }

            int k = 0;
            for (int i = 0; i < range; i++) 
            {
                for (int j = 0; j < list[i].Count; ++j)
                {
                    _arr[k++] = (int)list[i][j]; //записываем элементы по порядку в массив
                }
            }

            for (int i = 0; i < range; i++)
            {
                list[i].Clear();
            }
        }

        return _arr;
    }
}