Console.WriteLine("Day 15");

// string[] lines = System.IO.File.ReadAllLines(@"input-sample.txt");
// string[] lines = System.IO.File.ReadAllLines(@"input.txt");

int[][] list = File.ReadAllLines("input-sample.txt")
                   .Select(l => l.ToCharArray().Select(i => int.Parse(i.ToString())).ToArray())
                   .ToArray();

Console.WriteLine(list[3][9]);

// Part 2
// Console.WriteLine("Part 2.");


Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();