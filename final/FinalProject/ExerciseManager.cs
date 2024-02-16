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
        while (_menu.GetSelectedActionItem() != 6)
        {
            _menu.DisplayActions();
            switch(_menu.GetSelectedActionItem())
            {
                case 1:
                    CreateExercise();
                    break;
                case 2:
                    ShowAllExercises();
                    break;
                case 3:
                    DoExercises();
                    break;
                case 4:
                    LoadExercises(FirstFilename, _firstDayExercises);
                    LoadExercises(SecondFilename, _secondDayExercises);
                    LoadExercises(ThirdFilename, _thirdDayExercises);
                    break;
                case 5:
                    SaveExercises();
                    break;
                default:
                    break;
            }
        }
    }

    private void ShowAllExercises()
    {
        Console.WriteLine("Your first day exercises are: ");
        ListExercisesInfo(_firstDayExercises);
        Console.WriteLine("Your second day exercises are: ");
        ListExercisesInfo(_secondDayExercises);
        Console.WriteLine("Your third day exercises are: ");
        ListExercisesInfo(_thirdDayExercises);
    }

    private void CreateExercise()
    {
        // Local variables
        string name;
        string description;
        int timeDuration;
        int setTarget;
        int repTarget;
        int day;

        _menu.DisplayExerciseTypes();

        Console.Write("Select a training day [1-3]? ");
        day = int.Parse(Console.ReadLine());

        Console.Write("What is Exercise name? ");
        name = Console.ReadLine();

        Console.Write("What is exercise description? ");
        description = Console.ReadLine();
        
        switch(_menu.GetSelectedExerciseTypeItem())
            {
                case 1:
                    // Create RepExercise
                    Console.Write("How many repetitions per set? ");
                    repTarget = int.Parse(Console.ReadLine());
                    Console.Write("How many sets? ");
                    setTarget = int.Parse(Console.ReadLine());
                    RepExercise repExercise = new RepExercise(name, description, repTarget, setTarget);
                    AddToDay(repExercise, day);
                    break;
                case 2:
                    // Create TimeExercises
                    Console.Write("How many minutes are you going to do the exercise? ");
                    timeDuration = int.Parse(Console.ReadLine());
                    TimeExercise timeExercise = new TimeExercise(name, description, timeDuration);
                    AddToDay(timeExercise, day);
                    break;
                case 3:
                    // Create TimeRepExercise
                    Console.Write("How many minutes are you going to do the exercise? ");
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

    }

    private void DoExercises()
    {
        // local variables
        int day;
        string exerciseName;

        Console.Clear();
        _animationMaker.ShowLoading();
        Console.Write("Select a training day [1-3]");
        day = int.Parse(Console.ReadLine());

        Console.WriteLine("Your unfinished exercises are: ");

        switch(day)
            {
                case 1:
                    ListUnfinishedExercises(_firstDayExercises);
                    Console.Write("Enter Exercise name: ");
                    exerciseName = Console.ReadLine();
                    _firstDayExercises[exerciseName].DoExercise();
                    break;
                case 2:
                    ListUnfinishedExercises(_secondDayExercises);
                    Console.Write("Enter Exercise name: ");
                    exerciseName = Console.ReadLine();
                    _firstDayExercises[exerciseName].DoExercise();
                    break;
                case 3:
                    ListUnfinishedExercises(_thirdDayExercises);
                    Console.Write("Enter Exercise name: ");
                    exerciseName = Console.ReadLine();
                    _firstDayExercises[exerciseName].DoExercise();
                    break;
                default:
                    break;
            }
    }

    private void SaveExercises()
    {
        SaveToFile(_firstDayExercises, FirstFilename);
        SaveToFile(_secondDayExercises, SecondFilename);
        SaveToFile(_thirdDayExercises, ThirdFilename);
    }

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
                    repTarget = int.Parse(parts[4]);
                    setTarget = int.Parse(parts[5]);
                    RepExercise repExercise = new RepExercise (exerciseName, description, repTarget, setTarget);
                    exercises[repExercise.GetName()] = repExercise;
                    break;
                case "TimeExercise":
                    timeDuration = int.Parse(parts[3]);
                    isCompleted = bool.Parse(parts[4]);
                    TimeExercise timeExercise = new TimeExercise (exerciseName, description, timeDuration, isCompleted);
                    exercises[timeExercise.GetName()] = timeExercise;
                    break;
                case "TimeRepExercise":
                    timeDuration = int.Parse(parts[4]);
                    setTarget = int.Parse(parts[5]);
                    setCompleted = int.Parse(parts[6]);
                    TimeRepExercise timeRepExercise = new TimeRepExercise (exerciseName, description, timeDuration, setCompleted, setTarget);
                    exercises[timeRepExercise.GetName()] = timeRepExercise;
                    break;
                case "CustomExercise":
                    isCompleted = bool.Parse(parts[3]);
                    CustomExercise customExercise = new CustomExercise(exerciseName, description, isCompleted);
                    break;
            }
        }
    }

    private void ListExercisesInfo(Dictionary<string, Exercise> exercises)
    {
        
        List<Exercise> exerciseList = exercises.Values.ToList();
        for (int i = 0; i < exerciseList.Count; i++ )
        {
            if (exerciseList[i].IsCompleted())
            {
                Console.WriteLine($"{i + 1}. [V] {exerciseList[i].ExerciseInfo()}");
            }
            else
            {
                Console.WriteLine($"{i + 1}. [ ] {exerciseList[i].ExerciseInfo()}");
            }
        }
    }

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
    private void AddToDay(Exercise exercise, int day)
    {
        switch(day)
        {
            case 1:
                _firstDayExercises.Add(exercise.GetName(), exercise);
                break;
            case 2:
                _secondDayExercises.Add(exercise.GetName(), exercise);
                break;
            case 3:
                _thirdDayExercises.Add(exercise.GetName(), exercise);
                break;
            default:
                break;
        }
    }
}