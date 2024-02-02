public class Menu
{
    private int _selectedMenuItem = 0;

    public int GetSelectedMenuItem()
    {
        return _selectedMenuItem;
    }

    public void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("\nMenu Options: \n");

        List<string> menuItems = new List<string>() 
        {
            "Start Breathing Activity", 
            "Start Reflecting Activity",
            "Start Listening Activity",
            "Quit"
        };

        for (int index = 0; index < menuItems.Count; index++)
        {   
            Console.WriteLine($"{index+1}. {menuItems[index]}");
        }

        Console.Write("\nSelect a choice from the menu (1-4): ");
        _selectedMenuItem =  int.Parse(Console.ReadLine());
    }

    public void StartBreathingActivity()
    {
        BreathingActivity breathingActivity = new BreathingActivity(
            "Breathing Activity",
            "relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing"
        );
        breathingActivity.DisplayStartMessage();
        breathingActivity.Run();
        breathingActivity.DisplayEndMessage();
    }

    public void StartReflectingActivity()
    {
        ReflectingActivity reflectingActivity = new ReflectingActivity(
            "Reflecting Activity",
            "reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life"
        );
        reflectingActivity.DisplayStartMessage();
        reflectingActivity.Run();
        reflectingActivity.DisplayEndMessage();
    }

    public void StartListingActivity()
    {
        ListingActivity listingActivity = new ListingActivity(
            "Listing Activity",
            "reflect on the good things in your life by having you list as many things as you can in a certain area"
        );
        listingActivity.DisplayStartMessage();
        listingActivity.Run();
        listingActivity.DisplayEndMessage();
    }
}