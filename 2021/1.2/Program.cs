var input = System.IO.File.ReadAllLines("input");

var depths = input.Select(depth => int.Parse(depth)).ToArray();
int depthIncreases = 0;

for (int i = 0; i < depths.Length; i++)
{
    var aRangeStart = i;
    var aRangeEnd = aRangeStart + 3;
    if (aRangeEnd > depths.Length)
        break;

    var a = depths[aRangeStart..aRangeEnd].Sum();

    var bRangeStart = i + 1;
    var bRangeEnd = bRangeStart + 3;
    if (bRangeEnd > depths.Length)
        break;

    var b = depths[bRangeStart..bRangeEnd].Sum();

    if (b > a)
        depthIncreases += 1;
    Console.WriteLine($"{a}:{b}");
}

Console.WriteLine(depthIncreases);