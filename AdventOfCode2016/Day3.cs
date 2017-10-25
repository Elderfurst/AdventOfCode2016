using System;
using System.IO;
using System.Linq;


namespace AdventOfCode2016
{
    public class Day3 : IRunnable
    {
        public void Run()
        {
            var input = File.ReadAllText(@"C:\Temp\Day3Input.txt");
            var triangles = input.Split(new string[] {"\r\n"}, StringSplitOptions.None)
                .Select(x => x.Trim().Split().Where(y => !string.IsNullOrEmpty(y))).ToArray();
            var possible = 0;

            for (var i = 0; i < triangles[0].Count(); i++)
            {
                for (var j = 0; j < triangles.Length - 2; j = j + 3)
                {
                    if (int.Parse(triangles[j].ElementAt(i)) + int.Parse(triangles[j + 1].ElementAt(i)) > int.Parse(triangles[j + 2].ElementAt(i)) && int.Parse(triangles[j + 1].ElementAt(i)) + int.Parse(triangles[j + 2].ElementAt(i)) > int.Parse(triangles[j].ElementAt(i)) && int.Parse(triangles[j].ElementAt(i)) + int.Parse(triangles[j + 2].ElementAt(i)) > int.Parse(triangles[j + 1].ElementAt(i)))
                    {
                        possible++;
                    }
                }
            }

/*            foreach (var currentTriangle in input.Split(new string[] {"\r\n"}, StringSplitOptions.None))
            {
                var triangle = currentTriangle.Trim().Split();
                triangle = triangle.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                if (int.Parse(triangle[0]) + int.Parse(triangle[1]) > int.Parse(triangle[2]) && int.Parse(triangle[1]) + int.Parse(triangle[2]) > int.Parse(triangle[0]) && int.Parse(triangle[0]) + int.Parse(triangle[2]) > int.Parse(triangle[1]))
                {
                    possible++;
                }
            }*/
            Console.WriteLine(possible);
        }
    }
}
