using System;
using System.Collections.Generic;

namespace AdventOfCode2016
{
    public class Day1 : IRunnable
    {
        public void Run()
        {
            var visitedLocations = new List<string>()
            {
                "0,0"
            };
            var input = new List<string>()
            {
                "R2", "L5", "L4", "L5", "R4", "R1", "L4", "R5", "R3", "R1", "L1", "L1", "R4", "L4", "L1", "R4", "L4", "R4", "L3", "R5", "R4", "R1", "R3", "L1", "L1", "R1", "L2", "R5", "L4", "L3", "R1", "L2", "L2", "R192", "L3", "R5", "R48", "R5", "L2", "R76", "R4", "R2", "R1", "L1", "L5", "L1", "R185", "L5", "L1", "R5", "L4", "R1", "R3", "L4", "L3", "R1", "L5", "R4", "L4", "R4", "R5", "L3", "L1", "L2", "L4", "L3", "L4", "R2", "R2", "L3", "L5", "R2", "R5", "L1", "R1", "L3", "L5", "L3", "R4", "L4", "R3", "L1", "R5", "L3", "R2", "R4", "R2", "L1", "R3", "L1", "L3", "L5", "R4", "R5", "R2", "R2", "L5", "L3", "L1", "L1", "L5", "L2", "L3", "R3", "R3", "L3", "L4", "L5", "R2", "L1", "R1", "R3", "R4", "L2", "R1", "L1", "R3", "R3", "L4", "L2", "R5", "R5", "L1", "R4", "L5", "L5", "R1", "L5", "R4", "R2", "L1", "L4", "R1", "L1", "L1", "L5", "R3", "R4", "L2", "R1", "R2", "R1", "R1", "R3", "L5", "R1", "R4"
            };
            var currentDirection = "N";
            var x = 0;
            var y = 0;
            foreach (var direction in input)
            {
                if (currentDirection == "N" && direction.Substring(0, 1) == "R")
                {
                    for(var i = 0; i < int.Parse(direction.Substring(1)); i++)
                    {
                        x++;
                        if (visitedLocations.Contains(x + "," + y))
                        {
                            Console.WriteLine("The Easter Bunny's HQ is " + (Math.Abs(x) + Math.Abs(y)) + " blocks away");
                            break;
                        }
                        visitedLocations.Add(x + "," + y);
                    }
                    currentDirection = "E";
                }
                else if (currentDirection == "N" && direction.Substring(0, 1) == "L")
                {
                    for (var i = 0; i < int.Parse(direction.Substring(1)); i++)
                    {
                        x--;
                        if (visitedLocations.Contains(x + "," + y))
                        {
                            Console.WriteLine("The Easter Bunny's HQ is " + (Math.Abs(x) + Math.Abs(y)) + " blocks away");
                            break;
                        }
                        visitedLocations.Add(x + "," + y);
                    }
                    currentDirection = "W";
                }
                else if (currentDirection == "S" && direction.Substring(0, 1) == "R")
                {
                    for (var i = 0; i < int.Parse(direction.Substring(1)); i++)
                    {
                        x--;
                        if (visitedLocations.Contains(x + "," + y))
                        {
                            Console.WriteLine("The Easter Bunny's HQ is " + (Math.Abs(x) + Math.Abs(y)) + " blocks away");
                            break;
                        }
                        visitedLocations.Add(x + "," + y);
                    }
                    currentDirection = "W";
                }
                else if (currentDirection == "S" && direction.Substring(0, 1) == "L")
                {
                    for (var i = 0; i < int.Parse(direction.Substring(1)); i++)
                    {
                        x++;
                        if (visitedLocations.Contains(x + "," + y))
                        {
                            Console.WriteLine("The Easter Bunny's HQ is " + (Math.Abs(x) + Math.Abs(y)) + " blocks away");
                            break;
                        }
                        visitedLocations.Add(x + "," + y);
                    }
                    currentDirection = "E";
                }
                else if (currentDirection == "E" && direction.Substring(0, 1) == "R")
                {
                    for (var i = 0; i < int.Parse(direction.Substring(1)); i++)
                    {
                        y--;
                        if (visitedLocations.Contains(x + "," + y))
                        {
                            Console.WriteLine("The Easter Bunny's HQ is " + (Math.Abs(x) + Math.Abs(y)) + " blocks away");
                            break;
                        }
                        visitedLocations.Add(x + "," + y);
                    }
                    currentDirection = "S";
                }
                else if (currentDirection == "E" && direction.Substring(0, 1) == "L")
                {
                    for (var i = 0; i < int.Parse(direction.Substring(1)); i++)
                    {
                        y++;
                        if (visitedLocations.Contains(x + "," + y))
                        {
                            Console.WriteLine("The Easter Bunny's HQ is " + (Math.Abs(x) + Math.Abs(y)) + " blocks away");
                            break;
                        }
                        visitedLocations.Add(x + "," + y);
                    }
                    currentDirection = "N";
                }
                else if (currentDirection == "W" && direction.Substring(0, 1) == "R")
                {
                    for (var i = 0; i < int.Parse(direction.Substring(1)); i++)
                    {
                        y++;
                        if (visitedLocations.Contains(x + "," + y))
                        {
                            Console.WriteLine("The Easter Bunny's HQ is " + (Math.Abs(x) + Math.Abs(y)) + " blocks away");
                            break;
                        }
                        visitedLocations.Add(x + "," + y);
                    }
                    currentDirection = "N";
                }
                else if (currentDirection == "W" && direction.Substring(0, 1) == "L")
                {
                    for (var i = 0; i < int.Parse(direction.Substring(1)); i++)
                    {
                        y--;
                        if (visitedLocations.Contains(x + "," + y))
                        {
                            Console.WriteLine("The Easter Bunny's HQ is " + (Math.Abs(x) + Math.Abs(y)) + " blocks away");
                            break;
                        }
                        visitedLocations.Add(x + "," + y);
                    }
                    currentDirection = "S";
                }
            }

            Console.WriteLine("The Easter Bunny's HQ is " + (Math.Abs(x) + Math.Abs(y)) + " blocks away");
        }
    }
}
