//    Copyright(C) 2019  Vova Lantsov

//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.

//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//    GNU General Public License for more details.

//    You should have received a copy of the GNU General Public License
//    along with this program. If not, see https://www.gnu.org/licenses/.

using System;
using System.IO;
using System.Text;

namespace Task2
{
    internal static class SubTask1
    {
        private static readonly Random _random = new Random();

        internal static void Run()
        {
            Span<int> arr = stackalloc int[50];

            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = _random.Next(-10, 11);
                Console.Write(arr[i]);

                if (i < arr.Length - 1)
                    Console.Write(' ');
                else
                    Console.WriteLine();
            }
            Console.ResetColor();

            Console.Write("Input number n: ");
            int n;
            Console.ForegroundColor = ConsoleColor.Blue;
            while (!int.TryParse(Console.ReadLine(), out n)
                || n < 10 || n > 50)
            {
                Console.ResetColor();
                Console.Write("Invalid input, repeat: ");
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            Console.ResetColor();

            using (var fileWriter = new StreamWriter(Program.FilePath, false, Encoding.UTF8))
            {
                for (int i = 0; i < n; i++)
                {
                    fileWriter.Write(arr[i]);

                    if (i < n - 1)
                        fileWriter.Write(' ');
                }
            }
        }
    }
}
