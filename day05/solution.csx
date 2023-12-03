Console.WriteLine("Day 5");

// x1,y1 -> x2,y2
// 1,1 -> 1,3 == 1,1, 1,2, and 1,3
// 9,7 -> 7,7 == 9,7, 8,7, and 7,7
// x1 = x2 or y1 = y2

string[] lines = System.IO.File.ReadAllLines(@"input-sample.txt");
// string[] lines = System.IO.File.ReadAllLines(@"input.txt");

string[,] matrix = new string[10, 10]
{
    { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
    { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
    { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
    { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
    { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
    { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
    { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
    { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
    { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
    { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." }
};

PrintMatrix(matrix);

var coords = new List<(int row, int col)>();

var items = new List<(string, string)>();
foreach (var line in lines)
{
    (string start, string end) vents = line.Split(new char[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries) switch { var a => (a[0], a[1]) };
    // Console.WriteLine($"{ends1.end1} : {ends1.end2}");
    items.Add(vents);
}

// Console.WriteLine(items);
// items.ForEach(Console.WriteLine);
foreach (var item in items)
{
    // Console.WriteLine($"{item.Item1} : {item.Item2}");
    var start = item.Item1.Split(',');
    // Console.WriteLine($"{end1[0]} : {end1[1]}");
    var end = item.Item2.Split(',');
    // Console.WriteLine($"{end2[0]} : {end2[1]}");

    var start1 = Int32.Parse(start[0]);
    var start2 = Int32.Parse(end[0]);
    Console.WriteLine($"Start 1: {start1} : Start 2: {start2}");
    var end1 = Int32.Parse(start[1]);
    var end2 = Int32.Parse(end[1]);
    Console.WriteLine($"End 1: {end1} : End 2: {end2}");

    // var diff1 = start2 - start1;
    // var diff2 = end2 - end1;
    // Console.WriteLine($"{diff1}:{diff2} | Diff 1: {diff1} _ Diff 2: {diff2}");

    var lower = new List<int>();
    var upper = new List<int>();
    lower = BoundsRange(start1, start2);
    upper = BoundsRange(end1, end2);
    // lower.ForEach(Console.WriteLine);
    Console.WriteLine(string.Join(",", lower));
    // upper.ForEach(Console.WriteLine);
    Console.WriteLine(string.Join(",", upper));

    Console.WriteLine($"");

    foreach (var l in lower)
    {
        foreach (var u in upper)
        {
            // Console.WriteLine($"{l},{u}");
            coords.Add((l, u));
        }
    }
}

foreach (var coord in coords)
{
    // Console.WriteLine($"{coord.row},{coord.col}");
    Update(ref matrix, coord.row, coord.col);
}

PrintMatrix(matrix);

// --- --- ---



// --- --- ---

// var a = BoundsRange(0, 8);
// a.ForEach(Console.WriteLine);
// var b = BoundsRange(7, 1);
// b.ForEach(Console.WriteLine);

List<int> BoundsRange(int lower, int upper)
{
    if (lower > upper)
        return Enumerable.Range(upper, lower-upper+1).ToList();
    return Enumerable.Range(lower, upper-lower+1).ToList();
}

// Update
public void Update(ref string[,] matrix, int row, int col)
{
    var value = matrix[row, col];
    if (value == ".")
        value = "1";
    else
        value = (Convert.ToInt32(value) + 1).ToString();
    
    matrix[row, col] = value;
}

// Print Matrix
public void PrintMatrix(string[,] matrix)
{
    int rowLength = matrix.GetLength(0);
    int colLength = matrix.GetLength(1);

    for (int i = 0; i < rowLength; i++)
    {
        for (int j = 0; j < colLength; j++)
        {
            if (matrix[i, j] == ".")
                Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"{matrix[i, j]}");
            Console.ResetColor();
        }
        Console.Write(Environment.NewLine);
    }
}

// Swap
void Swap(ref int lower, ref int upper)
{
    if (lower > upper)
        SwapWithXor(ref lower, ref upper);
}

// Swap With Xor
// Swapping two numbers in C#
// https://hyr.mn/swapping-numbers/
public void SwapWithXor(ref int x, ref int y)
{
    x = x ^ y;
    y = y ^ x;
    x = x ^ y;
}

Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();
