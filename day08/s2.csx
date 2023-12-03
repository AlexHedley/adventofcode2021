Console.WriteLine("Day 8");

// string[] lines = System.IO.File.ReadAllLines(@"input-sample.txt");
// string[] lines = System.IO.File.ReadAllLines(@"input-sample-2.txt");
string[] lines = System.IO.File.ReadAllLines(@"input.txt");

// List<(int num, int segments)> display = new List<(int num, int segments)>() { (0, 6), (1, 2), (2, 5), (3, 5), (4, 4), (5, 5), (6, 6), (7, 3), (8, 7), (9, 6) };

var numbers = new List<(int number, int count, List<char> segments)>();
numbers.Add((0, 6, new List<char>{ 'a', 'b', 'c', 'e', 'f', 'g' }));
numbers.Add((1, 2, new List<char>{ 'c', 'f' }));
numbers.Add((2, 5, new List<char>{ 'a', 'c', 'd', 'e', 'g' }));
numbers.Add((3, 5, new List<char>{ 'a', 'c', 'd', 'f', 'g' }));
numbers.Add((4, 4, new List<char>{ 'b', 'c', 'd', 'f' }));
numbers.Add((5, 5, new List<char>{ 'a', 'b', 'd', 'f', 'g' }));
numbers.Add((6, 6, new List<char>{ 'a', 'b', 'd', 'e', 'f', 'g' }));
numbers.Add((7, 3, new List<char>{ 'a', 'c', 'f' }));
numbers.Add((8, 7, new List<char>{ 'a', 'b', 'c', 'd', 'e', 'f', 'g'}));
numbers.Add((9, 6, new List<char>{ 'a', 'b', 'c', 'd', 'f', 'g' }));

var uniqueNumbers = new List<int>();

// var uniqueSignalPatterns = items[0].Split(' ', StringSplitOptions.TrimEntries).ToList();
// uniqueSignalPatterns.ForEach(Console.WriteLine);

// foreach (var usp in uniqueSignalPatterns)
// {
    // var matching  = numbers.Where(x => x.count == usp.Length).Select(x => x).ToList();
    // Console.Write($"{usp}: {usp.Length} - Matching: {matching.Count}");
    // if (matching.Count == 1)
    // {
    //     Console.Write($" | {string.Join("", matching[0].segments)} | {matching[0].number}");
    //     uniqueNumbers.Add(matching[0].number);
    // }
    // Console.WriteLine();
// }

for(var i = 0; i < lines.Length; i++)
{
    List<string> items = lines[i].Split('|', StringSplitOptions.TrimEntries).ToList();
    // items.ForEach(Console.WriteLine);
    // Console.WriteLine($"Items #:{items.Count}");

    var outputs = items[1].Split(' ', StringSplitOptions.TrimEntries).ToList();
    // outputs.ForEach(Console.WriteLine);
    // Console.WriteLine($"Outputs #:{outputs.Count}");
    // outputs.ForEach(x => Console.WriteLine(x.Length));

    uniqueNumbers.AddRange(UniqueNumbers(outputs));
}

Console.WriteLine($"#: {uniqueNumbers.Count}");

// uniqueNumbers.ForEach(Console.WriteLine);
Console.WriteLine(string.Join(", ", uniqueNumbers.Distinct().OrderBy(n => n).ToList()));

// --- --- ---

// Unique Numbers
public List<int> UniqueNumbers(List<string> outputs)
{
    var foundNumbers = new List<int>();

    foreach (var output in outputs)
    {
        var matching  = numbers.Where(x => x.count == output.Length).Select(x => x).ToList();
        // Console.Write($"{output}: {output.Length} - Matching: {matching.Count}");
        if (matching.Count == 1)
        {
            // Console.Write($" | {string.Join("", matching[0].segments)} | {matching[0].number}");
            foundNumbers.Add(matching[0].number);
        }
        // Console.WriteLine();
    }

    // foundNumbers.ForEach(Console.WriteLine);
    // Console.WriteLine(string.Join(", ", foundNumbers));

    return foundNumbers;
}

// --- --- ---

// Testing

// var matching  = numbers.Where(x => x.count == 2).Select(x => x).ToList(); // var matching  = numbers.Select(x => x.count == 2).ToList();
// Console.WriteLine($"Matching: {matching.Count}");

// --- --- ---

// Part 2
Console.WriteLine("Part 2.");

var zeroDigit = new char[,] {
        { ' ', '1', '1', '1', '1', ' ' },
        { '2', ' ', ' ', ' ', ' ', '3' },
        { '2', ' ', ' ', ' ', ' ', '3' },
        { ' ', '.', '.', '.', '.', ' ' },
        { '5', ' ', ' ', ' ', ' ', '6' },
        { '5', ' ', ' ', ' ', ' ', '6' },
        { ' ', '7', '7', '7', '7', ' ' },
    };

var oneDigit = new char[,] {
        { ' ', '.', '.', '.', '.', ' ' },
        { '.', ' ', ' ', ' ', ' ', '3' },
        { '.', ' ', ' ', ' ', ' ', '3' },
        { ' ', '.', '.', '.', '.', ' ' },
        { '.', ' ', ' ', ' ', ' ', '6' },
        { '.', ' ', ' ', ' ', ' ', '6' },
        { ' ', '.', '.', '.', '.', ' ' },
    };

var twoDigit = new char[,] {
        { ' ', '1', '1', '1', '1', ' ' },
        { '.', ' ', ' ', ' ', ' ', '3' },
        { '.', ' ', ' ', ' ', ' ', '3' },
        { ' ', '4', '4', '4', '4', ' ' },
        { '5', ' ', ' ', ' ', ' ', '.' },
        { '5', ' ', ' ', ' ', ' ', '.' },
        { ' ', '7', '7', '7', '7', ' ' },
    };

var threeDigit = new char[,] {
        { ' ', '1', '1', '1', '1', ' ' },
        { '.', ' ', ' ', ' ', ' ', '3' },
        { '.', ' ', ' ', ' ', ' ', '3' },
        { ' ', '4', '4', '4', '4', ' ' },
        { '.', ' ', ' ', ' ', ' ', '6' },
        { '.', ' ', ' ', ' ', ' ', '6' },
        { ' ', '7', '7', '7', '7', ' ' },
    };

var fourDigit = new char[,] {
        { ' ', '.', '.', '.', '.', ' ' },
        { '2', ' ', ' ', ' ', ' ', '3' },
        { '2', ' ', ' ', ' ', ' ', '3' },
        { ' ', '4', '4', '4', '4', ' ' },
        { '.', ' ', ' ', ' ', ' ', '6' },
        { '.', ' ', ' ', ' ', ' ', '6' },
        { ' ', '.', '.', '.', '.', ' ' },
    };

var fiveDigit = new char[,] {
        { ' ', '1', '1', '1', '1', ' ' },
        { '2', ' ', ' ', ' ', ' ', '.' },
        { '2', ' ', ' ', ' ', ' ', '.' },
        { ' ', '4', '4', '4', '4', ' ' },
        { '.', ' ', ' ', ' ', ' ', '6' },
        { '.', ' ', ' ', ' ', ' ', '6' },
        { ' ', '7', '7', '7', '7', ' ' },
    };

var sixDigit = new char[,] {
        { ' ', '1', '1', '1', '1', ' ' },
        { '2', ' ', ' ', ' ', ' ', '.' },
        { '2', ' ', ' ', ' ', ' ', '.' },
        { ' ', '4', '4', '4', '4', ' ' },
        { '5', ' ', ' ', ' ', ' ', '6' },
        { '5', ' ', ' ', ' ', ' ', '6' },
        { ' ', '7', '7', '7', '7', ' ' },
    };

var sevenDigit = new char[,] {
        { ' ', '1', '1', '1', '1', ' ' },
        { '.', ' ', ' ', ' ', ' ', '3' },
        { '.', ' ', ' ', ' ', ' ', '3' },
        { ' ', '.', '.', '.', '.', ' ' },
        { '.', ' ', ' ', ' ', ' ', '6' },
        { '.', ' ', ' ', ' ', ' ', '6' },
        { ' ', '.', '.', '.', '.', ' ' },
    };

var eightDigit = new char[,] {
        { ' ', '1', '1', '1', '1', ' ' },
        { '2', ' ', ' ', ' ', ' ', '3' },
        { '2', ' ', ' ', ' ', ' ', '3' },
        { ' ', '4', '4', '4', '4', ' ' },
        { '5', ' ', ' ', ' ', ' ', '6' },
        { '5', ' ', ' ', ' ', ' ', '6' },
        { ' ', '7', '7', '7', '7', ' ' },
    };

var nineDigit = new char[,] {
        { ' ', '1', '1', '1', '1', ' ' },
        { '2', ' ', ' ', ' ', ' ', '3' },
        { '2', ' ', ' ', ' ', ' ', '3' },
        { ' ', '4', '4', '4', '4', ' ' },
        { '.', ' ', ' ', ' ', ' ', '6' },
        { '.', ' ', ' ', ' ', ' ', '6' },
        { ' ', '7', '7', '7', '7', ' ' },
    };

var numbersArray = new List<char[,]>() {
    zeroDigit, oneDigit, twoDigit, threeDigit, fourDigit, fiveDigit, sixDigit, sevenDigit, eightDigit, nineDigit
};

// numbersArray.ToList().ForEach(x => { PrintMatrix(x); Console.WriteLine(); } );

var numberMappings = new List<(int number, int count, List<char> segments)>();
numberMappings.Add((0, 6, GetNumbers(zeroDigit))); // new List<char>{ '1', '2', '3', '5', '6', '7' }
numberMappings.Add((1, 2, GetNumbers(oneDigit))); // new List<char>{ '3', '6' }
numberMappings.Add((2, 5, GetNumbers(twoDigit))); // new List<char>{ '1', '3', '4', '5', '7' }
numberMappings.Add((3, 5, GetNumbers(threeDigit))); // new List<char>{ '1', '3', '4', '6', '7' }
numberMappings.Add((4, 4, GetNumbers(fourDigit))); // new List<char>{ '2', '3', '4', '6' }
numberMappings.Add((5, 5, GetNumbers(fiveDigit))); // new List<char>{ '1', '2', '4', '6', '7' }
numberMappings.Add((6, 6, GetNumbers(sixDigit))); // new List<char>{ '1', '2', '4', '5', '6', '7' }
numberMappings.Add((7, 3, GetNumbers(sevenDigit))); // new List<char>{ '1', '3', '6' }
numberMappings.Add((8, 7, GetNumbers(eightDigit))); // new List<char>{ '1', '2', '3', '4', '5', '6', '7'}
numberMappings.Add((9, 6, GetNumbers(nineDigit))); // new List<char>{ '1', '2', '3', '4', '6', '7' }
// numberMappings.ForEach(x => Console.WriteLine(string.Join(", ", x.segments)));

string[] inputSample = System.IO.File.ReadAllLines(@"input-sample.txt");
List<string> items = inputSample[0].Split('|', StringSplitOptions.TrimEntries).ToList();
var uniqueSignalPatterns = items[0].Split(' ', StringSplitOptions.TrimEntries).ToList();
// uniqueSignalPatterns.ForEach(Console.WriteLine);

var one = "";
var two = "";
var three = "";
var four = "";
var five = "";
var six = "";
var seven = "";
var eight = "";
var nine = "";

foreach(var usp in uniqueSignalPatterns)
{
    // Number 1 4 7 8
    // Count  2 4 3 7
    switch (usp.Length) {
        case 2: // 1
            one = usp;
            break;
        case 3: // 7
            seven = usp;
            break;
        case 4: // 4
            four = usp;
            break;
        case 7: // 8
            eight = usp;
            break;
        default:
            break;
    }
}

Console.WriteLine($"1:{one} | 7:{seven} | 4:{four} | 8:{eight}");

var matchingOne = numberMappings.Where(x => x.count == 2).FirstOrDefault();
Console.WriteLine($"{matchingOne.number} | {string.Join(" ", matchingOne.segments)} | #:{matchingOne.count}");
var oneLetters = one.ToCharArray();
Console.WriteLine(string.Join(" ", oneLetters));

var checks = new List<List<char[,]>>();
var numbersMatrix = new List<char[,]>() { zeroDigit, oneDigit, twoDigit, threeDigit, fourDigit, fiveDigit, sixDigit, sevenDigit, eightDigit, nineDigit };

UpdateNumberOne();

foreach(var check in checks)
{
    PrintNumbers(check);
}


public void UpdateNumberOne()
{
    var a = 0;
    for (var i = 0; i < matchingOne.segments.Count; i++) // 3 6
    {
        Console.WriteLine($"a: {a} | i: {i}");
        
        // Console.WriteLine("ZERO");
        // PrintMatrix(zeroDigit);
        // Console.WriteLine("OREZ");

        // PrintNumbers(numbersMatrix);

        var numbers = new List<char[,]>(numbersMatrix);

        Console.WriteLine($"Number:{matchingOne.segments[0+a]} | Letter:{oneLetters[0]}");
        // swap all 3(c) with a | swap all 6(f) with b
        // a = 3 | b = 6
        // numbersMatrix.ForEach(m => FindAndSwapInMatrix(ref m, matchingOne.segments[0+a], oneLetters[0]));
        numbers = FindAndSwapInMatrix(numbers, matchingOne.segments[0+a], oneLetters[0]);

        Console.WriteLine($"Number:{matchingOne.segments[1-a]} | Letter:{oneLetters[1]}");
        // swap all 3(c) with b | swap all 6(f) with a
        // b = 3 | a = 6
        // numbersMatrix.ForEach(m => FindAndSwapInMatrix(ref m, matchingOne.segments[1-a], oneLetters[1]));
        numbers = FindAndSwapInMatrix(numbers, matchingOne.segments[1-a], oneLetters[1]);
        
        checks.Add(numbers);
        
        a+=1;
        Console.WriteLine("--- --- ---");
    }
}

// a a     b b
// 0 0     1 1
// 3 a     6 b

// b a     a b
// 1 0     0 1
// 6 a     3 b

Console.WriteLine();

// --- --- ---

// Print Numbers
public void PrintNumbers(List<char[,]> numbers)
{
    numbers.ForEach(x => { PrintMatrix(x); Console.WriteLine(""); } );

    // foreach (var number in numbers)
    // {
    //     PrintMatrix(number);
    // }
    Console.WriteLine("--- --- ---");
}

// Print Matrix
public void PrintMatrix(char[,] matrix)
{
    int rowLength = matrix.GetLength(0);
    int colLength = matrix.GetLength(1);

    for (int i = 0; i < rowLength; i++)
    {
        for (int j = 0; j < colLength; j++)
        {
            if (matrix[i, j] != '.' || matrix[i, j] != ' ')
                Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{matrix[i, j]}");
            Console.ResetColor();
        }
        Console.Write(Environment.NewLine);
    }
}

// Get Numbers
public List<char> GetNumbers(char[,] digit)
{
    var distinctValues = digit.Cast<char>().Distinct().ToList();
    var removeSpace = distinctValues.SingleOrDefault(r => r == ' ');
    if (removeSpace != 0)
        distinctValues.Remove(removeSpace);
    var removeDot = distinctValues.SingleOrDefault(r => r == '.');
    if (removeDot != 0)
        distinctValues.Remove(removeDot);
    
    // distinctValues.ToList().ForEach(Console.WriteLine);
    // Console.WriteLine(string.Join(", ", distinctValues));

    return distinctValues;
}

// Find And Swap In Matrix
public List<char[,]> FindAndSwapInMatrix(List<char[,]> numbers, char itemToFind, char replaceWith)
{
    List<char[,]> newNumbers = new List<char[,]>();

    foreach(var matrix in numbers)
    {
        char[,] newMatrix = matrix.Clone() as char[,];
        
        int rowLength = matrix.GetLength(0);
        int colLength = matrix.GetLength(1);
        
        for (int i = 0; i < rowLength; i++)
        {
            for (int j = 0; j < colLength; j++)
            {
                if (newMatrix[i,j] == itemToFind)
                    newMatrix[i,j] = replaceWith;
            }
        }

        newNumbers.Add(newMatrix);
    }
    return newNumbers;
}

//  aaaa    ....    aaaa    aaaa    ....    aaaa    aaaa    aaaa    aaaa    aaaa
// b    c  .    c  .    c  .    c  b    c  b    .  b    .  .    c  b    c  b    c
// b    c  .    c  .    c  .    c  b    c  b    .  b    .  .    c  b    c  b    c
//  ....    ....    dddd    dddd    dddd    dddd    dddd    ....    dddd    dddd
// e    f  .    f  e    .  .    f  .    f  .    f  e    f  .    f  e    f  .    f
// e    f  .    f  e    .  .    f  .    f  .    f  e    f  .    f  e    f  .    f
//  gggg    ....    gggg    gggg    ....    gggg    gggg    ....    gggg    gggg

// aaaa      dddd
//b    c    e    a
//b    c    e    a
// dddd      ffff
//e    f    g    b
//e    f    g    b
// gggg      cccc 

// a => d
// b => e
// c => a
// d => f
// e => g
// f => b
// g => c

//   0:      1:      2:      3:      4:      5:      6:      7:      8:      9:
//  aaaa    ....    aaaa    aaaa    ....    aaaa    aaaa    aaaa    aaaa    aaaa
// b    c  .    c  .    c  .    c  b    c  b    .  b    .  .    c  b    c  b    c
// b    c  .    c  .    c  .    c  b    c  b    .  b    .  .    c  b    c  b    c
//  ....    ....    dddd    dddd    dddd    dddd    dddd    ....    dddd    dddd
// e    f  .    f  e    .  .    f  .    f  .    f  e    f  .    f  e    f  .    f
// e    f  .    f  e    .  .    f  .    f  .    f  e    f  .    f  e    f  .    f
//  gggg    ....    gggg    gggg    ....    gggg    gggg    ....    gggg    gggg

// acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf
//    8                       7                 4          1  |

// Cominations

// 1 & 7 - (a b) d

//   0:      1:      2:      3:      4:      5:      6:      7:      8:      9:
//  dddd    ....    dddd    dddd    ....    dddd    dddd    dddd    dddd    dddd
// #    a  .    a  .    a  .    a  #    a  #    .  #    .  .    a  #    a  #    a
// #    a  .    a  .    a  .    a  #    a  #    .  #    .  .    a  #    a  #    a
//  ....    ....    ####    ####    ####    ####    ####    ....    ####    ####
// #    b  .    b  #    .  .    b  .    b  .    b  #    b  .    b  #    b  .    b
// #    b  .    b  #    .  .    b  .    b  .    b  #    b  .    b  #    b  .    b
//  ####    ....    ####    ####    ....    ####    ####    ....    ####    ####

// 4 - ((a b) d) e f

//  dddd    ....    dddd    dddd    ....    dddd    dddd    dddd    dddd    dddd
// e    a  .    a  .    a  .    a  e    a  e    .  e    .  .    a  e    a  e    a
// e    a  .    a  .    a  .    a  e    a  e    .  e    .  .    a  e    a  e    a
//  ....    ....    ffff    ffff    ffff    ffff    ffff    ....    ffff    ffff
// #    b  .    b  #    .  .    b  .    b  .    b  #    b  .    b  #    b  .    b
// #    b  .    b  #    .  .    b  .    b  .    b  #    b  .    b  #    b  .    b
//  ####    ....    ####    ####    ....    ####    ####    ....    ####    ####

//  dddd    ....    dddd    dddd    ....    dddd    dddd    dddd    dddd    dddd
// e    a  .    a  .    a  .    a  e    a  e    .  e    .  .    a  e    a  e    a
// e    a  .    a  .    a  .    a  e    a  e    .  e    .  .    a  e    a  e    a
//  ....    ....    ffff    ffff    ffff    ffff    ffff    ....    ffff    ffff
// #    b  .    b  #    .  .    b  .    b  .    b  #    b  .    b  #    b  .    b
// #    b  .    b  #    .  .    b  .    b  .    b  #    b  .    b  #    b  .    b
//  ####    ....    ####    ####    ....    ####    ####    ....    ####    ####

// 8 - ((a b) d) e f | acedgfb => adefb cg 

//  dddd    ....    dddd    dddd    ....    dddd    dddd    dddd    dddd    dddd
// e    a  .    a  .    a  .    a  e    a  e    .  e    .  .    a  e    a  e    a
// e    a  .    a  .    a  .    a  e    a  e    .  e    .  .    a  e    a  e    a
//  ....    ....    ffff    ffff    ffff    ffff    ffff    ....    ffff    ffff
// c    b  .    b  c    .  .    b  .    b  .    b  c    b  .    b  c    b  .    b
// c    b  .    b  c    .  .    b  .    b  .    b  c    b  .    b  c    b  .    b
//  gggg    ....    gggg    gggg    ....    gggg    gggg    ....    gggg    gggg

//  dddd    ....    dddd    dddd    ....    dddd    dddd    dddd    dddd    dddd
// e    a  .    a  .    a  .    a  e    a  e    .  e    .  .    a  e    a  e    a
// e    a  .    a  .    a  .    a  e    a  e    .  e    .  .    a  e    a  e    a
//  ....    ....    ffff    ffff    ffff    ffff    ffff    ....    ffff    ffff
// g    b  .    b  g    .  .    b  .    b  .    b  g    b  .    b  g    b  .    b
// g    b  .    b  g    .  .    b  .    b  .    b  g    b  .    b  g    b  .    b
//  cccc    ....    cccc    cccc    ....    cccc    cccc    ....    cccc    cccc

//            2       3       5
// cdfbe    dafcg | dafbg | defbg       bcdef    acdfg  abdfh bdefg
// gcdfa    dafcg | dafbg | defbg       acdfg   *acdfg* abdfh bdefg
// fbcad    dafcg | dafbg | defbg       abcdf    acdfg  abdfh bdefg

//            2       3       5
// cdfbe    dafgc | dafbc | defbc       bcdef    acdfg  abcdf *bcdef*
// gcdfa    dafgc | dafbc | defbc       acdfg   *acdfg* abcdf  bcdef
// fbcad    dafgc | dafbc | defbc       abcdf    acdfg *abcdf* bcdef

// 4 - ((a b) d) f e

//  dddd    ....    dddd    dddd    ....    dddd    dddd    dddd    dddd    dddd
// f    a  .    a  .    a  .    a  f    a  f    .  f    .  .    a  f    a  f    a
// f    a  .    a  .    a  .    a  f    a  f    .  f    .  .    a  f    a  f    a
//  ....    ....    eeee    eeee    eeee    eeee    eeee    ....    eeee    eeee
// #    b  .    b  #    .  .    b  .    b  .    b  #    b  .    b  #    b  .    b
// #    b  .    b  #    .  .    b  .    b  .    b  #    b  .    b  #    b  .    b
//  ####    ....    ####    ####    ....    ####    ####    ....    ####    ####

// 8 - ((a b) d) f e | acedgfb => adefb cg

//  dddd    ....    dddd    dddd    ....    dddd    dddd    dddd    dddd    dddd
// f    a  .    a  .    a  .    a  f    a  f    .  f    .  .    a  f    a  f    a
// f    a  .    a  .    a  .    a  f    a  f    .  f    .  .    a  f    a  f    a
//  ....    ....    eeee    eeee    eeee    eeee    eeee    ....    eeee    eeee
// c    b  .    b  c    .  .    b  .    b  .    b  c    b  .    b  c    b  .    b
// c    b  .    b  c    .  .    b  .    b  .    b  c    b  .    b  c    b  .    b
//  gggg    ....    gggg    gggg    ....    gggg    gggg    ....    gggg    gggg

//  dddd    ....    dddd    dddd    ....    dddd    dddd    dddd    dddd    dddd
// f    a  .    a  .    a  .    a  f    a  f    .  f    .  .    a  f    a  f    a
// f    a  .    a  .    a  .    a  f    a  f    .  f    .  .    a  f    a  f    a
//  ....    ....    eeee    eeee    eeee    eeee    eeee    ....    eeee    eeee
// g    b  .    b  g    .  .    b  .    b  .    b  g    b  .    b  g    b  .    b
// g    b  .    b  g    .  .    b  .    b  .    b  g    b  .    b  g    b  .    b
//  cccc    ....    cccc    cccc    ....    cccc    cccc    ....    cccc    cccc

// 2 3 5

// cdfbe   daegc | daebc | dfebc       bcdef   acdeg abcde *bcdef*
// gcdfa   daegc | daebc | dfebc       acdfg   acdeg abcde bcefd
// fbcad   daegc | daebc | dfebc       abcdf   acdeg abcde abdef

// --- --- ---

// 1 & 7 - (b a) d

//   0:      1:      2:      3:      4:      5:      6:      7:      8:      9:
//  dddd    ....    dddd    dddd    ....    dddd    dddd    dddd    dddd    dddd
// #    b  .    b  .    b  .    b  #    b  #    .  #    .  .    b  #    b  #    b
// #    b  .    b  .    b  .    b  #    b  #    .  #    .  .    b  #    b  #    b
//  ....    ....    ####    ####    ####    ####    ####    ....    ####    ####
// #    a  .    a  #    .  .    a  .    a  .    a  #    a  .    a  #    a  .    a
// #    a  .    a  #    .  .    a  .    a  .    a  #    a  .    a  #    a  .    a
//  ####    ....    ####    ####    ....    ####    ####    ....    ####    ####

// 4 - ((b a) d) e f

//   0:      1:      2:      3:      4:      5:      6:      7:      8:      9:
//  dddd    ....    dddd    dddd    ....    dddd    dddd    dddd    dddd    dddd
// e    b  .    b  .    b  .    b  e    b  e    .  e    .  .    b  e    b  e    b
// e    b  .    b  .    b  .    b  e    b  e    .  e    .  .    b  e    b  e    b
//  ....    ....    ffff    ffff    ffff    ffff    ffff    ....    ffff    ffff
// #    a  .    a  #    .  .    a  .    a  .    a  #    a  .    a  #    a  .    a
// #    a  .    a  #    .  .    a  .    a  .    a  #    a  .    a  #    a  .    a
//  ####    ....    ####    ####    ....    ####    ####    ....    ####    ####

// 4 - ((b a) d) f e

//   0:      1:      2:      3:      4:      5:      6:      7:      8:      9:
//  dddd    ....    dddd    dddd    ....    dddd    dddd    dddd    dddd    dddd
// f    b  .    b  .    b  .    b  f    b  f    .  f    .  .    b  f    b  f    b
// f    b  .    b  .    b  .    b  f    b  f    .  f    .  .    b  f    b  f    b
//  ....    ....    eeee    eeee    eeee    eeee    eeee    ....    eeee    eeee
// #    a  .    a  #    .  .    a  .    a  .    a  #    a  .    a  #    a  .    a
// #    a  .    a  #    .  .    a  .    a  .    a  #    a  .    a  #    a  .    a
//  ####    ....    ####    ####    ....    ####    ####    ....    ####    ####

Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();