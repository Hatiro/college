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

namespace Task3
{
    internal static class SubTask2
    {
        internal static void Run(int length)
        {
            int sumOfModulesOfItemsAboveMainDiagonal = 0, countOfLocalMins = 0;
            Span<int> previousLine1 = stackalloc int[length],
                previousLine2 = stackalloc int[length];

            using (var arrayReader = new StreamReader(Program.PathToFile, Encoding.UTF8))
            {
                var line = arrayReader.ReadLine();
                for (var i = 0; line != null; line = arrayReader.ReadLine(), Console.WriteLine(), i++)
                {
                    var currentLine = line.Split(' ').Select(int.Parse).ToArray().AsSpan();

                    for (var j = 0; j < length; j++)
                    {
                        var current = currentLine[j];

                        Console.Write("{0,5}", current);

                        if (j > i)
                            sumOfModulesOfItemsAboveMainDiagonal += Math.Abs(current);

                        if (i == 0)
                            continue;

                        var itemAbove = previousLine1[j];

                        if (itemAbove < current &&
                            (j == 0 || itemAbove < previousLine1[j - 1]) &&
                            (j == length - 1 || itemAbove < previousLine1[j + 1]) &&
                            (i == 1 || itemAbove < previousLine2[j]))
                        {
                            countOfLocalMins++;
                        }

                        if (i == length - 1 &&
                            (j == 0 || current < currentLine[j - 1]) &&
                            (j == length - 1 || current < currentLine[j + 1]) &&
                            current < itemAbove)
                        {
                            countOfLocalMins++;
                        }
                    }
                    
                    if (i != 0)
                        previousLine1.CopyTo(previousLine2);
                    currentLine.CopyTo(previousLine1);
                }
            }
            
            Console.WriteLine("The sum of absolute values of items that are placed above the main diagonal is {0}",
                sumOfModulesOfItemsAboveMainDiagonal);
            Console.WriteLine("The count of local mins: {0}", countOfLocalMins);
        }
    }
}