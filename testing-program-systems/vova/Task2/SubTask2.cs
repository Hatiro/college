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
using System.Linq;
using System.Text;

namespace Task2
{
    internal static class SubTask2
    {
        internal static void Run()
        {
            var text = File.ReadAllText(Program.FilePath, Encoding.UTF8);
            var nums = text.Split(' ').Select(int.Parse).Select(Math.Abs).ToArray();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(text);
            Console.ResetColor();

            var minAbsolute = nums.Min();
            Console.Write("Minimal absolute value is ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(minAbsolute);
            Console.ResetColor();

            var sumOfAfterZeroItems = nums.SkipWhile(n => n != 0).Sum();
            Console.Write("Sum of items after first zero is ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(sumOfAfterZeroItems);
            Console.ResetColor();
        }
    }
}
