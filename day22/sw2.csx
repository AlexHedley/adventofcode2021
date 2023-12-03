// using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

Console.WriteLine("Day 22");

// string[] lines = System.IO.File.ReadAllLines(@"input-sample.txt");
string[] lines = System.IO.File.ReadAllLines(@"input.txt");

// EXAMPLE: on x=10..12,y=10..12,z=10..12
// string pattern = "@"(on|off) (x=-?[0-9]*..-?[0-9]*),(y=-?[0-9]*..-?[0-9]*),(z=-?[0-9]*..-?[0-9]*)";
// string patternComplex = @"(on|off) (x=(\d*)..(\d*)),(y=(\d*)..(\d*)),(z=(\d*)..(\d*))";
string patternComplex = @"(on|off) (x=(-?[0-9]*)..(-?[0-9]*)),(y=(-?[0-9]*)..(-?[0-9]*)),(z=(-?[0-9]*)..(-?[0-9]*))";

List<RebootStep> rebootSteps = new List<RebootStep>();
foreach (var line in lines)
{
    var matchComplex = Regex.Match(line, patternComplex);

    var action = matchComplex.Groups[1].Value;
    var x = new Bounds(Int32.Parse(matchComplex.Groups[3].Value), Int32.Parse(matchComplex.Groups[4].Value));
    var y = new Bounds(Int32.Parse(matchComplex.Groups[6].Value), Int32.Parse(matchComplex.Groups[7].Value));
    var z = new Bounds(Int32.Parse(matchComplex.Groups[9].Value), Int32.Parse(matchComplex.Groups[10].Value));
    var rebootStep = new RebootStep(action, x, y, z);
    Console.WriteLine(rebootStep);
    if (rebootStep.IsValid())
    {
        Console.WriteLine($"IsValid");
        rebootSteps.Add(rebootStep);
    }
}

Console.WriteLine($"Reboot Steps: #{rebootSteps.Count}");

var cubes = new HashSet<string>();
foreach (var rebootStep in rebootSteps)
{
    switch (rebootStep.Action)
    {
        case "on":
            // Console.WriteLine("on");
            // var on = cubes.Union(rebootStep.Perms());
            // cubes = on.ToList();
            rebootStep.PermsString().ForEach(x => { var added = cubes.Add(x); });
            break;
        case "off":
            // Console.WriteLine("off");
            // var off = cubes.Except(rebootStep.Perms());
            // cubes = off.ToList();
            rebootStep.PermsString().ForEach(x => { cubes.Remove(x); });
            break;
        default:
            Console.WriteLine($"No matching action: {rebootStep.Action}");
            break;
    }
    Console.WriteLine($"Cubes Steps: #{cubes.Count}");
}

Console.WriteLine($"Final Cubes Steps: #{cubes.Count}");
// cubes.Distinct().ToList().ForEach(x => { Console.WriteLine(string.Join(",", x)); });

// Part 2
// Console.WriteLine("Part 2.");

Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();

// ---

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

    public List<int> XRange { get { return BoundsRange(X); } }
    public List<int> YRange { get { return BoundsRange(Y); } }
    public List<int> ZRange { get { return BoundsRange(Z); } }

    // public List<int[]> XPermutations { get { return XRange.Permutations().ToList(); } }
    // public List<int[]> YPermutations { get { return YRange.Permutations().ToList(); } }
    // public List<int[]> ZPermutations { get { return ZRange.Permutations().ToList(); } }

    // public List<int[]> Perms()
    // {
    //     var list = new List<int[]>();

    //     // Update this...
    //     foreach (var x in XRange)
    //     {
    //         foreach (var y in YRange)
    //         {
    //             foreach (var z in ZRange)
    //             {
    //                 list.Add(new [] { x, y, z });
    //             }
    //         }
    //     }

    //     return list;
    // }

    public List<string> PermsString()
    {
        var list = new List<string>();

        foreach (var x in XRange)
        {
            foreach (var y in YRange)
            {
                foreach (var z in ZRange)
                {
                    list.Add($"{x},{y},{z}");
                }
            }
        }

        return list;
    }

    List<int> BoundsRange(Bounds x)
    {
        return Enumerable.Range(x.Lower, x.Upper-x.Lower+1).ToList();
    }

    // on x=1947..32687,y=-15868..-4827,z=74913..89456

    public bool IsValid()
    {
        if ((X.Lower > -51 && X.Lower < 51) && (X.Upper > -51 && X.Upper < 51))
            return true;
        if ((Y.Lower > -51 && Y.Lower < 51) && (Y.Upper > -51 && Y.Upper < 51))
            return true;
        if ((Z.Lower > -51 && Z.Lower < 51) && (Z.Upper > -51 && Z.Upper < 51))
            return true;
        return false;
    }
}

public struct Bounds
{
    public Bounds(int lower, int upper)
    {
        Lower = lower;
        Upper = upper;
    }

    public int Lower { get; }
    public int Upper { get; }

    public override string ToString() => $"{Lower}..{Upper}";
}

// https://stackoverflow.com/a/58826787/2895831
// https://stackoverflow.com/a/53039741/2895831 - error CS1109: Extension methods must be defined in a top level static class; PermutationExtension is a nested class
// public static class PermutationExtension
// {
    public static IEnumerable<T[]> Permutations<T>(this IEnumerable<T> source)
    {
        var sourceArray = source.ToArray();
        var results = new List<T[]>();
        Permute(sourceArray, 0, sourceArray.Length - 1, results);
        return results;
    }

    private static void Swap<T>(ref T a, ref T b)
    {
        T tmp = a;
        a = b;
        b = tmp;
    }

    private static void Permute<T>(T[] elements, int recursionDepth, int maxDepth, ICollection<T[]> results)
    {
        if (recursionDepth == maxDepth)
        {
            results.Add(elements.ToArray());
            return;
        }

        for (var i = recursionDepth; i <= maxDepth; i++)
        {
            Swap(ref elements[recursionDepth], ref elements[i]);
            Permute(elements, recursionDepth + 1, maxDepth, results);
            Swap(ref elements[recursionDepth], ref elements[i]);
        }
    }
// }