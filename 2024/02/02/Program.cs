using System.Collections;

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

PartOne(input);