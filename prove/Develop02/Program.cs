// Exceeding the requirements:
// 1) Created mapper-methods in the Entry class and made its variables or attributes private.
// 2) Added lines displaying file saving and loading process.
// 3) Added a method Clear() to the Menu for deleting entries from the Journal
// 4) Added a short time display to the date (in DisplayMenu() method).
// 5) Added time variable to Entry class.
// 6) Used switch-case in Main function.

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        int selectedMenuItem = 0;

        DisplayGreetings();

        while (selectedMenuItem != 6)
        {
            DisplayMenu();

            string answer = Console.ReadLine();
            selectedMenuItem = int.Parse(answer);

            switch (selectedMenuItem)
            {
            case 1 :
                Write(journal, promptGenerator);
                break;
            case 2 :
                Display(journal);
                break;
            case 3 :
                Load(journal);
                break;
            case 4 :
                Save(journal);
                break;
            case 5 :
                Clear(journal);
                break;
            default:
                break;
            }

        }
    
    }

    
    

    static public void DisplayGreetings()
    {
        Console.WriteLine("Welcome to the Journal Program!");
    }

    static public void DisplayMenu()
    {
        Console.WriteLine("\nPlease select one of the following choices (1-6):\n");

        List<string> choices = new List<string>() {"Write", "Display", "Load", "Save", "Clear", "Quit"};

        for (int index = 0; index < choices.Count; index++)
        {   
            Console.WriteLine($"{index+1}. {choices[index]}");
        }

        Console.WriteLine("\nWhat would you like to do? ");
    }

    static public void Write(Journal journal, PromptGenerator promptGenerator)
    {
        Entry entry = new Entry();
        DateTime theCurrentTime = DateTime.Now;
        
        string dateText = theCurrentTime.ToShortDateString();
        string timeText = theCurrentTime.ToShortTimeString();

        string randomPrompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine(randomPrompt);
        
        string answer = Console.ReadLine();

        entry.MapToEntry(dateText, timeText, randomPrompt, answer);
        journal.AddEntry(entry);
    }

    static public void Display(Journal journal)
    {
        journal.Display();
    }

    static public void Load(Journal journal)
    {   
        Console.Write("Please enter file name: ");
        string fileName = Console.ReadLine();
        journal.LoadFromFile(fileName);
    }

    static public void Save(Journal journal)
    {
        Console.Write("Please enter file name: ");
        string fileName = Console.ReadLine();
        journal.SaveToFile(fileName);
    }

    static public void Clear(Journal journal)
    {
        journal.Clear();
    }
}

    