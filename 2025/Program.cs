using System.Reflection;

var argDay = args
    .SkipWhile(a => a != "--day")
    .Skip(1)
    .Select(int.Parse)
    .FirstOrDefault(-1);

var dayTypes = Assembly.GetExecutingAssembly()
    .GetTypes()
    .Where(t => typeof(IDay).IsAssignableFrom(t) && !t.IsInterface)
    .ToList();

static IDay CreateDay(Type t) =>
    (IDay?)Activator.CreateInstance(t)
    ?? throw new InvalidOperationException($"Cannot instantiate {t.Name}");

var days = dayTypes
    .Select(CreateDay)
    .OrderBy(d => d.DayNumber)
    .ToList();

int dayToRun = argDay > 0 ? argDay : days.Max(d => d.DayNumber);

var day = days.First(d => d.DayNumber == dayToRun);

var inputPath = $"Inputs/day{dayToRun:00}.txt";
var input = File.Exists(inputPath) ? File.ReadAllText(inputPath) : "";

Console.WriteLine(day.Run(input));
