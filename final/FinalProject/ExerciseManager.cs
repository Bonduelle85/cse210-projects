// This class contains 3 blocks of exercises in three dictionaries 
// and performs operations on the exercises. 
// The blocks correspond to each day of training.


public class ExerciseManager
{
    // Constants for filenames
    private const string FirstFilename = "firstDay.txt", SecondFilename = "secondDay.txt", ThirdFilename = "thirdDay.txt";

    // Each day of training has its own Dictionary
    private Dictionary<string, Exercise> _firstDayExercises;
    private Dictionary<string, Exercise> _secondDayExercises;
    private Dictionary<string, Exercise> _thirdDayExercises;
    private Menu _menu;
    private AnimationMaker _animationMaker;

    public ExerciseManager()
    {
        _firstDayExercises = new Dictionary<string, Exercise>();
        _secondDayExercises = new Dictionary<string, Exercise>();
        _thirdDayExercises = new Dictionary<string, Exercise>();
        _menu = new Menu();
        _animationMaker = new AnimationMaker();
    }

    public void Start()
    {
        
        while (_menu.GetSelectedActionItem() != "6")
        {
            Console.Clear();
            _animationMaker.ShowLoading();
            _menu.DisplayActions();
            switch(_menu.GetSelectedActionItem())
            {
                case "1":
                    _animationMaker.ShowLoading();
                    CreateExercise();
                    _animationMaker.ShowSpinner();
                    break;
                case "2":
                    _animationMaker.ShowLoading();
                    ShowAllExercises();
                    _animationMaker.ShowSpinner();
                    break;
                case "3":
                    _animationMaker.ShowLoading();
                    DoExercises();
                    _animationMaker.ShowSpinner();
                    break;
                case "4":
                    _animationMaker.ShowLoading();
                    LoadExercises(FirstFilename, _firstDayExercises);
                    LoadExercises(SecondFilename, _secondDayExercises);
                    LoadExercises(ThirdFilename, _thirdDayExercises);
                    _animationMaker.ShowSpinner();
                    break;
                case "5":
                    _animationMaker.ShowLoading();
                    SaveExercises();
                    _animationMaker.ShowSpinner();
                    break;
                default:
                    break;
            }
        }
    }

    // This function shows all exercises (3 days) and info
    private void ShowAllExercises()
    {
        Console.Clear();
        Console.WriteLine("\nYour first day exercises are: ");
        ListExercisesInfo(_firstDayExercises);
        Console.WriteLine("\nYour second day exercises are: ");
        ListExercisesInfo(_secondDayExercises);
        Console.WriteLine("\nYour third day exercises are: ");
        ListExercisesInfo(_thirdDayExercises);

        Console.WriteLine("\nPress Enter to go to main menu.");
        Console.ReadLine();
    }

    // This function creates the exercise and adds it to the day
    private void CreateExercise()
    {
        // Local variables
        string name;
        string description;
        int timeDuration;
        int setTarget;
        int repTarget;
        string day;

        _menu.DisplayExerciseTypes();

        Console.Write("Select a training day [1-3]? ");
        day = Console.ReadLine();

        Console.Write("What is Exercise name? ");
        name = Console.ReadLine();

        Console.Write("What is exercise description? ");
        description = Console.ReadLine();
        
        switch(_menu.GetSelectedExerciseTypeItem())
            {
                case "1":
                    // Create RepExercise
                    Console.Write("How many repetitions per set? ");
                    repTarget = int.Parse(Console.ReadLine());
                    Console.Write("How many sets? ");
                    setTarget = int.Parse(Console.ReadLine());
                    RepExercise repExercise = new RepExercise(name, description, repTarget, setTarget);
                    AddToDay(repExercise, day);
                    break;
                case "2":
                    // Create TimeExercises
                    Console.Write("How many minutes are you going to do the exercise? ");
                    timeDuration = int.Parse(Console.ReadLine());
                    TimeExercise timeExercise = new TimeExercise(name, description, timeDuration);
                    AddToDay(timeExercise, day);
                    break;
                case "3":
                    // Create TimeRepExercise
                    Console.Write("How many seconds are you going to do the exercise? ");
                    timeDuration = int.Parse(Console.ReadLine());
                    Console.Write("How many sets? ");
                    setTarget = int.Parse(Console.ReadLine());
                    TimeRepExercise timeRepExercise = new TimeRepExercise(name, description, timeDuration, setTarget);
                    AddToDay(timeRepExercise, day);
                    break;
                default:
                    CustomExercise customExercise = new CustomExercise(name, description);
                    AddToDay(customExercise, day);
                    break;
            }

        Console.WriteLine($"\nThe exercise ({name}) has been created and added to the workout list.");
        Console.WriteLine("\nPress Enter to go to main menu.");
        Console.ReadLine();
    }

    // This function does the exercise
    private void DoExercises()
    {
        // local variables
        string day;

        if(_firstDayExercises.Keys.Count != 0 || _secondDayExercises.Keys.Count != 0 || _thirdDayExercises.Keys.Count != 0)
        {
            Console.Write("Select a training day [1-3]: ");
            day = Console.ReadLine();

            switch(day)
                {
                    case "1":
                        ListUnfinishedExercises(_firstDayExercises);
                        CheckUncompletedExercises(_firstDayExercises);
                        DoExerciseIfNameValidated(_firstDayExercises);
                        break;
                    case "2":
                        ListUnfinishedExercises(_secondDayExercises);
                        CheckUncompletedExercises(_secondDayExercises);
                        DoExerciseIfNameValidated(_secondDayExercises);
                        break;
                    case "3":
                        ListUnfinishedExercises(_thirdDayExercises);
                        CheckUncompletedExercises(_thirdDayExercises);
                        DoExerciseIfNameValidated(_thirdDayExercises);
                        break;
                    default:
                        break;
                }
        }
        else
        {
            Console.WriteLine("You have no exercises yet. Create exercises first.");
            Console.WriteLine("\nPress Enter to go to main menu.");
            Console.ReadLine();
        }
    }

    // This function saves all exercises (3 days)
    private void SaveExercises()
    {
        SaveToFile(_firstDayExercises, FirstFilename);
        SaveToFile(_secondDayExercises, SecondFilename);
        SaveToFile(_thirdDayExercises, ThirdFilename);
    }

    // This function loads all exercises from files into the corresponding Dictionaries
    private void LoadExercises(string filename, Dictionary<string, Exercise> exercises)
    {   
        string type;
        string exerciseName;
        string description;
        bool isCompleted;
        int setCompleted;
        int repTarget;
        int setTarget;
        int timeDuration;


        string[] lines = System.IO.File.ReadAllLines(filename);
        
        for (int i = 0; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("#");

            type = parts[0];
            exerciseName = parts[1];
            description = parts[2];

            switch(type)
            {
                case "RepExercise":
                    setCompleted = int.Parse(parts[3]);
                    setTarget = int.Parse(parts[4]);
                    repTarget = int.Parse(parts[5]);
                    RepExercise repExercise = new RepExercise (exerciseName, description, repTarget, setCompleted, setTarget);
                    exercises[exerciseName] = repExercise;
                    break;
                case "TimeExercise":
                    timeDuration = int.Parse(parts[3]);
                    isCompleted = bool.Parse(parts[4]);
                    TimeExercise timeExercise = new TimeExercise (exerciseName, description, timeDuration, isCompleted);
                    exercises[exerciseName] = timeExercise;
                    break;
                case "TimeRepExercise":
                    setCompleted = int.Parse(parts[3]);
                    setTarget = int.Parse(parts[4]);
                    timeDuration = int.Parse(parts[5]);
                    TimeRepExercise timeRepExercise = new TimeRepExercise (exerciseName, description, setCompleted, setTarget, timeDuration);
                    exercises[exerciseName] = timeRepExercise;
                    break;
                case "CustomExercise":
                    isCompleted = bool.Parse(parts[3]);
                    CustomExercise customExercise = new CustomExercise(exerciseName, description, isCompleted);
                    exercises[exerciseName] = customExercise;
                    break;
            }
        }
    }

    // This function displays exercises info
    private void ListExercisesInfo(Dictionary<string, Exercise> exercises)
    {
        
        List<Exercise> exerciseList = exercises.Values.ToList();
        for (int i = 0; i < exerciseList.Count; i++ )
        {
            if (exerciseList[i].IsCompleted())
            {
                Console.WriteLine($"{i + 1}. [X] {exerciseList[i].ExerciseInfo()}");
            }
            else
            {
                Console.WriteLine($"{i + 1}. [-] {exerciseList[i].ExerciseInfo()}");
            }
        }
    }

    // This function displays uncompleted exercises to the console
    private void ListUnfinishedExercises(Dictionary<string, Exercise> exercises)
    {
        Console.WriteLine();
        Console.WriteLine("Your current list of unfinished Exercises are:\n");
        List<Exercise> exerciseList = exercises.Values.ToList();
        // Creating Unfinished Exercise List
        List<Exercise> unfinishedExercises = exerciseList.FindAll(exercise => !exercise.IsCompleted());
        for (int i = 0; i < unfinishedExercises.Count; i++ )
        {
            Console.WriteLine($"{i + 1}. {unfinishedExercises[i].GetName()}");
        }
        Console.WriteLine();
    }

    // This function saves a Dictionary to the file
    private void SaveToFile(Dictionary<string, Exercise> exercises, string filename)
    {
         using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (KeyValuePair<string, Exercise> exercisePair in exercises)
            {
                outputFile.WriteLine(exercisePair.Value.MakeSavingFormat());
            }
        }
    }

    // This function adds an Exercise to the corresponding Dictionary (day)
    private void AddToDay(Exercise exercise, string day)
    {
        switch(day)
        {
            case "1":
                _firstDayExercises.Add(exercise.GetName(), exercise);
                break;
            case "2":
                _secondDayExercises.Add(exercise.GetName(), exercise);
                break;
            case "3":
                _thirdDayExercises.Add(exercise.GetName(), exercise);
                break;
            default:
                _firstDayExercises.Add(exercise.GetName(), exercise);
                break;
        }
    }

    // This function checks the validity of the Key
    private void DoExerciseIfNameValidated(Dictionary<string, Exercise> worklist)
    {
            bool isInvalidInput = true; 
            do
            {
                Console.Write("Enter Exercise name: ");
                string exerciseName = Console.ReadLine();
                
                if (_firstDayExercises.Keys.Contains(exerciseName))
                {
                    isInvalidInput = false;
                    Exercise currentExercises = worklist[exerciseName];
                    currentExercises.DoExercise();
                }
                else
                {
                    Console.Write("\nInvalid input. There is no exercise with this name.\n");
                }
        } while (isInvalidInput);
    }

    // This function checks for outstanding exercises and launches a Menu if there are no exercises
    private void CheckUncompletedExercises(Dictionary<string, Exercise> worklist)
    {
        if (worklist.Values.All(exercise => exercise.IsCompleted()))
        {
            Console.WriteLine("You have completed all the exercises!");
            _animationMaker.ShowSpinner();
            Start();
        }
    }
}