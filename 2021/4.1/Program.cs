var input = File.ReadAllLines("input.txt");

var randomNumbers = input
    .First()
    .Split(",");

var boards = input
    .Skip(1)
    .SelectMany(v => v.Split(" "))
    .Where(v => !string.IsNullOrWhiteSpace(v))
    .ToArray();

Dictionary<string, IEnumerable<int>> boardLookup = new();
for (int i = 0; i < boards.Length; i++)
{
    var number = boards[i];
    boardLookup[number] = boardLookup.ContainsKey(number)
        ? boardLookup[number].Append(i)
        : new List<int> { i };
}

var noOfBoards = boards.Length / 25;
var bingoBoard = new bool[boards.Length];

var isWin = false;
var posWin = 0;
foreach (var number in randomNumbers)
{
    if (isWin)
        break;

    if (!boardLookup.ContainsKey(number))
        continue;

    var boardPositions = boardLookup[number];
    foreach (var pos in boardPositions)
    {
        if (isWin)
            break;

        bingoBoard[pos] = true;
        (isWin, posWin) = CheckWinAndCalculateScore(pos);
    }
}

if (isWin)
{
    var score = CalculateScoreFromPos(posWin);
    Console.WriteLine($"Winning score:{score}");
}
else
{
    Console.WriteLine("NO WIN");
}

int CalculateScoreFromPos(int pos)
{
    var boardPos = pos % 25;
    var startPos = pos - boardPos;
    var sumOfUnmarked = 0;

    for (int i = 0; i < 25; i++)
    {
        var currentPos = startPos + i;
        if (!bingoBoard[currentPos])
        {
            sumOfUnmarked += int.Parse(boards[currentPos]);
        }
    }

    var winningNumberOnBoard = int.Parse(boards[pos]);
    return sumOfUnmarked * winningNumberOnBoard;
}

(bool isWin, int pos) CheckWinAndCalculateScore(int pos)
{
    var boardPos = pos % 25;
    var rowPos = boardPos % 5;

    var allVRowIsTrue = true;
    var vrowStartPos = pos - rowPos;
    for (int i = 0; i < 5; i++)
    {
        allVRowIsTrue = bingoBoard[vrowStartPos] && allVRowIsTrue;
        vrowStartPos += 1;
    }

    if (allVRowIsTrue)
        return (true, pos);

    var allHRowIsTrue = true;
    var hRowPos = boardPos / 5;
    var hRowStartPos = pos - (hRowPos * 5);
    for (int i = 0; i < 5; i++)
    {
        allHRowIsTrue = bingoBoard[hRowStartPos] && allHRowIsTrue;
        hRowStartPos += 5;
    }

    if (allHRowIsTrue)
        return (true, pos);

    return (false, 0);
}