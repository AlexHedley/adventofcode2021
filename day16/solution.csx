using System.Linq;

Console.WriteLine("Day 16");

string[] lines = System.IO.File.ReadAllLines(@"input-sample.txt");
// string[] lines = System.IO.File.ReadAllLines(@"input.txt");

var input = "110100101111111000101000";
var partSize = 4;

var output = input.ToCharArray()
    .BufferWithCount(partSize)
    .Select(c => new String(c.ToArray()));

// Part 2
// Console.WriteLine("Part 2.");


Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();