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
using System.Diagnostics.CodeAnalysis;

namespace Task3
{
    internal static class Program
    {
        internal const string PathToFile = "myfile.txt";

        [SuppressMessage("ReSharper", "SwitchStatementMissingSomeCases")]
        private static void Main()
        {
            Console.Write("Input program part: ");
            switch (Console.ReadLine())
            {
                case "1":
                    SubTask1.Run(13);
                    break;

                case "2":
                    SubTask2.Run(13);
                    break;
            }
        }
    }
}
