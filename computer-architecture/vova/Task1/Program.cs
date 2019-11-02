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
using System.IO;
using System.Text;

namespace Task1
{
    internal static class Program
    {
        private static void Main()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.InputEncoding = Console.OutputEncoding = Encoding.GetEncoding(1251);

            Console.Write("Введите имя файла: ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            var pathToFile = Console.ReadLine();

            Console.ResetColor();
            Console.Write("Проверка: ");
            Console.ForegroundColor = ConsoleColor.Magenta;

            if (!File.Exists(pathToFile))
            {
                Console.Write("Файл не найден");
                return;
            }

            Console.WriteLine("OK");
            Console.ResetColor();

            Console.Write("Введите количество байтов (1-36): ");
            Console.ForegroundColor = ConsoleColor.Magenta;

            if (!int.TryParse(Console.ReadLine(), out var countOfBytes) || countOfBytes < 1)
            {
                countOfBytes = 15;
            }
            else if (countOfBytes > 36)
            {
                countOfBytes = 36;
            }

            var file = File.OpenRead(pathToFile);
            Span<byte> buffer = stackalloc byte[countOfBytes > file.Length ? (int) file.Length : countOfBytes];
            file.Read(buffer);
            file.Dispose();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Последовательность байт:");
            Console.ResetColor();

            for (var i = 0; i < buffer.Length; i++)
            {
                Console.Write(buffer[i]);

                if (i != buffer.Length - 1)
                    Console.Write(' ');
                else Console.WriteLine();
            }

            var allBits = GetAllBits(buffer);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Бинарная последовательность:");
            Console.ResetColor();
            PrintBits(allBits);

            var shiftedBits = RightShiftBits(allBits, 5);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Сдвиг вправо -> на 5 бит:");
            Console.ResetColor();
            PrintBits(shiftedBits);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Сжатие:");
            Console.ResetColor();

            var shiftedPositions = BytesStartingWithOne(shiftedBits, out var countOfBytesStartingFrom0);
            Span<byte> zippedBits = stackalloc byte[shiftedPositions.Length * 8];
            var zippedPosition = 0;
            foreach (ref readonly var position in shiftedPositions)
            {
                shiftedBits.Slice(position, 8).CopyTo(zippedBits.Slice(zippedPosition, 8));
                zippedPosition += 8;
            }

            PrintBits(zippedBits);

            Console.WriteLine("Количество байт, которые начинаются с нуля: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(countOfBytesStartingFrom0);
        }

        private static void WriteBits(byte b, Span<byte> bits)
        {
            for (int i = 7, j = 0; i > -1; i--, j++)
            {
                bits[j] = (byte) ((b >> i) & 0b00000001);
            }
        }

        private static ReadOnlySpan<byte> GetAllBits(ReadOnlySpan<byte> bytes)
        {
            Span<byte> bits = new byte[bytes.Length * 8];

            var i = 0;
            foreach (ref readonly var b in bytes)
            {
                WriteBits(b, bits.Slice(i++ * 8, 8));
            }

            return bits;
        }

        private static void PrintBits(ReadOnlySpan<byte> bits)
        {
            for (var i = 0; i < bits.Length; i += 8)
            {
                foreach (ref readonly var bit in bits.Slice(i, 8))
                {
                    Console.Write(bit);
                }

                if (i < bits.Length - 8)
                    Console.Write(' ');
                else Console.WriteLine();
            }
        }

        private static ReadOnlySpan<byte> RightShiftBits(ReadOnlySpan<byte> bits, int length)
        {
            Span<byte> rightShiftedBits = new byte[bits.Length];

            for (var i = 0; i < bits.Length; i++)
            {
                rightShiftedBits[(i + length) % rightShiftedBits.Length] = bits[i];
            }

            return rightShiftedBits;
        }

        private static ReadOnlySpan<int> BytesStartingWithOne(ReadOnlySpan<byte> bits, out int countOfBytesStartingFromZero)
        {
            countOfBytesStartingFromZero = 0;
            Span<int> positions = new int[bits.Length];
            var countOfBytesStartingFromOne = 0;

            for (var i = 0; i < bits.Length; i += 8)
            {
                ref readonly var b = ref bits[i];

                if (b == 0)
                {
                    countOfBytesStartingFromZero++;
                }
                else
                {
                    positions[countOfBytesStartingFromOne++] = i;
                }
            }

            return positions.Slice(0, countOfBytesStartingFromOne);
        }
    }
}