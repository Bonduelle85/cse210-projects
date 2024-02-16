// This type of exercise or physical is performed over time (_timeDuration) 
// and takes into account the number of set repetitions (_set).
public class TimeRepExercise : Exercise
{
    // duration of the exercise
    private int _timeDuration;
    
    // _setTarget - blok of reps (between rests)
    private int _setTarget;
    
    // amount of completed sets
    private int _setCompleted = 0;

    public TimeRepExercise(
        string name, 
        string description,
        int timeDuration,
        int setTarget
        ) : base(name, description)
    {
        _timeDuration = timeDuration;
        _setTarget = setTarget;
    }

    public TimeRepExercise(
        string name, 
        string description,
        int timeDuration,
        int setCompleted,
        int setTarget
        ) : base(name, description)
    {
        _timeDuration = timeDuration;
        _setTarget = setTarget;
    }

    override public bool IsCompleted()
    {
        return _setCompleted >= _setTarget;
    }

    public override void DoExercise()
    {
        Console.Write("Get ready ");
        base._animationMaker.ExerciseCountdown();
        Console.WriteLine("Go! Time: ");
        base._animationMaker.ExerciseCountdown(_timeDuration);
        _setCompleted++;
        Console.WriteLine($"\nWell done! You have completed one set ({_timeDuration} minutes).");
        if (IsCompleted())
        {
            Console.WriteLine($"\nCongratulations, you completed all sets ({_setTarget})!!!");
        }
    }

    override public string ExerciseInfo()
    {
        return $"{base.ExerciseInfo} -> Sets: {_setCompleted}/{_setTarget}. Time: {_timeDuration} min";
    }

    public override string MakeSavingFormat()
    {
        return $"TimeRepExercise#{base.MakeSavingFormat()}#{_timeDuration}#{_setCompleted}#{_setTarget}#{IsCompleted()}";
    }
}