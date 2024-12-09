using System.Collections;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

var inputFile = File.ReadAllLines("../../../../../inputData/input_03.txt");
var input = new List<string>(inputFile);

static int PartOne(List<string> input)
{
    Regex getMultiplyNumbers = new Regex("mul\\(\\d+,\\d+\\)");
    var total = 0;
    
    foreach (var line in input)
    {
       var multiplyMatches = getMultiplyNumbers.Matches(line);
       foreach (Match match in multiplyMatches)
       {
              var numbers = match.Value.Split("(")[1].Split(")")[0].Split(",");
              var firstNumber = int.Parse(numbers[0]);
              var secondNumber = int.Parse(numbers[1]);
              total += firstNumber * secondNumber;
       }
    }
    Console.WriteLine(total);
    return total;
}


static void PartTwo(List<string> input)
{
    Regex getMultiplyNumbers = new Regex("mul\\(\\d+,\\d+\\)");
    Regex getDo = new Regex("\\bdo\\b");
    Regex getDont = new Regex("\\bdon't\\b");

    bool enabled = true;
    foreach (var line in input)
    {
        
    }
    
}

PartTwo(input);
