﻿using System.Collections;
using System.ComponentModel;

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
        if (arrayOne[i] > arrayTwo[i])
        {
            number += arrayOne[i] - arrayTwo[i];
        }
        else
        {
            number += arrayTwo[i] - arrayOne[i];
        }
    }

    return number;
}

static void PartOne(List<string> input)
{
    ArrayList column1 = new ArrayList();
    ArrayList column2 = new ArrayList();
    foreach (var line in input)
    {
        var row = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        column1.Add(int.Parse(row[0]));
        column2.Add(int.Parse(row[1]));
    }

    (int[] sortedColumn1, int[] sortedColumn2) = (SortLowToHigh((int[])column1.ToArray(typeof(int))), SortLowToHigh((int[])column2.ToArray(typeof(int))));

    Console.WriteLine(GettingTotal(sortedColumn1, sortedColumn2));
}




PartOne(input);


