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

namespace Task3
{
    internal static class SubTask1
    {
        internal static void Run(int[,] mas)
        {
            int count = 0;
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); i++)
                {
                    var current = mas[i, j];

                    if (i > 0 && mas[i - 1, j] < current)
                        continue;

                }
            }
        }
    }
}
