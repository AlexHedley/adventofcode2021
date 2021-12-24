Console.WriteLine("Day 4");

// string[] lines = System.IO.File.ReadAllLines(@"input-sample.txt");
string[] lines = System.IO.File.ReadAllLines(@"input.txt");

lines = lines.Where(x => !string.IsNullOrEmpty(x)).ToArray();
// lines.ToList().ForEach(Console.WriteLine);

// var drawnNumbers = lines[0].Split(',');
// Console.WriteLine($"Drawn Numbers: {drawnNumbers.Length}");
List<int> drawnNumbers = lines[0].Split(',').Select(i => Int32.Parse(i)).ToList();
Console.WriteLine($"Drawn Numbers: {drawnNumbers.Count}");
// drawnNumbers.ToList().ForEach(Console.WriteLine);

var allBoards = lines.ToList();
allBoards.RemoveAt(0);

var LINES_IN_BOARD = 5;
var SWAP_NUMBER = 0;

var numOfBoards = allBoards.Count/LINES_IN_BOARD;
Console.WriteLine($"Num Of Boards: {numOfBoards}");

var boards = new List<int[,]>();
var a = 0;

for (var i = 0; i < numOfBoards; i++)
{
    int k = 0, l = 0;
    int[,] matrix = new int[5, 5];

    for (var j = 0; j < LINES_IN_BOARD; j++)
    {
        l = 0;
        
        foreach (var col in allBoards[a].Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            matrix[k, l] = Int32.Parse(col);
            l++;
        }
        k++;
        
        a++;
    }
    boards.Add(matrix);
    //PrintMatrix(matrix);
}

boards.ToList().ForEach(x => { PrintMatrix(x); Console.WriteLine(); } );

// --- --- ---

Dictionary<int, bool> complete = new Dictionary<int, bool>();
// boards.ToList().ForEach(x => complete.Add(););

for (var i = 0; i < numOfBoards; i++)
{
    complete.Add(i, false);
}
var c = complete.Select(kvp => kvp.Key + ": " + kvp.Value.ToString());
Console.WriteLine($"Dictionary: {string.Join(Environment.NewLine, c)}");

// Loop through each number and check if it's on any board.
foreach (var drawnNumber in drawnNumbers)
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine($"Drawn Number: {drawnNumber}");
    Console.ResetColor();

    // foreach (var board in boards)
    for (var i = 0; i < numOfBoards; i++)
    {
        var exists = Exists(boards[i], drawnNumber);
        PrintMatrix(boards[i]);
        Console.Write(Environment.NewLine);

        var winner = IsWinner(boards[i]);
        if (winner)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Winner: {i+1}");

            int sum = boards[i].Cast<int>().Sum();
            Console.WriteLine($"Sum: {sum}");

            int total = sum * drawnNumber;
            Console.WriteLine($"Total: {total} ({sum}*{drawnNumber})");

            Console.ResetColor();

            complete[i] = true;

            var allCompleted = complete.Values.All(c=> c == true);
            if (allCompleted)
                goto End;
        }
    }
}
End: Console.WriteLine($"Done");

// --- --- ---

public bool IsWinner(int[,] matrix)
{
    int rowLength = matrix.GetLength(0);
    int colLength = matrix.GetLength(1);

    for (var i = 0; i < rowLength; i++)
    {
        var row = GetRow(matrix, i);
        var matches = AllMatches(row);
        if (matches) return true;
    }

    for (var j = 0; j < colLength; j++)
    {
        var col = GetColumn(matrix, j);
        var matches = AllMatches(col);
        if (matches) return true;
    }
    
    return false;
}

// public T[] GetColumn(T[,] matrix, int columnNumber)
public int[] GetColumn(int[,] matrix, int columnNumber)
{
    return Enumerable.Range(0, matrix.GetLength(0))
            .Select(x => matrix[x, columnNumber])
            .ToArray();
}

// public T[] GetRow(T[,] matrix, int rowNumber)
public int[] GetRow(int[,] matrix, int rowNumber)
{
    return Enumerable.Range(0, matrix.GetLength(1))
            .Select(x => matrix[rowNumber, x])
            .ToArray();
}

public bool AllMatches(int[] array, int match = -1)
{
    return array.Distinct().Count() == 1;
}

public bool Exists(int[,] matrix, int value)
{
    int rowLength = matrix.GetLength(0);
    int colLength = matrix.GetLength(1);

    for (var i = 0; i < rowLength; i++)
    {
        for (var j = 0; j < colLength; j++)
        {
            // Console.WriteLine(matrix[i, j]);
            if (value == matrix[i, j])
            {
                // Console.WriteLine($"Position: [{i},{j}]");
                matrix[i, j] = SWAP_NUMBER;
                return true;
            }
        }
    }
    return false;
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
            if (matrix[i, j] == SWAP_NUMBER)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{matrix[i, j]} ");
            Console.ResetColor();
        }
        Console.Write(Environment.NewLine);
    }
}

// --- --- ---

// Part 2
// Console.WriteLine("Part 2.");

Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();
