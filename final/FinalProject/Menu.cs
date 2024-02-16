public class Menu
{
    private int _selectedActionItem;
    private int _selectedExerciseTypeItem;

    public Menu()
    {
        _selectedActionItem = 0;
        _selectedExerciseTypeItem = 0;
    }

    // selectedActionItem getter and setter
    public int GetSelectedActionItem()
    {
        return _selectedActionItem;
    }

    public int SetSelectedActionItem(int menuItem)
    {
        return _selectedActionItem = menuItem;
    }

    // selectedExerciseTypeItem getter and setter
    public int GetSelectedExerciseTypeItem()
    {
        return _selectedExerciseTypeItem;
    }
    public int SetSelectedExerciseTypeItem(int menuItem)
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
        _selectedActionItem =  int.Parse(Console.ReadLine());
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

        Console.Write("\nWhich type of exercise would you like to create [1-4]?");
        _selectedExerciseTypeItem =  int.Parse(Console.ReadLine());
    }
}