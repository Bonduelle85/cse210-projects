// This type of exercise or physical is performed over time in seconds (_timeDurationSec) 
// and takes into account the number of set repetitions (_set).
public class TimeRepExercise : Exercise
{
    // duration of the exercise
    private int _timeDurationSec;
    
    // _setTarget - blok of reps (between rests)
    private int _setTarget;
    
    // amount of completed sets
    private int _setCompleted;

    public TimeRepExercise(
        string name, 
        string description,
        int timeDurationSec,
        int setTarget
        ) : base(name, description)
    {
        _setCompleted = 0;
        _timeDurationSec = timeDurationSec;
        _setTarget = setTarget;
    }

    public TimeRepExercise(
        string name, 
        string description,
        int setCompleted,
        int setTarget,
        int timeDurationSec
        ) : base(name, description)
    {
        _timeDurationSec = timeDurationSec;
        _setTarget = setTarget;
        _setCompleted = setCompleted;
    }

    public override bool IsCompleted()
    {
        return _setCompleted >= _setTarget;
    }

    public override void DoExercise()
    {
        Console.Clear();
        Console.WriteLine("Get ready");
        base._animationMaker.ExerciseCountdown();
        Console.WriteLine("Go! Time: ");
        base._animationMaker.ExerciseCountdown(_timeDurationSec);
        _setCompleted++;
        Console.WriteLine($"\nWell done! You have completed one set ({_timeDurationSec} seconds).");
        if (IsCompleted())
        {
            Console.WriteLine($"\nCongratulations, you completed all sets ({_setTarget})!");
        }
    }

    public override string ExerciseInfo()
    {
        return $"{base.ExerciseInfo()} => Sets: {_setCompleted}/{_setTarget}. Time: {_timeDurationSec} seconds";
    }

    public override string MakeSavingFormat()
    {
        return $"TimeRepExercise#{base.MakeSavingFormat()}#{_setCompleted}#{_setTarget}#{_timeDurationSec}";
    }
}