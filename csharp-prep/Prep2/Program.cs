using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string stringGrade = Console.ReadLine();
        int intGrade = int.Parse(stringGrade);
        
        string letterGrade;

        if (intGrade >= 90)
        {
            letterGrade = "A";
        }
        else if (intGrade >= 80)
        {
            letterGrade = "B";
        }
        else if (intGrade >= 70)
        {
            letterGrade = "C";
        }
        else if (intGrade >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        Console.WriteLine($"\nYour letter grade is {letterGrade}.");

        if (intGrade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the test!");
        }
        else
        {
            Console.WriteLine("You failed the test today. But you will succeed next time.");
        }
    }
}