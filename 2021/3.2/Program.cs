var input = File.ReadAllLines("input");

var o2FilteredInput = input;
int[] freqTable = CreateFreqTable(o2FilteredInput);
var length = freqTable.Length;
for (int i = 0; i < length; i++)
{
    if (o2FilteredInput.Length == 1)
        break;

    o2FilteredInput = o2FilteredInput.Where(v =>
    {
        var c = v[i].ToString();
        if (c == "1")
            return freqTable[i] >= 0;

        return freqTable[i] < 0;
    }).ToArray();

    // Recalculate Freq table here
    freqTable = CreateFreqTable(o2FilteredInput);
}
var t = CreateFreqTable(input);
var co2FilteredInput = input;
freqTable = CreateFreqTable(co2FilteredInput);
for (int i = 0; i < length; i++)
{
    if (co2FilteredInput.Length == 1)
        break;

    co2FilteredInput = co2FilteredInput.Where(v =>
    {
        var c = v[i].ToString();
        if (c == "1")
            return freqTable[i] < 0;

        return freqTable[i] >= 0;
    }).ToArray();

    freqTable = CreateFreqTable(co2FilteredInput);
}

int o2Rating = Convert.ToInt32(o2FilteredInput.First(), 2);
int co2Rating = Convert.ToInt32(co2FilteredInput.First(), 2);

Console.WriteLine($"O2:{o2Rating}, CO2:{co2Rating}, power consumption:{o2Rating * co2Rating}");

static int[] CreateFreqTable(string[] input)
{
    var freqTableSize = input.First().Length;
    int[] freqTable = new int[freqTableSize];
    Array.Fill(freqTable, 0);

    // 0 subtracts -1
    // 1 adds 1
    foreach (var value in input)
    {
        for (int i = 0; i < value.Length; i++)
        {
            var v = int.Parse(value[i].ToString());
            freqTable[i] += v == 1 ? 1 : -1;
        }
    }

    return freqTable;
}
