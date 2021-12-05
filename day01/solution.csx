Console.WriteLine("Day 1");

string[] lines = System.IO.File.ReadAllLines(@"input.txt"); // @"input-sample.txt"
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

// Part 2

var sum = new List<int>();
for (var i = 0; i < numbers.Count; i++) {
    if (i > numbers.Count - 3) break;
    sum.Add(numbers[i] + numbers[i+1] + numbers[i+2]);
}
// sum.ForEach(Console.WriteLine);

var sum2 = sum.ToList();
sum2.RemoveAt(0);

var diff2 = new List<int>();
for (var i = 0; i < numbers.Count; i++)
{
    if (i > sum2.Count - 1) break;
    // Console.WriteLine(sum[i] + " " + sum2[i]);
    diff2.Add(sum2[i] - sum[i]);
}
// diff2.ForEach(Console.WriteLine);

var positiveNumbers2 = diff2.Where(n => n > 0).ToArray();
Console.WriteLine($"Positive: {positiveNumbers2.Length}");

Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();