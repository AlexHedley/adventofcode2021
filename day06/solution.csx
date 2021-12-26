using System.IO;
using System.Threading.Tasks;

Console.WriteLine("Day 6");

// string[] lines = System.IO.File.ReadAllLines(@"input-sample.txt");
string[] lines = System.IO.File.ReadAllLines(@"input.txt");

List<int> lanterns = lines[0].Split(',').Select(i => Int32.Parse(i)).ToList();
// lanterns.ForEach(Console.WriteLine);

// ---

List<int> CalculateLanterns(ref List<int> lanterns)
{
    List<int> newLanterns = new List<int>();
    foreach (var lantern in lanterns)
    {
        var lan = lantern - 1;
        if (lan < 0)
        {
            lan = 6;
            newLanterns.Add(8);
        } 
        newLanterns.Add(lan);
    }
    return newLanterns;
}

// var day1 = CalculateLanterns(lanterns);
// // Console.WriteLine(string.Join<int>(",", day1));

// for (var i = 1; i < 81; i++)
// {
//     lanterns = CalculateLanterns(ref lanterns);
//     Console.WriteLine($"Day {i} #: {lanterns.Count}");
// }

// // Part 2
// Console.WriteLine("Part 2.");

// for (var i = 1; i < 257; i++)
// {
//     lanterns = CalculateLanterns(ref lanterns);
//     Console.WriteLine($"Day {i} #: {lanterns.Count}");
// }

// Day 180 #: 2135672865
// System.OutOfMemoryException: Array dimensions exceeded supported range.

// ---

Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();