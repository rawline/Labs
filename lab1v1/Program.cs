using System;

namespace Task01;

public class Program
{
    public static void Main(string[] args)
    {

        Console.WriteLine("Часть 1:");
        Console.Write("Введите размер массива: ");

        int size = int.Parse(Console.ReadLine());

        var firstPart = new FirstPart(size);

        Console.WriteLine("Исходный массив: ");
        PrintVector((int[])firstPart.Vector);

        Console.WriteLine("Номер минимального по модулю элемента массива: " + firstPart.MinAbsElement());
        Console.WriteLine("Сумма модулей: " + firstPart.AbsSum());

        firstPart.ArrayZip(-5, 5);

        Console.WriteLine("Часть 2:");
        Console.Write("Введите размер прямоугольной матрицы: ");

        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());

        var secondPart = new SecondPart(rows, cols);

        Console.Write("Матрица в треугольном виде: ");
        secondPart.TriangleMatrix();

        Console.WriteLine("Количество строк, среднее арифметическое элементов которых меньше 5: " + secondPart.GetAmountOfRowsFewerThanValue(5));

    }
    public static void PrintVector(int[] ints)
    {
        Console.WriteLine(string.Join(", ", ints));
    }
}
