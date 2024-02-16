// This class is responsible for performing animations in the application.

public class AnimationMaker
{
    public void ShowLoading(int seconds = 3)
    {
        Console.Clear();
        List<string> loadingStrings = new List<string>()
        {
            "...Loading...",
            "...lOading...",
            "...loAding...",
            "...loaDing...",
            "...loadIng...",
            "...loadiNg...",
            "...loadinG...",
        };
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            string str = loadingStrings[i];
            Console.Write(str);
            Thread.Sleep(100);
            Console.Write("\r" + new string(' ', Console.BufferWidth) + "\r");

            i++;

            if (i >= loadingStrings.Count)
            {
                i = 0;
            }
        }
    }

    public void ExerciseCountdown(int seconds = 5)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\r" + new string(' ', Console.BufferWidth) + "\r");
        }
    }

    public void ShowSpinner(int seconds = 3)
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
}