public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public int GetDuration()
    {
        return _duration;
    }

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine($"\nThis activity will help you {_description}.");

        Console.Write("\nHow long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.Clear();
    }

    public void DisplayEndMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner();
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name}.");
        ShowSpinner();
    }

    protected void ShowSpinner(int seconds = 3)
    {
        List<Char> spinneChars = new List<char>()
        {
            '-',
            '\\',
            '|',
            '/',
            '-',
            '\\',
            '|',
            '/'
        };
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            char ch = spinneChars[i];
            Console.Write(ch);
            Thread.Sleep(100);
            Console.Write("\b \b");

            i++;

            if (i >= spinneChars.Count)
            {
                i = 0;
            }
        }
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}