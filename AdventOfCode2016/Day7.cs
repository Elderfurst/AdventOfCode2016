using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    public class Day7 : IRunnable
    {
        private readonly string[] _input = File.ReadAllText(@"C:\Temp\Day7Input.txt").Split(new string[] { "\r\n" }, StringSplitOptions.None);
        public void Run()
        {
            PartOne();
            PartTwo();
        }

        private void PartOne()
        {
            var count = 0;
            foreach (var input in _input)
            {
                count += ContainsAbba(input);
            }
            Console.WriteLine(count);
        }

        private void PartTwo()
        {
            var count = 0;
            foreach (var input in _input)
            {
                count += ContainsAba(input);
            }
            Console.WriteLine(count);
        }


        private static int ContainsAbba(string input)
        {
            var insideBrackets = false;
            var returnValue = 0;
            for (var i = 0; i < input.Length - 3; i++)
            {
                if (input[i] == '[')
                {
                    insideBrackets = true;
                }
                else if (input[i] == ']')
                {
                    insideBrackets = false;
                }
                if (input[i] == input[i + 3] && input[i + 1] == input[i + 2] && input[i] != input[i + 1] && !insideBrackets)
                {
                    returnValue = 1;
                }
                else if (input[i] == input[i + 3] && input[i + 1] == input[i + 2] && input[i] != input[i + 1] && insideBrackets)
                {
                    return 0;
                }
            }
            return returnValue;
        }

        private static int ContainsAba(string input)
        {
            return 0;
        }
    }
}
