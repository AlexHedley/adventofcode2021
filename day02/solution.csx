Console.WriteLine("Day 2");

private int horizontal = 0;
private int depth = 0;
private int aim = 0;

void forward(int x) {
    // horizontal += x;
    horizontal += x;
    depth += aim * x;
}

void down(int x) {
    // depth += x;
    aim += x;
}

void up(int x) {
    // depth -= x;
    aim -= x;
}

// string[] lines = System.IO.File.ReadAllLines(@"input-sample.txt");
string[] lines = System.IO.File.ReadAllLines(@"input.txt");

foreach(var line in lines)
{
    (string cmd, int amount) command = line.Split(' ') switch { var a => (a[0], Int32.Parse(a[1])) };
    Console.WriteLine(command);
    // this.GetType().GetMethod(command.cmd).Invoke(this, new object[]{ command.amount } );

    switch (command.cmd) {
        case "forward":
            forward(command.amount);
            break;
        case "down":
            down(command.amount);
            break;
        case "up":
            up(command.amount);
            break;
        default:
            break;
    }
}

Console.WriteLine($"Horizontal {horizontal}");
Console.WriteLine($"Depth: {depth}");
Console.WriteLine($"Final Depth: {horizontal*depth}");

Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();