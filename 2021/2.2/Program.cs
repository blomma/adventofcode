var input = System.IO.File.ReadAllLines("input");
var commands = input.Select(value =>
{
    var r = value.Split(" ").Select(v => v.Trim());
    return (string)r.First() switch
    {
        "forward" => new Command(Direction.Forward, int.Parse(r.Last())),
        "down" => new Command(Direction.Down, int.Parse(r.Last())),
        "up" => new Command(Direction.Up, int.Parse(r.Last())),
        _ => throw new Exception("Unknow command"),
    };
});

var aim = 0;
var horizontalPos = 0;
var depthPos = 0;

foreach (var command in commands)
{
    switch (command.Direction)
    {
        case Direction.Down:
            aim += command.Units;
            break;

        case Direction.Up:
            aim -= command.Units;
            break;

        case Direction.Forward:
            horizontalPos += command.Units;
            depthPos += aim * command.Units;
            break;
        default:
            break;
    }
}

Console.WriteLine($"{horizontalPos * depthPos}");

enum Direction
{
    Down,
    Up,
    Forward
}

record Command(Direction Direction, int Units);

