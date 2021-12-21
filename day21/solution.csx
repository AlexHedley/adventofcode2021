Console.WriteLine("Day 21");

// string[] lines = System.IO.File.ReadAllLines(@"input-sample.txt");
string[] lines = System.IO.File.ReadAllLines(@"input.txt");

var rolls = 0;
var playerScore1 = 0;
var playerScore2 = 0;
var player1 = lines[0].Split(':', StringSplitOptions.TrimEntries).Where(x => int.TryParse(x, out _)).Select(int.Parse).LastOrDefault();
Console.WriteLine($"Player1 Start: {player1}");
var player2 = lines[1].Split(':', StringSplitOptions.TrimEntries).Where(x => int.TryParse(x, out _)).Select(int.Parse).LastOrDefault();
Console.WriteLine($"Player2 Start: {player2}");

var players = new List<int>() { player1, player2 };

// Console.WriteLine(new[]{1,2,3}.Aggregate((x, y) => x + y));
// I don't like this.
var numberList = Enumerable.Range(1, 100).ToList();
numberList = numberList.Concat(numberList).ToList();
numberList = numberList.Concat(numberList).ToList();
numberList = numberList.Concat(numberList).ToList();
numberList = numberList.Concat(numberList).ToList();

var groupSize = 3;
var grouped = numberList.Select((t, i) => new { t, i }).GroupBy(x => (int)(x.i / groupSize), x => x.t);
// grouped.ForEach(Console.WriteLine);

// Swap this to Linq
var groupedSum = new List<int>();
foreach (var g in grouped)
{
    var sum = 0;
    foreach (var w in g)
    {
        sum += w;
    }
    Console.WriteLine($"{sum}: {String.Join("+", g)}");
    groupedSum.Add(sum);
}

// groupedSum.ForEach(Console.WriteLine);
Console.WriteLine(String.Join(", ", groupedSum));
Console.WriteLine($"Count of items: {groupedSum.Count}");

while (playerScore1 < 1000 && playerScore2 < 1000)
{
    for (var i = 0; i < groupedSum.Count - 2; i++)
    {
        player1 = WrapAround(player1+groupedSum[i]);
        playerScore1 += player1;
        Console.WriteLine($"Player1 ({i}): {player1} ({groupedSum[i]}) - Total Score: {playerScore1}");
        rolls += 3;
        
        if (playerScore1 >= 1000)
        {
            Console.WriteLine("P1 Winner");
            break;
        }
        
        player2 = WrapAround(player2+groupedSum[i+1]);
        playerScore2 += player2;
        Console.WriteLine($"Player2 ({i+=1}): {player2} ({groupedSum[i+1]}) - Total Score: {playerScore2}");
        rolls += 3;

        if (playerScore2 >= 1000)
        {
            Console.WriteLine("P2 Winner");
            break;
        }
        
    }
}

Console.WriteLine($"Player1 Score: {playerScore1}");
Console.WriteLine($"Player2 Score: {playerScore2}");

Console.WriteLine($"Rolls #: {rolls}");

Console.WriteLine($"Total P1: {playerScore1*rolls} ({playerScore1} * {rolls})");
Console.WriteLine($"Total P2: {playerScore2*rolls} ({playerScore2} * {rolls})");

// Console.WriteLine($"Actual  : {745 * 993} (745 * 993)");

// players.Interleave(groupedSum);

// var x = 4 + 21;
// var x_min = 1;
// var x_max = 11;
// x = (((x - x_min) % (x_max - x_min)) + (x_max - x_min)) % (x_max - x_min) + x_min;
// Console.WriteLine(x);

public int WrapAround(int x)
{
    var x_min = 1;
    var x_max = 11;
    x = (((x - x_min) % (x_max - x_min)) + (x_max - x_min)) % (x_max - x_min) + x_min;
    return x;
}

// Part 2
// Console.WriteLine("Part 2.");

Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();