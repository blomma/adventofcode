var input = System.IO.File.ReadAllLines("input");

var freqTableSize = input.First().Length;
int[] freqTable = new int[freqTableSize];
Array.Fill(freqTable, 0);

foreach (var value in input)
{
    // 0 subtracts -1
    // 1 adds 1

    for (int i = 0; i < value.Length; i++)
    {
        var v = int.Parse(value[i].ToString());
        freqTable[i] += v == 1 ? 1 : -1;
    }
}

string gamma = string.Empty;
string epsilon = string.Empty;

foreach (var f in freqTable)
{
    gamma += f > 0 ? 1 : 0;
    epsilon += f > 0 ? 0 : 1;
}

int decimalGamma = Convert.ToInt32(gamma, 2);
int decimalEpsilon = Convert.ToInt32(epsilon, 2);

Console.WriteLine($"gamma:{decimalGamma}, epsilon:{decimalEpsilon}, power consumption:{decimalGamma * decimalEpsilon}");
