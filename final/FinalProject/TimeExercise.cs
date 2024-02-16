// This type of exercise or physical is performed over time (_timeDuration) 
// and does not count the number of repetitions (reps).
public class TimeExercise : Exercise
{
    // duration of the exercise
    private int _timeDuration;
    
    private bool _isCompleted = false;

    public TimeExercise(
        string name, 
        string description,
        int timeDuration
        ) : base(name, description)
    {
        _timeDuration = timeDuration;
    }
    public TimeExercise(
        string name, 
        string description,
        int timeDuration,
        bool isCompleted
        ) : base(name, description)
    {
        _timeDuration = timeDuration;
        _isCompleted = isCompleted;
    }

    public override bool IsCompleted()
    {
        return _isCompleted;
    }

    public override void DoExercise()
    {
        Console.Write("Get ready ");
        base._animationMaker.ExerciseCountdown();
        Console.WriteLine("Go! Time: ");
        base._animationMaker.ExerciseCountdown(_timeDuration);
        _isCompleted = true;
        Console.WriteLine($"Congratulations, you completed {base.GetName()} ({_timeDuration} minutes)!!!");
    }

    override public string ExerciseInfo()
    {
        return $"{base.ExerciseInfo} -> Time: {_timeDuration} min)";
    }

    public override string MakeSavingFormat()
    {
        return $"TimeExercise#{base.MakeSavingFormat()}#{_timeDuration}#{_isCompleted}";
    }
}