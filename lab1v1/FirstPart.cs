using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01;

public class FirstPart
{
    private readonly int[] array;
    private const int rangeOfValues = 10;
    private List<int> list;

    public FirstPart(int length)
    {
        if (length <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(length));
        }

        var random = new Random();

        array = new int[length];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(-rangeOfValues, rangeOfValues);
        }

        list = array.ToList();
    }

    public FirstPart(int[] arr)
    {
        array = arr;
        list = arr.ToList();
    }

    public IReadOnlyList<int> Vector
    {
        get
        {
            return array;
        }
    }

    public IReadOnlyList<int> List
    {
        get
        {
            return list;
        }
    }

    // поиск минимального элемента массива
    public int MinAbsElement()
    {
        int length = array.Length;
        int min = rangeOfValues;

        for (int i = 0; i < length; i++)
        {
            if (min > Math.Abs(array[i]))
            {
                min = Math.Abs(array[i]);
            }
        }

        return min;
    }

    // поиск суммы модулей элементов массива, расположенных после первого отрицательного элемента
    public int AbsSum()
    {
        int totalSum = 0;
        int length = array.Length;

        for (int i = 0; i < length; i++)
        {
            if (array[i] < 0)
            {
                for (int j = i + 1; j < length; j++)
                    totalSum += Math.Abs(array[j]);
                break;
            }
        }

        return totalSum;
    }

    public void ArrayZip(int a, int b)
    {
        if (a > b)
        {
            Console.WriteLine("Введен неправильный диапозон");
            Environment.Exit(0);
        }

        int length = list.Count;

        // вывод в консоль коллекции до изменений
        Console.WriteLine("Массив до изменений");

        for (int i = 0; i < length; i++)
            Console.Write(list[i] + ", ");

        Console.WriteLine();

        // удаление элементов в необходимом диапозоне
        list.RemoveAll(x => x >= a && x <= b);
        list.AddRange(Enumerable.Repeat(0, array.Length - list.Count));

        // вывод в консоль коллекции после изменений
        Console.WriteLine("Массив после изменений");

        for (int i = 0; i < length; i++)
            Console.Write(list[i] + ", ");

        Console.WriteLine();
    }
}
