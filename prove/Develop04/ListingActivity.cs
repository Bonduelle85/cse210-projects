public class ListingActivity : Activity
{
    private List<string> _userAnswers = new List<string>();
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    private Random _random = new Random();

    public ListingActivity(
        string name, 
        string description
        ) : base(name, description)
    {}

    public void Run()
    {
        Console.WriteLine("Get Ready...");
        ShowSpinner(5);

        Console.WriteLine("\nList as many responses you can to the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");

        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(base.GetDuration());
        
        while (DateTime.Now < endTime)
        {
            GetListFromUser();
        }

        Console.WriteLine($"You listed {_userAnswers.Count} items!");
        Console.WriteLine("\nHere are your answers: ");

        for (int i = 0; i < _userAnswers.Count; i++)
        {
            ShowSpinner(1);
            Console.Write($"{i+1}. ");
            DisplayUserAnswer(_userAnswers[i]);
        }
    }

    private string GetRandomPrompt()
    {
        int randomIndex = _random.Next(_prompts.Count);
        return _prompts[randomIndex];
    }

    private void GetListFromUser()
    {
        Console.Write(">");
        string answer = Console.ReadLine();
        _userAnswers.Add(answer);         
    }

    private void DisplayUserAnswer(string answer)
    {
        foreach (char ch in answer)
        {
            Console.Write(ch);
            Thread.Sleep(50);
        }
        Console.WriteLine();
    }
}