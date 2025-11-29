namespace DefaultNamespace;

public class Day01 : IDay
{
    public int DayNumber => 1;

    public string Run(string data)
    {
        var input = data
            .Split('\n')
            .Select(x => x.Trim())
            .Where(x => x != "")
            .ToList();

        var (col1, col2) = ParseColumns(input);
        var sorted1 = SortLowToHigh(col1);
        var sorted2 = SortLowToHigh(col2);
        int part1 = GetDistanceTotal(sorted1, sorted2);

        int part2 = FindSimilarityScore(col1, col2);

        return $"Part 1: {part1}\nPart 2: {part2}";
    }
    

    private static (int[], int[]) ParseColumns(List<string> input)
    {
        var col1 = new List<int>();
        var col2 = new List<int>();

        foreach (var line in input)
        {
            var row = line.Split(new char[] { ' ', '\t' },
                StringSplitOptions.RemoveEmptyEntries);

            col1.Add(int.Parse(row[0]));
            col2.Add(int.Parse(row[1]));
        }

        return (col1.ToArray(), col2.ToArray());
    }

    private static int[] SortLowToHigh(int[] array)
    {
        Array.Sort(array);
        return array;
    }

    private static int GetDistanceTotal(int[] arrayOne, int[] arrayTwo)
    {
        int number = 0;

        for (int i = 0; i < arrayOne.Length; i++)
        {
            number += Math.Abs(arrayOne[i] - arrayTwo[i]);
        }

        return number;
    }

    private static int FindSimilarityScore(int[] arrayOne, int[] arrayTwo)
    {
        int total = 0;

        foreach (var value in arrayOne)
        {
            int count = arrayTwo.Count(x => x == value);
            total += value * count;
        }

        return total;
    }
}