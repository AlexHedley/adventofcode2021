using System.Text.RegularExpressions;

Console.WriteLine("Day 22");

string[] lines = System.IO.File.ReadAllLines(@"input-sample.txt");
// string file = System.IO.File.ReadAllText(@"input-sample.txt");
// string[] lines = System.IO.File.ReadAllLines(@"input.txt");

string pattern = @"(on|off) (x=\d*..\d*),(y=\d*..\d*),(z=\d*..\d*)";
// Regex rg = new Regex(pattern);
// MatchCollection matchedCommands = rg.Matches(lines[0]);
// for (int count = 0; count < matchedCommands.Count; count++)
//     Console.WriteLine(matchedCommands[count].Value);

// var match = Regex.Match(lines[0], pattern);
// Console.WriteLine(match.Value);
// Console.WriteLine(match.Groups[0]);
// Console.WriteLine(match.Groups[1]); // on or off
// Console.WriteLine(match.Groups[2]); // x
// Console.WriteLine(match.Groups[3]); // y
// Console.WriteLine(match.Groups[4]); // z

// on x=10..12,y=10..12,z=10..12
string patternComplex = @"(on|off) (x=(\d*)..(\d*)),(y=(\d*)..(\d*)),(z=(\d*)..(\d*))";
var matchComplex = Regex.Match(lines[0], patternComplex);
// Console.WriteLine(matchComplex.Value);
// Console.WriteLine(matchComplex.Groups[0]);
// Console.WriteLine(matchComplex.Groups[1]); // on or off
// Console.WriteLine(matchComplex.Groups[2]); // x=1..2
// Console.WriteLine(matchComplex.Groups[3]); // 1
// Console.WriteLine(matchComplex.Groups[4]); // 2
// Console.WriteLine(matchComplex.Groups[5]); // y=3..4
// Console.WriteLine(matchComplex.Groups[6]); // 3
// Console.WriteLine(matchComplex.Groups[7]); // 4
// Console.WriteLine(matchComplex.Groups[8]); // z=5..6
// Console.WriteLine(matchComplex.Groups[9]); // 5
// Console.WriteLine(matchComplex.Groups[10]); // 6

var action = matchComplex.Groups[1].Value;
var x = new Bounds(Int32.Parse(matchComplex.Groups[3].Value), Int32.Parse(matchComplex.Groups[4].Value));
var y = new Bounds(Int32.Parse(matchComplex.Groups[6].Value), Int32.Parse(matchComplex.Groups[7].Value));
var z = new Bounds(Int32.Parse(matchComplex.Groups[9].Value), Int32.Parse(matchComplex.Groups[10].Value));
var rebootStep = new RebootStep(action, x, y, z);
Console.WriteLine(rebootStep);


// var cubesT = new HashSet<int[]>();
// cubesT.Add(new [] { 1, 2, 3 });
// cubesT.Add(new [] { 1, 1, 1 });
// cubesT.Add(new [] { 3, 2, 1 });
// cubesT.Remove(new [] { 1, 1, 1 });
// Console.WriteLine($"CubesT Steps: #{cubesT.Count}");

var cubesT = new HashSet<string>();
cubesT.Add("1,2,3");
cubesT.Add("1,1,1");
cubesT.Add("3,2,1");
cubesT.Remove("1,1,1");
Console.WriteLine($"CubesT Steps: #{cubesT.Count}");

// Part 2
// Console.WriteLine("Part 2.");


Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();

public class RebootStep
{
    public RebootStep(string action, Bounds x, Bounds y, Bounds z)
    {
        Action = action;
        X = x;
        Y = y;
        Z = z;
    }

    // private string _action;
    public string Action { get; }

    // private Bounds _x;
    public Bounds X { get; }

    // private Bounds _y;
    public Bounds Y { get; }

    // private Bounds _z;
    public Bounds Z { get; }

    public override string ToString()
    {
        return $"{Action} x={X},y={Y},z={Z}"; //on x=10..12,y=10..12,z=10..12
    }
}

public struct Bounds
{
    public Bounds(int lower, int upper)
    {
        Lower = lower;
        Upper = upper;
    }

    public double Lower { get; }
    public double Upper { get; }

    public override string ToString() => $"{Lower}..{Upper}";
}