using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01;
    public class SecondPart
    {
        private readonly double[,] matrix;
        private int rows, cols;

        public SecondPart(int rows, int cols)
        {
            if (rows < 0 || cols < 0 || rows >= cols)
            {
                throw new ArgumentOutOfRangeException(nameof(rows) + " или " + nameof(cols));
            }

            this.rows = rows;
            this.cols = cols;

            matrix = new double[rows, cols];

            var random = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(-10, 10);
                }
            }
        }

        public SecondPart(double[,] matrix, int rows, int cols)
        {
            this.matrix = matrix;
            this.rows = rows;
            this.cols = cols;
        }

        public double[,] Matrix
        {
            get
            {
                return matrix;
            }
        }

        public void TriangleMatrix()
        {
            for (int i = 0; i < rows; i++)
            {
                // Поиск главного элемента в текущем столбце
                int maxRow = i;
                for (int j = i + 1; j < rows; j++)
                {
                    if (Math.Abs(matrix[j, i]) > Math.Abs(matrix[maxRow, i]))
                    {
                        maxRow = j;
                    }
                }

                // Обмен строк, чтобы главный элемент был на i-й позиции
                if (maxRow != i)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        double temp = matrix[i, j];
                        matrix[i, j] = matrix[maxRow, j];
                        matrix[maxRow, j] = temp;
                    }
                }

                // Обнуление элементов под главным элементом
                for (int j = i + 1; j < rows; j++)
                {
                    double factor = matrix[j, i] / matrix[i, i];

                    for (int k = i; k < cols; k++)
                    {
                        matrix[j, k] -= factor * matrix[i, k];

                        matrix[j, k] = Math.Round(matrix[j, k], 1);
                    }
                }
            }

            // Выводим результат
            Console.WriteLine("Матрица в треугольном виде:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public int GetAmountOfRowsFewerThanValue(int a)
        {
            int targetValue = a;
            int rowCount = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                double rowAverage = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    rowAverage += matrix[i, j];
                }
                rowAverage /= matrix.GetLength(1);

                if (rowAverage < targetValue)
                {
                    rowCount++;
                }
            }

            return rowCount;
        }
    }
