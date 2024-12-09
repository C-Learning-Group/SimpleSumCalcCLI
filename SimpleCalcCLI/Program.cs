namespace SimpleCalcCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long firstVal = 0, secondVal = 0;
            bool isFirstValid = false, isSecondValid = false;

            while (!isFirstValid || !isSecondValid)
            {
                if (!isFirstValid)
                {
                    Console.WriteLine("Please enter the first number:");
                    string? firstInput = Console.ReadLine();
                    if (Int64.TryParse(firstInput, out firstVal))
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
                    if (Int64.TryParse(secondInput, out secondVal))
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

            long sum = firstVal + secondVal;
            Console.WriteLine($"The sum of {firstVal} + {secondVal} = {sum}");
        }
    }
}
