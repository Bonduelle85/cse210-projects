using System;

class Program
{
    static void Main(string[] args)
    {   
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);

        int userNumber;
        int counter = 0;
        string answer = "N";

        do
        {
            do
            {
                Console.Write("What is your guess? ");
                string userNumberString = Console.ReadLine();
                userNumber = int.Parse(userNumberString);
                counter++;

                if (userNumber > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (userNumber < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine($"You guessed it! Number of attempts: {counter}");
                    Console.Write("Shall we play again? (Y/N) ");
                    answer = Console.ReadLine();
                    counter = 0;
                }
            } while (userNumber != magicNumber);

        } while (answer == "Y");

    }
}