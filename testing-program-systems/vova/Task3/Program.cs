﻿//    Copyright(C) 2019  Vova Lantsov

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

namespace Task3
{
    internal static class Program
    {
        private static readonly Random Random = new Random();
        
        private static void Main()
        {
            var mas = new int[13, 13];
            
            for (var i = 0; i < mas.GetLength(1); i++)
            {
                for (var j = 0; j < mas.GetLength(2); j++)
                {
                    mas[i, j] = Random.Next(-100, 101);
                }
            }
            
            
        }
    }
}
