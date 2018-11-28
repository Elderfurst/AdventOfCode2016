using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2016
{
    public class Day10 : IRunnable
    {
        private readonly string[] _input = File.ReadAllText(@"Input\Day10.txt").Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        private readonly List<IInstruction> _instructions = new List<IInstruction>();
        private readonly List<Bot> _bots = new List<Bot>();
        private readonly List<Output> _outputs = new List<Output>();

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
                var parsed = line.Split(' ');
                if (parsed[0] == "value")
                {
                    var botId = int.Parse(parsed[5]);
                    _instructions.Add(new ReceiveInstruction
                    {
                        Value = int.Parse(parsed[1]),
                        BotId = botId
                    });
                }
            }
        }

        private void PartOne()
        {

        }

        private void PartTwo()
        {

        }
    }

    internal class Output
    {
        public int Id { get; set; }

        public List<int> values = new List<int>();
    }

    internal class Bot
    {
        public int Id { get; set; }
        public int High { get; set; }
        public int Low { get; set; }
    }

    internal interface IInstruction
    {
        bool CanRun();
    }

    internal class ReceiveInstruction : IInstruction
    {
        public int Value { get; set; }
        public int BotId { get; set; }
        public bool CanRun()
        {
            return true;
        }
    }

    internal class GiveInstruction : IInstruction
    {
        public int GivingBotId { get; set; }
        public ValueIdentifier FirstValueIdentifier { get; set; }
        public GiveIdentifier FirstGiveIdentifier { get; set; }
        public int FirstGiveId { get; set; }
        public ValueIdentifier SecondValueIdentifier { get; set; }
        public GiveIdentifier SecondGiveIdentifier { get; set; }
        public int SecondGiveId { get; set; }

        public bool CanRun()
        {
            return true;
        }
    }

    enum ValueIdentifier
    {
        HIGH,
        LOW
    }

    enum GiveIdentifier
    {
        BOT,
        OUTPUT
    }
}
