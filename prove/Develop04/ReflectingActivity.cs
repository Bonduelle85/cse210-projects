public class ReflectingActivity : Activity
{

    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else",
        "Think of a time when you did something really difficult",
        "Think of a time when you helped someone in need",
        "Think of a time when you did something truly selfless"
    };
    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private Random _random = new Random();

    public ReflectingActivity(
        string name, 
        string description
        ) : base(name, description)
        {}

    public void Run()
    {
        Console.WriteLine("Get Ready...");
        ShowSpinner();

        Console.WriteLine("\nConsider the following prompt:");
        DisplayPrompt();

        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("\nNow ponder on each of the following questions as they relate to this experience.");

        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.Clear();
        DisplayQuestions();
    }

    private string GetRandomPrompt()
    {
        int randomIndex = _random.Next(_prompts.Count);
        return _prompts[randomIndex];
    }

    private string GetRandomQuestion()
    {
        int randomIndex = _random.Next(_questions.Count);
        return _questions[randomIndex];
    }

    private void DisplayPrompt()
    {
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
    }

    private void DisplayQuestions()
    {

        // Each question takes 10 seconds. 
        int numberOfquestions = base.GetDuration() / 10;

        for (int i = numberOfquestions; i > 0; i--)
        {
            Console.Write($"> {GetRandomQuestion()} ");
            ShowSpinner(10);
            Console.WriteLine();
        }
    }
}