Console.WriteLine("Day 23");

// Amber (A)    1
// Bronze (B)   10
// Copper (C)   100
// Desert (D)   1000

// walls (#)
// open space (.)

// #############
// #...........#
// ###B#C#B#D###
//   #A#D#C#A#
//   #########

// =>

// #############
// #...........#
// ###A#B#C#D###
//   #A#B#C#D#
//   #########

string[] lines = System.IO.File.ReadAllLines(@"input-sample.txt");
// string[] lines = System.IO.File.ReadAllLines(@"input.txt");

// char[,] matrix = new char[5, 13]
// {
//     { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
//     { '#', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '#' },
//     { '#', '#', '#', 'B', '#', 'C', '#', 'B', '#', 'D', '#', '#', '#' },
//     { ' ', ' ', '#', 'A', '#', 'D', '#', 'C', '#', 'A', '#', ' ', ' ' },
//     { ' ', ' ', '#', '#', '#', '#', '#', '#', '#', '#', '#', ' ', ' ' }
// };

int i = 0, j = 0;
char[,] matrix = new char[5, 13];
foreach (var row in lines)
{
    j = 0;
    foreach (var col in row.ToCharArray())
    {
        matrix[i, j] = col;
        j++;
    }
    i++;
}

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


// Part 2
// Console.WriteLine("Part 2.");


Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();