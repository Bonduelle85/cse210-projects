// Exceeding the requirements:
// 1) Created menu with choice: 'scripture from library' or 'user scripture'.
// 2) Added the opportunity to enter your own scripture.
//     !!! But the program requires correct data input (only integers, for example), otherwise an Exception occurs. For some reason unknown to me, I was unable to avoid this using the "try catch" block, which we studied in the early courses with Python. Even if I throw a general Exception or specific Exception, the block doesn't catch it.
// 3) Added Class-Repository 'ScriptureLibrary' with List<Scriptures> and GetRamdomScripture() method  
// 4) The text display of the link depends on the constructor.
// 5) Used switch-case in Main function and higher-order functions (  words.All(word => word.IsHidden())   and   words.FindAll(word => !word.IsHidden()) ).

using System;


class Program
{
    static void Main(string[] args)
    {
        DisplayGreetings();
        DisplayMenu();
        
        string answer = Console.ReadLine();
        int selectedMenuItem = int.Parse(answer);

        switch (selectedMenuItem)
        {
            case 1 :
                GetLibraryScripture();
                break;
            case 2 :
                GetUserScripture();
                break;
            default:
                break;
        }
        
    }

    public static void DisplayGreetings()
    {
        Console.Clear();
        Console.WriteLine("\nWelcome to the Scripture Memorizer!");
    }

    public static void MemorizeScripture(Scripture scripture)
    {
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine();
        Console.WriteLine("Please enter to continue or type 'quit' to finish:");

        string answer = "";

        while (answer.ToLower() != "quit" && !scripture.IsCompletelyHidden())
        {
            answer = Console.ReadLine();
            Console.Clear();
            scripture.HideRandomWords();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Please enter to continue or type 'quit' to finish:");   
        }
    }

    static public void DisplayMenu()
    {
        Console.WriteLine("\nPlease select one of the following choices (1-3):\n");

        List<string> choices = new List<string>() 
        {
            "Memorize random scripture from 'Proverbs Chapter 3'", 
            "Memorize my scripture",
            "Quit"
        };

        for (int index = 0; index < choices.Count; index++)
        {   
            Console.WriteLine($"{index+1}. {choices[index]}");
        }

        Console.WriteLine("\nWhat would you like to do? ");
    }

    public static void GetUserScripture()
    {
       
        Console.Clear();

        Console.Write("Please enter the title of the book: ");
        string book = Console.ReadLine();

        Console.Write("Please enter the 'chapter' (1-10): ");
        int chapter = int.Parse(Console.ReadLine());
        
        Console.Write("Please enter the 'start verse' (1-100): ");
        int verse = int.Parse(Console.ReadLine());

        Console.Write("Please enter the 'end verse' (1-100): ");
        Console.Write("(enter '0' if 'end verse' does not exist): ");
        int endVerse = int.Parse(Console.ReadLine());

        Console.Write("Please enter the scripture text: ");
        string text = Console.ReadLine();

        if (endVerse == 0)
        {
            Reference reference = new Reference(book, chapter, verse);
            Scripture scripture = new Scripture(reference, text);
            MemorizeScripture(scripture);
        }
        else
        {
            Reference reference = new Reference(book, chapter, verse, endVerse);
            Scripture scripture = new Scripture(reference, text);
            MemorizeScripture(scripture);
        }
    
    }

    public static void GetLibraryScripture()
    {
        ScriptureLibrary scriptureLibrary = new ScriptureLibrary();
        Scripture scripture = scriptureLibrary.GetRamdomScripture();

        MemorizeScripture(scripture);
    }


//  char[] myValidOptions = {'0','1','2'};
//    Console.WriteLine(myValidOptions.Contains('2'));    // this will output True
//    Console.WriteLine(myValidOptions.Contains('F'));   // this will output False
}