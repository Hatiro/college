//    Copyright(C) 2019  Vova Lantsov

//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.

//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//    GNU General Public License for more details.

//    You should have received a copy of the GNU General Public License
//    along with this program.If not, see https://www.gnu.org/licenses/.

using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Task3
{
    internal static class SubTask2
    {
        internal static void Run(int dim0, int dim1)
        {
            int sumOfModulesOfItemsAboveMainDiagonal = 0, countOfLocalMins = 0;
            Span<int> previousLine = stackalloc int[dim1];

            using (var arrayReader = new StreamReader(Program.PathToFile, Encoding.UTF8))
            {
                string line = arrayReader.ReadLine();
                for (int i = 0; line != null; line = arrayReader.ReadLine(), Console.WriteLine(), i++)
                {
                    int[] separated = line.Split(' ').Select(int.Parse).ToArray();

                    for (int j = 0; j < dim1; j++)
                    {
                        var current = separated[j];

                        Console.Write("{0,5}", current);

                        if (i > 0 && mas[i - 1, j] >= current ||
                            i < dim0 - 1 && mas[i + 1, j] >= current ||
                            j > 0 && mas[i, j - 1] >= current ||
                            j < dim1 - 1 && mas[i, j + 1] >= current)
                            continue;

                        countOfLocalMins++;

                        Console.Write("{0,5}", mas[i, j] = separated[j]);
                    }
                }
            }

            CountLocalMins(mas);
            SumOfModulesOfItemsAboveMainDiagonal(mas);
        }

        private static void CountLocalMins(int[,] mas)
        {
            int count = 0, dim1 = mas.GetLength(0), dim2 = mas.GetLength(1);

            for (int i = 0; i < dim1; i++)
            {
                for (int j = 0; j < dim2; i++)
                {
                    var current = mas[i, j];

                    if (i > 0 && mas[i - 1, j] >= current ||
                        i < dim1 - 1 && mas[i + 1, j] >= current ||
                        j > 0 && mas[i, j - 1] >= current ||
                        j < dim2 - 1 && mas[i, j + 1] >= current)
                        continue;

                    count++;
                }
            }

            Console.WriteLine($"Count of local mins: {count}");
        }

        private static void SumOfModulesOfItemsAboveMainDiagonal(int[,] mas)
        {

        }
    }
}