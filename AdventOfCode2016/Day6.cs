﻿using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2016
{
    public class Day6 : IRunnable
    {
        string[] input = File.ReadAllText(@"C:\Temp\Day6Input.txt").Split(new string[] { "\r\n" }, StringSplitOptions.None);
        public void Run()
        {
            PartOne();
            PartTwo();
        }

        private void PartOne()
        {
            var result = "";
            for (var i = 0; i < input[0].Length; i++)
            {
                result += input.Select(x => x[i]).GroupBy(x => x).Select(x => new {Char = x.Key, Count = x.Count()})
                    .OrderByDescending(x => x.Count).Take(1).First().Char;
            }
            Console.WriteLine(result);
        }

        private void PartTwo()
        {
            var result = "";
            for (var i = 0; i < input[0].Length; i++)
            {
                result += input.Select(x => x[i]).GroupBy(x => x).Select(x => new { Char = x.Key, Count = x.Count() })
                    .OrderBy(x => x.Count).Take(1).First().Char;
            }
            Console.WriteLine(result);
        }
    }
}
