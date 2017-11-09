using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AdventOfCode2016
{
    public class Day10 : IRunnable
    {
        private readonly string[] _input = File.ReadAllText(@"Input\Day10.txt").Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        private Queue<Instruction> _instructionQueue = new Queue<Instruction>();
        private readonly List<Bot> _bots = new List<Bot>();
        private readonly List<Output> _output = new List<Output>();
        public void Run()
        {
            Initialize();
            PartOne();
            PartTwo();
        }

        private void Initialize()
        {
            foreach (var line in _input)
            {
                var tokenizedLine = line.Split(' ');
                if (tokenizedLine[0] == "value")
                {
                    var index = _bots.IndexOf(new Bot(int.Parse(tokenizedLine[5])));
                    if (index > -1)
                    {
                        _bots[index].TakeNumber(int.Parse(tokenizedLine[1]));
                    }
                    else
                    {
                        var b = new Bot(int.Parse(tokenizedLine[5]));
                        b.TakeNumber(int.Parse(tokenizedLine[1]));
                        _bots.Add(b);
                    }
                }
                else
                {
                    var instruction = new Instruction
                    {
                        Bot = new Bot(int.Parse(tokenizedLine[1]))
                    };
                    if (tokenizedLine[5] == "output")
                    {
                        instruction.Low = new Output(int.Parse(tokenizedLine[6]));
                    }
                    else
                    {
                        instruction.Low = new Bot(int.Parse(tokenizedLine[6]));
                    }

                    if (tokenizedLine[10] == "output")
                    {
                        instruction.High = new Output(int.Parse(tokenizedLine[11]));
                    }
                    else
                    {
                        instruction.High = new Bot(int.Parse(tokenizedLine[11]));
                    }
                    _instructionQueue.Enqueue(instruction);
                }
            }
        }

        private void PartOne()
        {
            while (_instructionQueue.Count > 0)
            {
                ProcessInstruction(_instructionQueue.Dequeue());
            }
        }

        private void PartTwo()
        {
            
        }

        private void ProcessInstruction(Instruction instruction)
        {
            if (instruction.Low.GetType() == typeof(Bot))
            {
                _bots[_bots.IndexOf((Bot)instruction.Low)].TakeNumber(_bots[_bots.IndexOf(instruction.Bot)].GiveLow());
            }
            else
            {
                _output[_output.IndexOf((Output)instruction.Low)].Microchips.Add(_bots[_bots.IndexOf(instruction.Bot)].GiveLow());
            }
            if (instruction.High.GetType() == typeof(Bot))
            {
                _bots[_bots.IndexOf((Bot)instruction.High)].TakeNumber(_bots[_bots.IndexOf(instruction.Bot)].GiveHigh());
            }
            else
            {
                _output[_output.IndexOf((Output)instruction.High)].Microchips.Add(_bots[_bots.IndexOf(instruction.Bot)].GiveHigh());
            }
        }
    }

    internal class Output
    {
        public int Id;
        public List<int> Microchips;

        public Output(int id)
        {
            Id = id;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var b = (Output) obj;
            return Id == b.Id;
        }
    }

    internal class Instruction
    {
        public Bot Bot;
        public object Low;
        public object High;
    }

    internal class Bot
    {
        public int Id;
        public int First;
        public int Second;

        public Bot(int id)
        {
            Id = id;
        }

        public int GiveHigh()
        {
            if (((First == 61) && (Second == 17)) || ((First == 17) && (Second == 61)))
            {
                Console.WriteLine(Id);
            }
            if (First > Second)
            {
                First = 0;
                return First;
            }
            else
            {
                Second = 0;
                return Second;
            }
        }

        public int GiveLow()
        {
            if (((First == 61) && (Second == 17)) || ((First == 17) && (Second == 61)))
            {
                Console.WriteLine(Id);
            }
            if (First < Second)
            {
                First = 0;
                return First;
            }

            else
            {
                Second = 0;
                return Second;
            }
        }

        public void TakeNumber(int num)
        {
            if (First == 0)
            {
                First = num;
            }
            else
            {
                Second = num;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var b = (Bot) obj;
            return Id == b.Id;
        }
    }
}
