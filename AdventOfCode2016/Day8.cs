
using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode2016
{
    public class Day8 : IRunnable
    {
        private const int XValue = 50;
        private const int YValue = 6;
        private string[,] _screen = new string[YValue, XValue];
        private readonly string[] _input = File.ReadAllText(@"Input\Day8.txt").Split(new string[] { "\r\n" }, StringSplitOptions.None);

        public void Run()
        {
            _screen = NewPopulatedArray();
            PartOne();
            PartTwo();
        }

        private string[,] NewPopulatedArray()
        {
            var tempArray = new string[YValue, XValue];
            for (var i = 0; i < _screen.GetLength(0); i++)
            {
                for (var j = 0; j < _screen.GetLength(1); j++)
                {
                    tempArray[i, j] = "*";
                }
            }
            return tempArray;
        }
        private void PartOne()
        {
            foreach (var line in _input)
            {
                var temp = "";
                if (line.StartsWith("rect"))
                {
                    temp = line.Replace("rect ", "");
                    ActivateRectangle(int.Parse(temp.Substring(0, temp.IndexOf("x", StringComparison.Ordinal))), int.Parse(temp.Substring(temp.IndexOf("x", StringComparison.Ordinal) + 1)));
                }
                else if (line.StartsWith("rotate row"))
                {
                    temp = line.Replace("rotate row ", "");
                    RotateRow(int.Parse(temp.Substring(temp.IndexOf("y", StringComparison.Ordinal) + 2, 1)), int.Parse(temp.Substring(temp.IndexOf("by ", StringComparison.Ordinal) + 3)));
                }
                else if (line.StartsWith("rotate column"))
                {
                    temp = line.Replace("rotate column ", "");
                    RotateColumn(int.Parse(temp.Substring(temp.IndexOf("x", StringComparison.Ordinal) + 2, 2).Trim()), int.Parse(temp.Substring(temp.IndexOf("by ", StringComparison.Ordinal) + 3)));
                }
            }
            Console.WriteLine(_screen.Cast<string>().Count(x => x != "*"));
        }

        private void PartTwo()
        {
            PrintScreen();
        }

        private void ActivateRectangle(int x, int y)
        {
            for (var i = 0; i < y; i++)
            {
                for (var j = 0; j < x; j++)
                {
                    _screen[i, j] = "#";
                }
            }
        }

        private void RotateRow(int row, int shift)
        {
            var tempScreen = new string[YValue, XValue];
            Array.Copy(_screen, tempScreen, YValue * XValue);
            for (var i = 0; i < _screen.GetLength(1); i++)
            {
                if ((i + shift) >= _screen.GetLength(1))
                {
                    tempScreen[row, (i + shift) % (_screen.GetLength(1))] = _screen[row, i];
                }
                else
                {
                    tempScreen[row, i + shift] = _screen[row, i];
                }
            }
            _screen = tempScreen;
        }

        private void RotateColumn(int column, int shift)
        {
            var tempScreen = new string[YValue, XValue];
            Array.Copy(_screen, tempScreen, YValue * XValue);
            for (var i = 0; i < _screen.GetLength(0); i++)
            {
                if ((i + shift) >= _screen.GetLength(0))
                {
                    tempScreen[(i + shift) % (_screen.GetLength(0)), column] = _screen[i, column];
                }
                else
                {
                    tempScreen[i + shift, column] = _screen[i, column];
                }
            }
            _screen = tempScreen;
        }

        private void PrintScreen()
        {
            Console.Write(new string('-', XValue) + Environment.NewLine);
            for (var i = 0; i < _screen.GetLength(0); i++)
            {
                for (var j = 0; j < _screen.GetLength(1); j++)
                {
                    Console.Write($"{_screen[i, j]}");
                }
                Console.Write(Environment.NewLine);
            }
            Console.Write(new string('-', XValue) + Environment.NewLine);
        }
    }
}
