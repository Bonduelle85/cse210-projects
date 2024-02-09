using System.IO;
public class GoalManager
{
    private Dictionary<string, Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new Dictionary<string, Goal>();
        _score = 0;
    }

    public void Start()
    {
        int userChoice = 0;
        Console.Clear();

        while (userChoice != 8)
        {
            DisplayPlayerInfo();

            ShowMainMenu();
            userChoice = int.Parse(Console.ReadLine());

            switch (userChoice)
                {
                    case 1 :
                        CreateGoal();
                        break;
                    case 2 :
                        ListGoalDetails();
                        break;
                    case 3 :
                        SaveGoals();
                        break;
                    case 4 :
                        LoadGoals();
                        break;
                    case 5 :
                        RecordEvent();
                        break;
                    case 6 :
                        ClearGoalList();
                        break;
                    case 7 :
                        ClearScore();
                        break;
                    default:
                        break;
                }
            }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.");
    }

    public void ListGoalTypes()
    {
        Console.WriteLine("\nThe types of Goals are: ");

        List<string> menuItems = new List<string>() 
        {
            "Simple Goal", 
            "Eternal Goal",
            "Checklist Goal",
        };

        for (int index = 0; index < menuItems.Count; index++)
        {   
            Console.WriteLine($"{index+1}. {menuItems[index]}");
        }
    }

    public void ListUnfinishedGoalNames()
    {
        Console.WriteLine();
        Console.WriteLine("Your current list of unfinished goals are:\n");
        List<Goal> goalList = _goals.Values.ToList();
        // Creating Unfinished Goal List
        List<Goal> unfinishedGoalList = goalList.FindAll(goal => !goal.IsComplete());
        for (int i = 0; i < unfinishedGoalList.Count; i++ )
        {
            Console.WriteLine($"{i + 1}. {unfinishedGoalList[i].GetShortName()}");
        }
        Console.WriteLine();
    }

    public void ListGoalDetails()
    {
        Console.WriteLine();
        Console.WriteLine("Your current list of goals are:\n");
        List<Goal> goalList = _goals.Values.ToList();
        for (int i = 0; i < goalList.Count; i++ )
        {
            if (goalList[i].IsComplete())
            {
                Console.WriteLine($"{i + 1}. [X] {goalList[i].GetDetailsString()}");
            }
            else
            {
                Console.WriteLine($"{i + 1}. [ ] {goalList[i].GetDetailsString()}");
            }
        }
    }

    public void CreateGoal()
    {
        ListGoalTypes();
        Console.Write("Which type of goal would you like to create [1-3]? ");

        int userChoice = int.Parse(Console.ReadLine());

        Console.Write("What is name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What are amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (userChoice)
            {
                case 1 :
                    SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                    _goals.Add(simpleGoal.GetShortName(), simpleGoal);
                    break;
                case 2 :
                    EternalGoal eternalGoal = new EternalGoal(name, description, points);
                    _goals.Add(eternalGoal.GetShortName(), eternalGoal);
                    break;
                case 3 :
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    int bonus = int.Parse(Console.ReadLine());
                    ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                    _goals.Add(checklistGoal.GetShortName(), checklistGoal);
                    break;
                default:
                    break;
            }

    }

    public void RecordEvent()
    {
        if(_goals.Keys.Count != 0)
        {
            // User input validation
            bool isInvalidInput = true; 
            do
            {
                ListUnfinishedGoalNames();
                Console.Write("Enter the NAME of the Goal you have accomplished: ");
                string goalName = Console.ReadLine();
                if (_goals.Keys.Contains(goalName))
                {
                    isInvalidInput = false;
                    Goal currentGoal = _goals[goalName];
                    currentGoal.RecordEvent();
                    _score += currentGoal.GetPoints();
                }
                else
                {
                    Console.Write("\nInvalid input. There is no goal with this name in the list.\n");
                }
        } while (isInvalidInput);
        }
        else
        {
            Console.WriteLine("You have no goals yet. Create a goal first");
        }
          
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (KeyValuePair<string, Goal> goalPair in _goals)
            {
                outputFile.WriteLine(goalPair.Value.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {   
        string type;
        string shortName;
        string description;
        int points;
        bool isComplete;
        int amountCompleted;
        int target;
        int bonus;

        Console.WriteLine("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        string[] lines = System.IO.File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("#");

            type = parts[0];
            shortName = parts[1];
            description = parts[2];
            points = int.Parse(parts[3]);

            switch(type)
            {
                case "SimpleGoal":
                    isComplete = bool.Parse(parts[4]);
                    SimpleGoal simpleGoal = new SimpleGoal (shortName, description, points, isComplete);
                    _goals.Add(shortName, simpleGoal);
                    break;
                case "EternalGoal":
                    EternalGoal eternalGoal = new EternalGoal (shortName, description, points);
                    _goals.Add(shortName, eternalGoal);
                    break;
                case "ChecklistGoal":
                    amountCompleted = int.Parse(parts[4]);
                    target = int.Parse(parts[5]);
                    bonus = int.Parse(parts[6]);
                    ChecklistGoal checklistGoal = new ChecklistGoal (shortName, description, points, amountCompleted, target, bonus);
                    _goals.Add(shortName, checklistGoal);
                    break;
            }
        }
    }

    private void ShowMainMenu()
    {
        Console.WriteLine("\nMenu Options: ");

        List<string> menuItems = new List<string>() 
        {
            "Create New Goal", 
            "List Goals",
            "Save Goals",
            "Load Goals",
            "Record Event",
            "Clear All Goals",
            "Clear Score",
            "Quit",
        };

        for (int index = 0; index < menuItems.Count; index++)
        {   
            Console.WriteLine($"{index+1}. {menuItems[index]}");
        }

        Console.Write("\nSelect a choice from the menu (1-6): ");
    }

    public void ClearGoalList()
    {
        Console.WriteLine("Do you really want to DELETE all goals? [Y/N]: ");
        string userChoice = Console.ReadLine();
        if (userChoice.ToLower() == "y")
        {
            Console.Write("Goal list has been cleared.");
            _goals.Clear();
        }
    }

    public void ClearScore()
    {
        Console.WriteLine("Do you really want to DELETE your score? [Y/N]: ");
        string userChoice = Console.ReadLine();
        if (userChoice.ToLower() == "y")
        {
            Console.Write("Your score deleted.");
            _score = 0;
        }
    }

}