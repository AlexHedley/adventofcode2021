// Console.ForegroundColor = ConsoleColor.White;  
// Console.BackgroundColor = ConsoleColor.Red;
Console.WriteLine("Day 1");

// string text = System.IO.File.ReadAllText(@"input-sample.txt");
// Console.WriteLine(text);

// string[] lines = System.IO.File.ReadAllLines(@"input-sample.txt");
string[] lines = System.IO.File.ReadAllLines(@"input.txt");
// lines.ToList().ForEach(Console.WriteLine);

var numbers = lines.Where(x => int.TryParse(x, out var temp))
                .Select(t=>int.Parse(t.Trim())).ToList();

var numbers2 = numbers.ToList();
numbers2.RemoveAt(0);
// numbers2.ForEach(Console.WriteLine);

var diff = new List<int>();
for (var i = 0; i < numbers.Count; i++)
{
    if (i > numbers2.Count - 1) break;
    // Console.WriteLine(numbers[i] + " " + numbers2[i]);
    diff.Add(numbers2[i] - numbers[i]);
}
// diff.ForEach(Console.WriteLine);

var positiveNumbers = diff.Where(n => n > 0).ToArray();
Console.WriteLine($"Positive: {positiveNumbers.Length}");

// Console.Clear();
// Console.ResetColor();

Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();