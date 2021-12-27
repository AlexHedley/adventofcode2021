Console.WriteLine("Day 9");

// string[] lines = System.IO.File.ReadAllLines(@"input-sample.txt");
string[] lines = System.IO.File.ReadAllLines(@"input.txt");

var ROWS = lines.Length;
var COLS = lines[0].Length;

var matrix = GenerateMatrix(ROWS, COLS);
PrintMatrix(matrix);
Console.WriteLine();

// LoopMatrix(matrix);

var lowestPoints = GetLowestPoints(matrix);
lowestPoints.ForEach(x => Console.WriteLine($"{x.row}:{x.col} | {matrix[x.row,x.col]}"));

var heat = 0;
foreach(var point in lowestPoints)
{
    heat += matrix[point.row,point.col];
}
heat += lowestPoints.Count;

Console.WriteLine($"Heat Sum: {heat}");

// foreach(var point in lowestPoints)
// {
//     PrintMatching(ref matrix, point.row, point.col);
//     Console.WriteLine();
// }

// --- --- ---

// Generate Matrix
public int[,] GenerateMatrix(int rows, int cols)
{
    int[,] matrix = new int[rows, cols];
    int rowLength = matrix.GetLength(0);
    int colLength = matrix.GetLength(1);

    var a = 0;
    for (var i = 0; i < rowLength; i++)
    {
        for (var j = 0; j < colLength; j++)
        {
            foreach (char c in lines[a].ToCharArray())
            {
                // Console.WriteLine(c);
                matrix[i, j] = int.Parse(c.ToString());
                j++;
            }
        }
        a++;
    }

    return matrix;
}

// Print Matrix
public void PrintMatrix(int[,] matrix)
{
    int rowLength = matrix.GetLength(0);
    int colLength = matrix.GetLength(1);

    for (int i = 0; i < rowLength; i++)
    {
        for (int j = 0; j < colLength; j++)
        {
            Console.Write($"{matrix[i, j]}");
        }
        Console.Write(Environment.NewLine);
    }
}

// Loop Matrix
public void LoopMatrix(int[,] matrix)
{
    int rowLength = matrix.GetLength(0);
    int colLength = matrix.GetLength(1);

    for (int i = 0; i < rowLength; i++)
    {
        for (int j = 0; j < colLength; j++)
        {
            Console.Write(matrix[i, j]);
        }
    }
}

// Get Lowest Points
public List<(int row, int col)> GetLowestPoints(int[,] matrix)
{
    var lowestPoints = new List<(int row, int col)>();

    int rowLength = matrix.GetLength(0);
    int colLength = matrix.GetLength(1);

    for (int i = 0; i < rowLength; i++)
    {
        for (int j = 0; j < colLength; j++)
        {
            // Console.Write(matrix[i, j]);
            var currentValue = matrix[i, j];
            // Console.WriteLine($"{currentValue} | {i}:{j}");

            var adjecents = new List<int>();
            var top = -1;
            var left = -1;
            var bottom = -1;
            var right = -1;

            // 0 0
            if (i-1 > -1)
            {
                top = matrix[i-1, j];
                adjecents.Add(top);
            }
            if (j-1 > -1)
            {
                left = matrix[i, j-1];
                adjecents.Add(left);
            }
            if (i+1 < rowLength)
            {
                bottom = matrix[i+1, j];
                adjecents.Add(bottom); 
            }
            if (j+1 < colLength)
            {
                right = matrix[i, j+1];
                adjecents.Add(right);
            }

            // Console.WriteLine($"T:{top} | L:{left} | B:{bottom} | R:{right}");
            // adjecents.ForEach(Console.WriteLine);
            // Console.WriteLine($"{string.Join(", ", adjecents)}");

            // Are these numbers great than current.
            var lowestPoint = adjecents.All(x => x > currentValue);
            if (lowestPoint)
            {
                lowestPoints.Add((i, j));
            }

        }
    }
    
    return lowestPoints;
}

// Print Matching
public void PrintMatching(ref int[,] matrix, int row, int col)
{
    int rowLength = matrix.GetLength(0);
    int colLength = matrix.GetLength(1);

    for (int i = 0; i < rowLength; i++)
    {
        for (int j = 0; j < colLength; j++)
        {
            if (i == row && j == col)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{matrix[i, j]}");
                Console.ResetColor();
            }
            else
            {
                Console.Write($"{matrix[i, j]}");
            }
        }
        Console.Write(Environment.NewLine);
    }
    
}

// Part 2
// Console.WriteLine("Part 2.");

Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();