using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2025.Days
{
    public class Day01 : IDay
    {
        public int DayNumber => 1;

        public string Run(string input)
        {
            string[] lines = input.Split('\n');

            string PartTwo(string[] lines)
            {
                int currentSpot = 50;
                int crossedZero = 0;

                foreach (var line in lines)
                {
                    char directionToTurn = line[0];
                    int turningAmount = int.Parse(line.Substring(1));
                    if (directionToTurn == 'L') turningAmount = -turningAmount;

                    int fullRotations = turningAmount / 100;
                    int remainder = turningAmount % 100;

                    crossedZero += Math.Abs(fullRotations);

                    int startingSpot = currentSpot;
                    currentSpot += remainder;

                    if (currentSpot >= 100)
                    {
                        currentSpot -= 100;
                        crossedZero++;
                    }
                    else if (currentSpot < 0)
                    {
                        currentSpot += 100;
                        if (startingSpot != 0) crossedZero++;
                    }
                    else if (currentSpot == 0)
                    {
                        crossedZero++;
                    }
                }

                
                return "Part Two " + crossedZero.ToString();
            }
            
            
            string PartOne(string[] lines)
            {
            
                int currentSpot = 50;
                int total = 0;

                foreach (var line in lines)
                {
                    char directionToTurn = line[0];
                    int turningAmount = int.Parse(line.Substring(1)) % 100;
                    switch (directionToTurn)
                    {
                        case 'L':
                            TurnLeft(turningAmount);
                            break;
                        case 'R':
                            TurnRight(turningAmount);
                            break;
                        default:
                            Console.WriteLine("Invalid direction");
                            break;
                    }
                }

                int TurnLeft(int turningAmount)
                {
                        
                    currentSpot -= turningAmount;
                    currentSpot = (currentSpot + 100) % 100;

                    if (currentSpot == 0) total++;
                    
                    return currentSpot;
                }
                
                int TurnRight(int turningAmount)
                {
                    currentSpot += turningAmount;

                    currentSpot = (currentSpot + 100) % 100;

                    if (currentSpot == 0) total++;
                    
                    return currentSpot;
                }

                return "Part One " + total.ToString();   
            }
            
            return $"{PartOne(lines)}\n{PartTwo(lines)}";
        }
    }
}