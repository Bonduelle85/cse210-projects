using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        int number;
        List<int> numbers = new List<int>();
        List<int> posNumbers = new List<int>();

        do
        {
            string userInput = Console.ReadLine();
            int userNumber = int.Parse(userInput);
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
                number = userNumber;
            }
            else
            {
                number = userNumber;
            }
        } while (number != 0);
        
        // Calculation sum, average and largest number
        int sum = numbers.Sum();
        float average = (float)sum / numbers.Count;
        int largest = numbers.Max();
        
        // Adding positive numbers to a empty posNumbers list
        foreach (int num in numbers)
        {
            if (num > 0)
            {
                posNumbers.Add(num);
            }
        }

        // Calculation smallest positive number
        int smallPos = posNumbers.Min();

        Console.WriteLine($"The sum is: {sum}.");
        Console.WriteLine($"The average is: {average}.");
        Console.WriteLine($"The largest number is: {largest}.");
        Console.WriteLine($"The smallest positive number is: {smallPos}");
        Console.WriteLine($"The sorted list is: ");
        
        numbers.Sort();
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}