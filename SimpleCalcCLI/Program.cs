using System;

namespace SimpleCalcCLI
{
    public class Calculator
    {
        public static bool TryParseNumber(string? input, out long number)
        {
            return Int64.TryParse(input, out number);
        }

        public static long CalculateSum(long firstNumber, long secondNumber)
        {
            return firstNumber + secondNumber;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            long firstVal = 0, secondVal = 0;
            bool isFirstValid = false, isSecondValid = false;

            while (!isFirstValid || !isSecondValid)
            {
                if (!isFirstValid)
                {
                    Console.WriteLine("Please enter the first number:");
                    string? firstInput = Console.ReadLine();
                    if (Calculator.TryParseNumber(firstInput, out firstVal))
                    {
                        isFirstValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer number.\n");
                        continue;
                    }
                }

                if (!isSecondValid)
                {
                    Console.WriteLine("Please enter the second number:");
                    string? secondInput = Console.ReadLine();
                    if (Calculator.TryParseNumber(secondInput, out secondVal))
                    {
                        isSecondValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer number.\n");
                        continue;
                    }
                }
            }
            long sum = Calculator.CalculateSum(firstVal, secondVal);
            Console.WriteLine($"The sum of {firstVal} + {secondVal} = {sum}");
        }
    }

}
