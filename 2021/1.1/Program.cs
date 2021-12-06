// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var input = System.IO.File.ReadAllLines("input");

var depths = input.Select(depth => int.Parse(depth));

int currentDepth = depths.First();
int depthIncreases = 0;
foreach (var depth in depths.Skip(1))
{
    if (depth > currentDepth)
    {
        depthIncreases += 1;
    }
    currentDepth = depth;
}

Console.WriteLine(depthIncreases);