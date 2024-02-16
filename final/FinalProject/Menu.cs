public class Menu
{
    private string _selectedActionItem;
    private string _selectedExerciseTypeItem;

    public Menu()
    {
        _selectedActionItem = "0";
        _selectedExerciseTypeItem = "0";
    }

    // selectedActionItem getter and setter
    public string GetSelectedActionItem()
    {
        return _selectedActionItem;
    }

    public string SetSelectedActionItem(string menuItem)
    {
        return _selectedActionItem = menuItem;
    }

    // selectedExerciseTypeItem getter and setter
    public string GetSelectedExerciseTypeItem()
    {
        return _selectedExerciseTypeItem;
    }
    public string SetSelectedExerciseTypeItem(string menuItem)
    {
        return _selectedExerciseTypeItem = menuItem;
    }


    public void DisplayActions()
    {
        Console.Clear();
        Console.WriteLine("\nMenu Options: \n");

        List<string> menuItems = new List<string>() 
        {
            "Create Exercise", 
            "Show All Exercises",
            "Do Exercise",
            "Load Exercises",
            "Save Exercises",
            "Quit"
        };

        for (int index = 0; index < menuItems.Count; index++)
        {   
            Console.WriteLine($"{index+1}. {menuItems[index]}");
        }

        Console.Write("\nSelect a choice from the menu: ");
        _selectedActionItem =  Console.ReadLine();
    }

    public void DisplayExerciseTypes()
    {
        Console.Clear();
        Console.WriteLine("Exercise types are:");

        List<string> menuItems = new List<string>() 
        {
            "Repetition Exercise", 
            "Time Exercise",
            "Time Exercise with sets",
            "Custom Exercise",
        };

        for (int index = 0; index < menuItems.Count; index++)
        {   
            Console.WriteLine($"{index+1}. {menuItems[index]}");
        }

        Console.Write("\nWhich type of exercise would you like to create [1-4]? ");
        _selectedExerciseTypeItem =  Console.ReadLine();
    }
}