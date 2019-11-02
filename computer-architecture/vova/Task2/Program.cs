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
using System.Linq;
using System.Text;

namespace Task2
{
    internal static class Program
    {
        private static void Main()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.InputEncoding = Console.OutputEncoding = Encoding.GetEncoding(1251);
            
            Console.Write("Введите значение байта: ");
            var b = !long.TryParse(Console.ReadLine(), out var byteValue) || byteValue < 0L
                ? (byte) 100
                : byteValue > 255
                    ? (byte) (byteValue % 256L)
                    : (byte) byteValue;
            Console.WriteLine();
            
            Console.WriteLine("Введённый байт в");
            Console.WriteLine("десятичном представлении — {0}", b);
            var bitStr = Convert.ToString(b, 2).PadLeft(8, '0');
            var strWithout7n8 = bitStr.Substring(0, 6);
            var str7n8 = bitStr.Substring(6);
            Console.Write("двоичном представлении — {0}", strWithout7n8);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(str7n8);
            Console.ResetColor();
            Console.WriteLine();

            var rightShifted = new string(strWithout7n8.Select((c, i) => new {c, i})
                .OrderByDescending(it => it.i == 5).Select(it => it.c).ToArray());
            var rightShiftedNum = Convert.ToInt32(rightShifted + str7n8, 2);
            Console.WriteLine("Циклический сдвиг вправо в");
            Console.WriteLine("десятичном представлении — {0}", rightShiftedNum);
            Console.Write("двоичном представлении — {0}", rightShifted);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(str7n8);
            Console.ResetColor();
            Console.WriteLine();

            var added = rightShiftedNum + 200;
            var bytes = BitConverter.GetBytes(added);
            Console.WriteLine("Результат сложения с числом 200 в");
            Console.WriteLine("десятичном представлении — {0}", added);
            Console.WriteLine("двоичном представлении — {0}", string.Join(' ',
                bytes.Where(it => it != 0).Select(it => Convert.ToString(it, 2)
                    .PadLeft(8, '0'))));
        }
    }
}