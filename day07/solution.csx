Console.WriteLine("Day 7");

// string[] lines = System.IO.File.ReadAllLines(@"input-sample.txt");
string[] lines = System.IO.File.ReadAllLines(@"input.txt");

List<int> positions = lines[0].Split(',').Select(i => Int32.Parse(i)).ToList();
// lanterns.ForEach(Console.WriteLine);

var max = positions.Max();
Console.WriteLine($"Max: {max}");

List<(int pos, int total)> totals = new List<(int pos, int total)>();

// 16,1,2,0,4,2,7,1,2,14
for (var i=0; i < max; i++)
{
    var total = 0;
    foreach(var pos in positions)
    {
        total += Math.Abs(pos-i);
    }
    Console.WriteLine($"Total ({i}): {total}");
    totals.Add((i, total));
}

var min = totals.OrderBy(t => t.total).FirstOrDefault();
Console.WriteLine($"Minimum ({min.pos}: {min.total})");

Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();