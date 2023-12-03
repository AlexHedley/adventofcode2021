Console.WriteLine("Day 3");

string[] lines = System.IO.File.ReadAllLines(@"input-sample.txt");
// string[] lines = System.IO.File.ReadAllLines(@"input.txt");

var gr = "";
for (var i = 0; i < lines[0].Length; i++)
{
    var grouped = lines.GroupBy(l => Int32.Parse(l.Substring(i, 1)))
        .Select(g => new { Number = g.Key, Count = g.Select(l => l).Count()})
        .OrderByDescending(t => t.Count).FirstOrDefault();
    gr += grouped.Number;
}

Console.WriteLine($"Gamma Rate (Binary): {gr}");
var gRD = Convert.ToInt32(gr, 2);
Console.WriteLine($"Gamma Rate (Decimal): {gRD}");

var elipsonRate = gr.Replace("1","2").Replace("0", "1").Replace("2", "0");
Console.WriteLine($"Elipson Rate (Binary): {elipsonRate}");
var eRD = Convert.ToInt32(elipsonRate, 2);
Console.WriteLine($"Elipson Rate (Decimal): {eRD}");

Console.WriteLine($"Power Consumption: {gRD*eRD}");

Console.WriteLine("Day 3 - Part 2");

var lifeSupportRating = 0;
var oxygenGeneratorRating = 0;
var CO2ScrubberRating = 0;

// for (var i = 0; i < lines[0].Length; i++)
// {
//     var grouped = lines.GroupBy(l => Int32.Parse(l.Substring(i, 1)))
//         .Select(g => new { Number = g.Key, Count = g.Select(l => l).Count()})
//         .OrderByDescending(t => t.Count).FirstOrDefault();

//     var ogr = new List<string>();
//     foreach(var line in lines)
//     {
//         if (Int32.Parse(line.Substring(i, 1)) == grouped.Number)
//         {
//             ogr.Add(line);
//         }
//     }
//     ogr.ForEach(Console.WriteLine);
//     Console.WriteLine();
//     ogr.Clear();
// }

var first = ogr(lines.ToList(), 0);
var second = ogr(first, 1);
var third = ogr(second, 2);
var fourth = ogr(third, 3);
var fifth = ogr(fourth, 4);
var gR2 = fifth[0];

Console.WriteLine($"Gamma Rate (Binary): {gR2}");
var gRD2 = Convert.ToInt32(gR2, 2);
Console.WriteLine($"Gamma Rate (Decimal): {gRD2}");

var elipsonRate2 = gR2.Replace("1","2").Replace("0", "1").Replace("2", "0");
Console.WriteLine($"Elipson Rate (Binary): {elipsonRate2}");
var eRD2 = Convert.ToInt32(elipsonRate2, 2);
Console.WriteLine($"Elipson Rate (Decimal): {eRD2}");

// ---

List<string> ogr(List<string> items, int index) {
    Console.WriteLine($"Index: {index} : {items.Count}");
    if (items.Count == 1) return items;

    for (var i = 0; i < items[0].Length; i++)
    {
        var ratings = new List<string>();

        var grouped = items.GroupBy(l => Int32.Parse(l.Substring(index, 1)))
            .Select(g => new { Number = g.Key, Count = g.Select(l => l).Count()})
            .OrderByDescending(t => t.Count).FirstOrDefault();
        Console.WriteLine($"GN-{grouped.Number}: GC-{grouped.Count}");
        
        ratings = items.Where(l => Int32.Parse(l.Substring(index, 1)) == grouped.Number).Select(l => l).ToList();
        ratings.ForEach(Console.WriteLine);
        Console.WriteLine();
        
        return ratings;
    }

    return items;
}

// lifeSupportRating = oxygenGeneratorRating * CO2ScrubberRating;
// Console.WriteLine($"Life Support Rating: {lifeSupportRating}");

Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();