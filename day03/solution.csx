Console.WriteLine("Day 3");

// string[] lines = System.IO.File.ReadAllLines(@"input-sample.txt");
string[] lines = System.IO.File.ReadAllLines(@"input.txt");

private double powerConsumption = 0;

// var sumOfFirstOnes = lines.Select(l => Int32.Parse(l.Substring(0, 1))).ToList().Sum();
// Console.WriteLine($"sumOfFirstOnes: {sumOfFirstOnes}");

var gr = "";
for (var i = 0; i<  lines[0].Length; i++)
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

Console.WriteLine($"Power Consumption {gRD*eRD}");

Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();