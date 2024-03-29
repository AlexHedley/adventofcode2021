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

var completedNumbers = new List<char>();
var completedLetters = new List<char>();

// ONE
Console.WriteLine("-- ONE --");

var matchingOne = numberMappings.Where(x => x.count == 2).FirstOrDefault();
Console.WriteLine($"{matchingOne.number} | {string.Join(" ", matchingOne.segments)} | #:{matchingOne.count}");
var oneLetters = one.ToCharArray();
Console.WriteLine(string.Join(" ", oneLetters));

var checks = new List<List<char[,]>>();
var numbersMatrix = new List<char[,]>() { zeroDigit, oneDigit, twoDigit, threeDigit, fourDigit, fiveDigit, sixDigit, sevenDigit, eightDigit, nineDigit };

UpdateNumberOne(matchingOne.segments, oneLetters);

// SEVEN
Console.WriteLine("-- SEVEN --");

var matchingSeven = numberMappings.Where(x => x.count == 3).FirstOrDefault();
Console.WriteLine($"{matchingSeven.number} | {string.Join(" ", matchingSeven.segments)} | #:{matchingSeven.count}");
var sevenLetters = seven.ToCharArray();
Console.WriteLine($"Seven Letters: {string.Join(" ", sevenLetters)}");

var remainingLettersSeven = sevenLetters.Except(completedLetters).ToArray();
Console.WriteLine($"Remaing Letters: {string.Join(" ", remainingLettersSeven)}");

var numbersToCheckSeven = matchingSeven.segments.Except(completedNumbers).ToList();
Console.WriteLine($"Numbers To Check: {string.Join(" ", numbersToCheckSeven)}");

UpdateNumberSeven(numbersToCheckSeven, remainingLettersSeven);

// FOUR
Console.WriteLine("-- FOUR --");

var matchingFour = numberMappings.Where(x => x.count == 4).FirstOrDefault();
Console.WriteLine($"{matchingFour.number} | {string.Join(" ", matchingFour.segments)} | #:{matchingFour.count}");
var fourLetters = four.ToCharArray();
Console.WriteLine($"Four Letters: {string.Join(" ", fourLetters)}");

var remainingLettersFour = fourLetters.Except(completedLetters).ToArray();
Console.WriteLine($"Remaing Letters: {string.Join(" ", remainingLettersFour)}");

var numbersToCheckFour = matchingFour.segments.Except(completedNumbers).ToList();
Console.WriteLine($"Numbers To Check: {string.Join(" ", numbersToCheckFour)}");

// UpdateNumberFour
UpdateNumberWithCombinations(4, checks, numbersToCheckFour, remainingLettersFour);

foreach(var check in checks)
{
    PrintNumbers(check);
}

Console.WriteLine("--- --- ---");
Console.WriteLine($"Checks #:{checks.Count}");
Console.WriteLine($"Completed Letters: {string.Join(" ", completedLetters)}");
Console.WriteLine($"Completed Numbers: {string.Join(" ", completedNumbers)}");

Console.WriteLine();

// --- --- ---

// Testing

// var product = 
//     from first in numbersToCheckFour 
//     from second in remainingLettersFour 
//     select new[] { first, second };
// product.ToList().ForEach(Console.WriteLine);

// --- --- ---

// Update Number One
public void UpdateNumberOne(List<char> numbers, char[] letters)
{
    Console.WriteLine("UPDATE NUMBER 1");

    var a = 0;
    for (var i = 0; i < numbers.Count; i++) // 3 6
    {
        Console.WriteLine($"a: {a} | i: {i} | {numbers[i]}");
        completedNumbers.Add(numbers[i]);
        
        // Console.WriteLine("ZERO");
        // PrintMatrix(zeroDigit);
        // Console.WriteLine("OREZ");

        // PrintNumbers(numbersMatrix);

        var digits = new List<char[,]>(numbersMatrix);

        Console.WriteLine($"Number:{numbers[0+a]} | Letter:{letters[0]}");
        // swap all 3(c) with a | swap all 6(f) with b
        // a = 3 | b = 6
        // numbersMatrix.ForEach(m => FindAndSwapInMatrix(ref m, letters[0+a], letters[0]));
        digits = FindAndSwapInMatrix(digits, numbers[0+a], letters[0]);

        Console.WriteLine($"Number:{numbers[1-a]} | Letter:{letters[1]}");
        // swap all 3(c) with b | swap all 6(f) with a
        // b = 3 | a = 6
        // numbersMatrix.ForEach(m => FindAndSwapInMatrix(ref m, numbers[1-a], letters[1]));
        digits = FindAndSwapInMatrix(digits, numbers[1-a], letters[1]);
        
        checks.Add(digits);
        
        a+=1;
        Console.WriteLine("--- --- ---");
    }
    completedLetters.Add(letters[0]);
    completedLetters.Add(letters[1]);
}

// Update Number Seven
public void UpdateNumberSeven(List<char> numbers, char[] letters)
{
    Console.WriteLine("UPDATE NUMBER 7");

    var sevenChecks = new List<List<char[,]>>();

    foreach(var number in numbers)
    {
        foreach(var letter in letters)
        {
            Console.WriteLine($"Number:{number} | Letter:{letter}");

            foreach(var check in checks)
            {
                var digits = new List<char[,]>(check);
                digits = FindAndSwapInMatrix(digits, number, letter);

                sevenChecks.Add(digits);
            }
            completedLetters.Add(letter);
        }
        completedNumbers.Add(number);
    }

    checks = sevenChecks;
}

// Update Number Four
public void UpdateNumberWithCombinations(int digit, List<List<char[,]>> checks, List<char> numbers, char[] letters)
{
    Console.WriteLine($"UPDATE DIGIT {digit}");

    var updatedList = new List<List<char[,]>>();
    
    // 2 combinations - existing checks duplicated.
    // Loop each with the combinations again. 

    // var product = 
    //     from first in numbers 
    //     from second in letters 
    //     select new[] { first, second };
    // product.ToList().ForEach(Console.WriteLine);
    
    foreach(var check in checks)
    {
        for (var i = 0; i < numbers.Count; i++)
        {
            var digits = new List<char[,]>(check);
            updatedList.Add(digits);
        }
    }

    var combinationChecks = new List<List<char[,]>>();

    var a = 0;
    foreach(var list in updatedList)
    {
        // PrintNumbers(combinationCheck);
        var digits = new List<char[,]>(list);
        digits = FindAndSwapInMatrix(digits, numbers[0+a], letters[0]); // 2 e  // 4 e
        digits = FindAndSwapInMatrix(digits, numbers[1-a], letters[1]); // 4 f  // 2 f

        combinationChecks.Add(digits);

        a+=1;
    }

    Console.WriteLine($"#:{combinationChecks.Count}");

    completedLetters.AddRange(letters);

    checks = combinationChecks;
}

// Print Numbers
public void PrintNumbers(List<char[,]> numbers)
{
    numbers.ForEach(x => { PrintMatrix(x); Console.WriteLine(""); } );
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

Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();