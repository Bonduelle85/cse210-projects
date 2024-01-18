public class PromptGenerator
{
    List<string> _prompts = new List<string>() {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "What activity did I do today that brought me the least pleasure?",
        "What was the strongest positive emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What was the strongest negative emotion I felt today?",
        "Which family or friend would I like to meet this week?",
        "What activity did I do today that brought me the most pleasure?",
        "What useful things did I do today?",
        "What useless things did I do today?",
        "If there was one thing I could avoid doing today, what would it be?"
    };

    public string GetRandomPrompt()
    {
        Random randomGenerator = new Random();
        int randomIndex = randomGenerator.Next(_prompts.Count);
        string result = _prompts[randomIndex];
        return result;
    }
}