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

var hPos = commands.Sum(command => command.Direction == Direction.Forward ? command.Units : 0);
var dPos = commands.Sum(command =>
{
    return command.Direction switch
    {
        Direction.Down => command.Units,
        Direction.Up => -command.Units,
        _ => 0,
    };
});

Console.WriteLine($"{hPos * dPos}");

enum Direction
{
    Down,
    Up,
    Forward
}

record Command(Direction Direction, int Units);

