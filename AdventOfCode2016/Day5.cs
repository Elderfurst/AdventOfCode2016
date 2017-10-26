using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    public class Day5 : IRunnable
    {
        const string input = "uqwqemis";
        public void Run()
        {
            //PartOne();
            PartTwo();
        }

        private void PartOne()
        {
            var counter = 0;
            var password = "";
            var temp = "";
            while (password.Length < 8)
            {
                temp = Hash(input + counter);
                if (temp.StartsWith("00000"))
                {
                    password += temp.ToCharArray()[5];
                    Console.WriteLine(password);
                    Console.WriteLine(counter);
                }
                counter++;
            }
            Console.WriteLine(password);
        }

        private void PartTwo()
        {
            var counter = 0;
            var password = "________";
            var temp = "";
            while (password.Contains('_'))
            {
                temp = Hash(input + counter);
                if (temp.StartsWith("00000") && int.TryParse(char.ToString(temp.ToCharArray()[5]), out int test) && 0 <= int.Parse(char.ToString(temp.ToCharArray()[5])) && int.Parse(char.ToString(temp.ToCharArray()[5])) <= 7 && password[int.Parse(char.ToString(temp.ToCharArray()[5]))] == '_')
                {
                    var sb = new StringBuilder(password);
                    sb[int.Parse(char.ToString(temp.ToCharArray()[5]))] = temp.ToCharArray()[6];
                    password = sb.ToString();
                    Console.WriteLine(password);
                    Console.WriteLine(counter);
                }
                counter++;
            }
            Console.WriteLine(password);
        }

        private string Hash(string word)
        {
            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(word);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                var sb = new StringBuilder();
                foreach (var hashByte in hashBytes)
                {
                    sb.Append(hashByte.ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
