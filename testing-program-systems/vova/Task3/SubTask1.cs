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

namespace Task3
{
    internal static class SubTask1
    {
        private static readonly Random Random = new Random();

        internal static void Run(int length)
        {
            Console.WriteLine("Array");

            using (var arrayWriter = new StreamWriter(Program.PathToFile, false, Encoding.UTF8))
            {
                for (var i = 0; i < length; i++, Console.WriteLine())
                {
                    // ReSharper disable once StackAllocInsideLoop
                    Span<int> localMas = stackalloc int[length];
                    for (var j = 0; j < length; j++)
                    {
                        Console.Write("{0,5}", localMas[j] = Random.Next(-100, 101));

                        if (j < localMas.Length - 1)
                            arrayWriter.Write("{0} ", localMas[j]);
                        else if (i < length - 1)
                            arrayWriter.WriteLine(localMas[j]);
                        else
                            arrayWriter.Write(localMas[j]);
                    }
                }
            }
        }
    }
}
