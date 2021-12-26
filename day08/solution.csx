Console.WriteLine("Day 8");

// string[] lines = System.IO.File.ReadAllLines(@"input-sample.txt");
// string[] lines = System.IO.File.ReadAllLines(@"input-sample-2.txt");
string[] lines = System.IO.File.ReadAllLines(@"input.txt");

// List<(int num, int segments)> display = new List<(int num, int segments)>() { (0, 6), (1, 2), (2, 5), (3, 5), (4, 4), (5, 5), (6, 6), (7, 3), (8, 7), (9, 6) };

var numbers = new List<(int number, int count, List<char> segments)>();
numbers.Add((0, 6, new List<char>{ 'a', 'b', 'c', 'e', 'f', 'g' }));
numbers.Add((1, 2, new List<char>{ 'c', 'f' }));
numbers.Add((2, 5, new List<char>{ 'a', 'c', 'd', 'e', 'g' }));
numbers.Add((3, 5, new List<char>{ 'a', 'c', 'd', 'f', 'g' }));
numbers.Add((4, 4, new List<char>{ 'b', 'c', 'd', 'f' }));
numbers.Add((5, 5, new List<char>{ 'a', 'b', 'd', 'f', 'g' }));
numbers.Add((6, 6, new List<char>{ 'a', 'b', 'd', 'e', 'f', 'g' }));
numbers.Add((7, 3, new List<char>{ 'a', 'c', 'f' }));
numbers.Add((8, 7, new List<char>{ 'a', 'b', 'c', 'd', 'e', 'f', 'g'}));
numbers.Add((9, 6, new List<char>{ 'a', 'b', 'c', 'd', 'f', 'g' }));

var uniqueNumbers = new List<int>();

// var uniqueSignalPatterns = items[0].Split(' ', StringSplitOptions.TrimEntries).ToList();
// uniqueSignalPatterns.ForEach(Console.WriteLine);

// foreach (var usp in uniqueSignalPatterns)
// {
    // var matching  = numbers.Where(x => x.count == usp.Length).Select(x => x).ToList();
    // Console.Write($"{usp}: {usp.Length} - Matching: {matching.Count}");
    // if (matching.Count == 1)
    // {
    //     Console.Write($" | {string.Join("", matching[0].segments)} | {matching[0].number}");
    //     uniqueNumbers.Add(matching[0].number);
    // }
    // Console.WriteLine();
// }

for(var i = 0; i < lines.Length; i++)
{
    List<string> items = lines[i].Split('|', StringSplitOptions.TrimEntries).ToList();
    // items.ForEach(Console.WriteLine);
    // Console.WriteLine($"Items #:{items.Count}");

    var outputs = items[1].Split(' ', StringSplitOptions.TrimEntries).ToList();
    // outputs.ForEach(Console.WriteLine);
    // Console.WriteLine($"Outputs #:{outputs.Count}");
    // outputs.ForEach(x => Console.WriteLine(x.Length));

    uniqueNumbers.AddRange(UniqueNumbers(outputs));
}

Console.WriteLine($"#: {uniqueNumbers.Count}");

// uniqueNumbers.ForEach(Console.WriteLine);
Console.WriteLine(string.Join(", ", uniqueNumbers.Distinct().OrderBy(n => n).ToList()));

// --- --- ---

// Unique Numbers
public List<int> UniqueNumbers(List<string> outputs)
{
    var foundNumbers = new List<int>();

    foreach (var output in outputs)
    {
        var matching  = numbers.Where(x => x.count == output.Length).Select(x => x).ToList();
        // Console.Write($"{output}: {output.Length} - Matching: {matching.Count}");
        if (matching.Count == 1)
        {
            // Console.Write($" | {string.Join("", matching[0].segments)} | {matching[0].number}");
            foundNumbers.Add(matching[0].number);
        }
        // Console.WriteLine();
    }

    // foundNumbers.ForEach(Console.WriteLine);
    // Console.WriteLine(string.Join(", ", foundNumbers));

    return foundNumbers;
}

// --- --- ---

// Part 2
// Console.WriteLine("Part 2.");

// --- --- ---

// Testing

// var matching  = numbers.Where(x => x.count == 2).Select(x => x).ToList(); // var matching  = numbers.Select(x => x.count == 2).ToList();
// Console.WriteLine($"Matching: {matching.Count}");

Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();