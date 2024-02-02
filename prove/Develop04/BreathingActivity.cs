public class BreathingActivity : Activity
{
    public BreathingActivity(
        string name, 
        string description
        ) : base(name, description)
    {
    }

    public void Run()
    {
        Console.WriteLine("Get Ready...");
        ShowSpinner();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(base.GetDuration()); 

        // First initial breathing cycle - 5 seconds (3 sec - inhalation, 2 sec exhalation)
        Console.Write("\nBreathe in...");
        ShowCountDown(2);
        Console.Write("\nBreathe out...");
        ShowCountDown(3);
        Console.WriteLine();

        while(DateTime.Now < endTime)
        {
            // One relaxing breathing cycle - 10 seconds (6 sec - inhalation, 4 sec exhalation)
            // We will round the time to a whole breathing cycle.
            Console.Write("\nBreathe in...");
            ShowCountDown(4);
            Console.Write("\nBreathe out...");
            ShowCountDown(6);
            Console.WriteLine();
        }

    }
}