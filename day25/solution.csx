Console.WriteLine("Day 25");

// string[] lines = System.IO.File.ReadAllLines(@"input-sample.txt");
string[] lines = System.IO.File.ReadAllLines(@"input.txt");

var EAST = '>';
var SOUTH = 'v';
var EMPTY = '.';

var ROWS = lines.Length;
var COLS = lines[0].Length;
// Console.WriteLine($"ROWS: {ROWS} | COLS: {COLS}");

var matrix = GenerateMatrix(ROWS, COLS);
PrintMatrix(matrix);
Console.WriteLine();

var i = 1;
var eastMoves = -1;
var southMoves = -1;
while (eastMoves != 0 && southMoves != 0)
{
    var eastMoves = LoopMatrixEast(matrix);
    var southMoves = LoopMatrixSouth(matrix);
    Console.WriteLine($"{i}: EastMoves #: {eastMoves} | SouthMoves #: {southMoves}");
    if (eastMoves == 0 && southMoves == 0)
        break;
    i++;
}

Console.WriteLine($"Count #: {i}");

PrintMatrix(matrix);
Console.WriteLine();

// Part 2
// Console.WriteLine("Part 2.");

// --- --- ---

// Generate Matrix
public char[,] GenerateMatrix(int rows, int cols)
{
    char[,] matrix = new char[rows, cols];
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
                matrix[i, j] = c;
                j++;
            }
        }
        a++;
    }

    return matrix;
}

// Print Matrix
// From Day04
public void PrintMatrix(char[,] matrix)
{
    int rowLength = matrix.GetLength(0);
    int colLength = matrix.GetLength(1);

    for (int i = 0; i < rowLength; i++)
    {
        for (int j = 0; j < colLength; j++)
        {
            if (matrix[i, j] == EAST || matrix[i, j] == SOUTH)
                Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{matrix[i, j]}");
            Console.ResetColor();
        }
        Console.Write(Environment.NewLine);
    }
}

// Get Moves East
public List<(int row, int col, char item)> GetMovesEast(char[,] matrix, int row, int col)
{
    var moved = new List<(int row, int col, char item)>();

    var item = matrix[row, col];
    var itemToCheck = ' ';

    switch (item.ToString())
    {
        case ">": // EAST
            var newCol = (col == COLS-1) ? 0 : col+1;
            itemToCheck = matrix[row, newCol];
            // Console.WriteLine($"{row}:{newCol} => {matrix[row, newCol]}");
            if (itemToCheck == '.')
            {
                moved.Add((row, col, EMPTY));
                moved.Add((row, newCol, EAST));
            }
            break;
        default:
            break;
    }

    return moved;
}

// Get Moves South
public List<(int row, int col, char item)> GetMovesSouth(char[,] matrix, int row, int col)
{
    var moved = new List<(int row, int col, char item)>();

    var item = matrix[row, col];
    var itemToCheck = ' ';

    switch (item.ToString())
    {
        case "v": // SOUTH
            var newRow = (row == ROWS-1) ? 0 : row+1;
            itemToCheck = matrix[newRow, col];
            if (itemToCheck == '.')
            {
                moved.Add((row, col, EMPTY));
                moved.Add((newRow, col, SOUTH));
            }
            break;
        default:
            break;
    }

    return moved;
}

// Move
public void Move(ref char[,] matrix, int row, int col, char chr)
{
    matrix[row, col] = chr;
}

// Loop Matrix (East)
public int LoopMatrixEast(char[,] matrix)
{
    var allMoves = new List<(int row, int col, char item)>();
    int rowLength = matrix.GetLength(0);
    int colLength = matrix.GetLength(1);

    for (int i = 0; i < rowLength; i++)
    {
        for (int j = 0; j < colLength; j++)
        {
            // Console.WriteLine($"{i}:{j} = {matrix[i, j]}");
            var movesEast = GetMovesEast(matrix, i, j);
            // Console.WriteLine($"E#: {movesEast.Count}");
            // movesEast.ForEach(m => Console.WriteLine($"{m.row}:{m.col}, {m.item}"));
            allMoves.AddRange(movesEast);
        }
    }
    allMoves.ForEach(m => Move(ref matrix, m.row, m.col, m.item));
    
    return allMoves.Count;
}

// Loop Matrix (South)
public int LoopMatrixSouth(char[,] matrix)
{
    var allMoves = new List<(int row, int col, char item)>();
    int rowLength = matrix.GetLength(0);
    int colLength = matrix.GetLength(1);

    for (int i = 0; i < rowLength; i++)
    {
        for (int j = 0; j < colLength; j++)
        {
            var movesSouth = GetMovesSouth(matrix, i, j);
            // Console.WriteLine($"S#: {movesSouth.Count}");
            // movesSouth.ForEach(m => Console.WriteLine($"{m.row}:{m.col}, {m.item}"));
            allMoves.AddRange(movesSouth);
        }
    }
    allMoves.ForEach(m => Move(ref matrix, m.row, m.col, m.item));

    return allMoves.Count;
}

// --- --- ---

Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();