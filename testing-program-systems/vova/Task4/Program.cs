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

namespace Task4
{
    internal static class Program
    {
        private static void Main()
        {
            int a, b;
            
            Console.Write("Input a: ");
            while (!int.TryParse(Console.ReadLine(), out a))
                Console.Write("Invalid input, please retry: ");
            
            Console.Write("Input b: ");
            while (!int.TryParse(Console.ReadLine(), out b) || b < a)
                Console.Write("Invalid input, please retry: ");

            for (var p = a; p <= b; p++)
            {
                if (p % 4 != 1)
                    continue;

                for (var m = 0; m < p; m++)
                    if ((m * m + 1) % p == 0)
                    {
                        Console.WriteLine($"{$"p = {p}",-8}{$"m = {m}",-8}({m} * {m} + 1) % {p} == 0");
                        goto Ok;
                    }

                Console.WriteLine("The hypothesis is incorrect.");
                break;

                Ok: ;
            }
        }
    }
}
