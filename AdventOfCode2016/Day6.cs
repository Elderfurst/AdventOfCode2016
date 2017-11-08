using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2016
{
    public class Day6 : IRunnable
    {
        private readonly string[] _input = File.ReadAllText(@"Input\Day6Input.txt").Split(new string[] { "\r\n" }, StringSplitOptions.None);
        public void Run()
        {
            PartOne();
            PartTwo();
        }

        private void PartOne()
        {
            var result = "";
            for (var i = 0; i < _input[0].Length; i++)
            {
                result += _input.Select(x => x[i]).GroupBy(x => x).Select(x => new {Char = x.Key, Count = x.Count()})
                    .OrderByDescending(x => x.Count).Take(1).First().Char;
            }
            Console.WriteLine(result);
        }

        private void PartTwo()
        {
            var result = "";
            for (var i = 0; i < _input[0].Length; i++)
            {
                result += _input.Select(x => x[i]).GroupBy(x => x).Select(x => new { Char = x.Key, Count = x.Count() })
                    .OrderBy(x => x.Count).Take(1).First().Char;
            }
            Console.WriteLine(result);
        }
    }
}
