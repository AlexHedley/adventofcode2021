Console.WriteLine("Day 10");

string[] lines = System.IO.File.ReadAllLines(@"input-sample.txt");
// string[] lines = System.IO.File.ReadAllLines(@"input.txt");

// () // [] // {} // <>

var errorScores = new Dictionary<char, int>();
errorScores.Add('(', 3);
errorScores.Add(']', 57);
errorScores.Add('}', 1197);
errorScores.Add('>', 25137);

// var curly = errorScores['('];

foreach (var line in lines)
{
    foreach(char c in line)
    {

    }
}

// Part 2
// Console.WriteLine("Part 2.");

Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();