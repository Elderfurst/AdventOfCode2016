using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;


namespace AdventOfCode2016
{
    public class Day9 : IRunnable
    {
        private readonly string _input = File.ReadAllText(@"Input\Day9.txt");
        public void Run()
        {
            PartOne();
            PartTwo();
        }

        private void PartOne()
        {
            const string pattern = @"\(\d+x\d+\)";
            var decompressed = "";
            for (var i = 0; i < _input.Length; i++)
            {
                decompressed += _input[i];
                var matches = Regex.Matches(decompressed, pattern);
                if (matches.Count > 0)
                {
                    var letterCount = int.Parse(matches[0].Groups[0].ToString().Substring(0, matches[0].Groups[0].ToString().IndexOf("x", StringComparison.Ordinal)).Replace("(", ""));
                    var repeatCount = int.Parse(matches[0].Groups[0].ToString().Substring(matches[0].Groups[0].ToString().IndexOf("x", StringComparison.Ordinal) + 1).Replace(")", ""));
                    decompressed = decompressed.Replace(matches[0].Groups[0].ToString(), "");
                    for (var j = 0; j < repeatCount; j++)
                    {
                        decompressed += _input.Substring(i + 1, letterCount).Replace("(", "*").Replace(")", "*");
                    }
                    i += letterCount;
                }
            }
            Console.WriteLine(decompressed.Count());
        }

        private void PartTwo()
        {
            //Day 9 part 2 should use recursion to unpack the strings
        }
    }
}
