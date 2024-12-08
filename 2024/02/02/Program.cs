using System.Collections;
using System.ComponentModel;

var inputFile = File.ReadAllLines("../../../../../inputData/input_02.txt");
var input = new List<string>(inputFile);

static int[] ConvertToNumbers(string array)
{
    return array.Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();
}


static bool IsArrayInOrder(int[] array)
{
    bool? isIncreasing = null;
    
    for (int i = 0; i < array.Length - 1; i++)
    {
        if (array[i] == array[i + 1])
        {
            return false;
        }

        if (isIncreasing == null)
        {
            isIncreasing = array[i] < array[i + 1];
        }
        else if ((isIncreasing.Value && array[i] > array[i + 1]) || (!isIncreasing.Value && array[i] < array[i + 1]))
        {
            return false;
        }
    }
    return true;
}

static void PartOne(List<string> input)
{
    var safe = 0;
    foreach (var line in input)
    {
        var numbers =  ConvertToNumbers(line);
        if (IsArrayInOrder(numbers))
        {
            bool isSafe = true;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (Math.Abs(numbers[i] - numbers[i+1]) > 3)
                {
                    isSafe = false;
                    break;
                }
            }
            if (isSafe)
            {
                safe++;
            }
        }
    }
    Console.WriteLine(safe);
}

static bool IsSafe(List<int> report)
{
    if (report.Count < 2)
    {
        return true;
    }

    var firstDiff = report[1] - report[0];

    if (firstDiff == 0 || Math.Abs(firstDiff) > 3)
    {
        return false;
    }

    var expectedSgn = firstDiff / Math.Abs(firstDiff);

    for (int i = 1; i < report.Count - 1; i++)
    {
        var diff = report[i + 1] - report[i];
        if (diff == 0 || Math.Abs(diff) > 3)
        {
            return false;
        }

        var sgn = diff / Math.Abs(diff);
        if (sgn != expectedSgn)
        {
            return false;
        }
    }

    return true;
}

static void PartTwo(List<string> input)
{
    var safe = 0;
    foreach (var line in input)
    {
        var report = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        if (IsSafe(report))
        {
            safe++;
        }
        else
        {
            for (int i = 0; i < report.Count; i++)
            {
                var reportCopy = report.ToList();
                reportCopy.RemoveAt(i);
                if (IsSafe(reportCopy))
                {
                    safe++;
                    break;
                }
            }
        }
    }
    Console.WriteLine(safe);
}


PartTwo(input);