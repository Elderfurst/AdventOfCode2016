using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2016
{
    public class Day4 : IRunnable
    {
        private List<string> realRooms = new List<string>();
        public void Run()
        {
            PartOne();
            PartTwo();
        }

        private void PartOne()
        {
            var input = File.ReadAllText(@"Input\Day4.txt").Split(new string[] { "\r\n" }, StringSplitOptions.None);
            var total = 0;
            foreach (var room in input)
            {
                var splitRoom = room.Split('[');
                var checksum = splitRoom[1].Replace("]", string.Empty).ToCharArray();
                var roomAndSector = splitRoom[0].Split('-');
                var onlySector = roomAndSector.Last();
                var onlyRoom = string.Join("", roomAndSector.Take(roomAndSector.Length - 1));
                var letters = onlyRoom.GroupBy(x => x).Select(x => new { Char = x.Key, Count = x.Count() })
                    .OrderByDescending(x => x.Count).ThenBy(x => x.Char).Take(5);
                if (letters.Count(x => checksum.Contains(x.Char)) == 5)
                {
                    total += int.Parse(onlySector);
                    realRooms.Add(string.Join("-", roomAndSector));
                }
            }
            Console.WriteLine(total);
        }

        private void PartTwo()
        {
            foreach (var room in realRooms)
            {
                var splitRoom = room.Split('-');
                var onlySector = splitRoom.Last();
                var onlyRoom = splitRoom.Take(splitRoom.Length - 1).ToArray();
                var offset = int.Parse(onlySector) % 26;
                for (var i = 0; i < onlyRoom.Count(); i++)
                {
                    onlyRoom[i] = CaesarCypher(onlyRoom[i], offset);
                }
                var completeRoom = string.Join(" ", onlyRoom);
                if (completeRoom.ToLower().Contains("north") && completeRoom.ToLower().Contains("pole"))
                {
                    Console.WriteLine(completeRoom + "; Sector ID: " + onlySector);
                }
            }
        }

        private string CaesarCypher(string input, int offset)
        {
            var newString = "";
            for (var j = 0; j < input.Length; j++)
            {
                var letter = (char) (input[j] + offset);
                if (letter > 'z')
                {
                    letter = (char) (letter - 26);
                }
                else if (letter < 'a')
                {
                    letter = (char) (letter + 26);
                }
                newString += letter;
            }
            return newString;
        }
    }
}
