using System.Collections;
using System.Runtime.CompilerServices;

var inputFile = File.ReadAllLines("../../../../../inputData/input_01.txt");
var input = new List<string>(inputFile);

static int[] SortLowToHigh(int[] array)
{
    Array.Sort(array);
    return array;
}

static int GettingTotal(int[] arrayOne, int[] arrayTwo)
{
    var number = 0;
    for (int i = 0; i < arrayOne.Length; i++)
    {
        // Original
        // if (arrayOne[i] > arrayTwo[i])
        // {
        //     number += arrayOne[i] - arrayTwo[i];
        // }
        // else
        // {
        //     number += arrayTwo[i] - arrayOne[i];
        // }
        
        // Refactored
        number += Math.Abs(arrayOne[i] - arrayTwo[i]);

    }

    return number;
}

static void PartOne(List<string> input)
{
    // Original
    // ArrayList column1 = new ArrayList();
    // ArrayList column2 = new ArrayList();
    // foreach (var line in input)
    // {
    //     var row = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
    //     column1.Add(int.Parse(row[0]));
    //     column2.Add(int.Parse(row[1]));
    // }

    // Refactored
    var (column1, column2) = ParsingArray(input);
    var sortedColumn1 = SortLowToHigh(column1);
    var sortedColumn2 = SortLowToHigh(column2);

    Console.WriteLine(GettingTotal(sortedColumn1, sortedColumn2));
}


static int FindInArray(int[] arrayOne, int[] arrayTwo)
{
    var number = 0;
    foreach (var line in arrayOne)
    {
        var count = 0;
        foreach (var line2 in arrayTwo)
        {
            if (line == line2)
            {
                count++;
            }
        }

        count = line * count;
        number += count;
    }

    return number;
}

static void PartTwo(List<string> input)
{
    // Original
    // ArrayList column1 = new ArrayList();
    // ArrayList column2 = new ArrayList();
    // foreach (var line in input)
    // {
    //     var row = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
    //     column1.Add(int.Parse(row[0]));
    //     column2.Add(int.Parse(row[1]));
    // }
    
    // Refactored
    var (column1, column2) = ParsingArray(input);
    Console.WriteLine(FindInArray(column1, column2));
}

// Refactored parsing to int to its own method
static (int[], int[]) ParsingArray(List<string> input)
{
    ArrayList column1 = new ArrayList();
    ArrayList column2 = new ArrayList();
    foreach (var line in input)
    {
        var row = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        column1.Add(int.Parse(row[0]));
        column2.Add(int.Parse(row[1]));
    }

    return ((int[])column1.ToArray(typeof(int)), (int[])column2.ToArray(typeof(int)));
}

PartOne(input);
PartTwo(input);
