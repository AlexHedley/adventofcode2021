Console.WriteLine("Day 11");

string[] lines = System.IO.File.ReadAllLines(@"input-sample-simple.txt");
// string[] lines = System.IO.File.ReadAllLines(@"input-sample.txt");
// string[] lines = System.IO.File.ReadAllLines(@"input.txt");

var ROWS = lines.Length;
var COLS = lines[0].Length;

var matrix = GenerateMatrix(ROWS, COLS);
PrintMatrix(matrix);
Console.WriteLine();

// Increase each by 1.
LoopMatrix(matrix);
PrintMatrix(matrix);

// Part 2
// Console.WriteLine("Part 2.");

// --- --- ---

// Testing

// Energy Level 0 -> 9
// TL matrix[0,0] 5
// BR matrix[9,9] 6
// Console.WriteLine(matrix[0,0]);
// Console.WriteLine(matrix[9,9]);

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

    var flashes = 0;

    for (int i = 0; i < rowLength; i++)
    {
        for (int j = 0; j < colLength; j++)
        {
            // Console.WriteLine($"0: {matrix[i, j]}");
            matrix[i, j] += 1;
            // Console.WriteLine($"1: {matrix[i, j]}");
            
            if (matrix[i, j] > 9)
            {
                Console.WriteLine("FLASHES");
                // Flashes
                if (i-1 > -1) // U
                {
                    matrix[i-1, j] += 1;
                    flashes++;
                }
                if (j-1 > -1) // L
                {
                    matrix[i, j-1] += 1;
                    flashes++;
                }
                if (i+1 < rowLength) // D
                {
                    matrix[i+1, j] += 1;
                    flashes++;
                }
                if (j+1 < colLength) // R
                {
                    matrix[i, j+1] += 1;
                    flashes++;
                }

                // Diagonals

                // Reset to Zero
                matrix[i, j] = 0;
            }
        }
    }
    Console.WriteLine($"flashes: {flashes}");

    PrintMatrix(matrix);
    Console.WriteLine();

    // Check each.
    if (flashes == 0)
        return;

    LoopMatrix(matrix);
}

Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();