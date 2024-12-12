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
    Regex getDo = new Regex("do");
    Regex getDont = new Regex("\\bdon't\\b");

    bool enabled = true;
    var total = 0;
    foreach (var line in input)
    {
        var disableMatches = getDont.Matches(line);
        var enableMatches = getDo.Matches(line);
        var multiplyMatches = getMultiplyNumbers.Matches(line);
        var allMatches = enableMatches.Cast<Match>().Concat(disableMatches.Cast<Match>().Concat(multiplyMatches.Cast<Match>()))
            .OrderBy(m => m.Index);

        foreach (var match in allMatches)
        {
            if (match.Value == "do")
            {
                enabled = true;
            }
            else if (match.Value == "don't")
            {
                enabled = false;
            }
            if (enabled && match.Value.StartsWith("mul("))
            {
                var parts = match.Value.Split(new[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 3)
                {
                    var firstNumber = int.Parse(parts[1]);
                    var secondNumber = int.Parse(parts[2]);
                    total += firstNumber * secondNumber;
                }
            }
        }
    }
    Console.WriteLine(total);
}

PartTwo(input);
