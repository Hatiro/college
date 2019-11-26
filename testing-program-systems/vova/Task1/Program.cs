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

namespace Task1
{
    internal static class Program
    {
        private static void Main()
        {
            Console.Write("Введите число a: ");
            double a;
            while (!double.TryParse(Console.ReadLine(), out a))
                Console.Write("Неверно, повторите ввод: ");

            var z1 = Math.Sin(Math.PI / 2d + 3d * a) / (1d - Math.Sin(3d * a - Math.PI));
            var z2 = 1d / Math.Tan(5d / 4d * Math.PI + 3d / 2d * Math.PI);
            
            Console.WriteLine("z1 = {0}", z1);
            Console.WriteLine("z2 = {0}", z2);
        }
    }
}