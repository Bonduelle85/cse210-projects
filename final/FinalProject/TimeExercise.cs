// This type of exercise or physical is performed over time (_timeDuration) 
// and does not count the number of repetitions (reps).
public class TimeExercise : Exercise
{
    // duration of the exercise
    private int _timeDurationMin;
    
    private bool _isCompleted;

    public TimeExercise(
        string name, 
        string description,
        int timeDurationMin
        ) : base(name, description)
    {
        _isCompleted = false;
        _timeDurationMin = timeDurationMin;
    }
    public TimeExercise(
        string name, 
        string description,
        int timeDurationMin,
        bool isCompleted
        ) : base(name, description)
    {
        _timeDurationMin = timeDurationMin;
        _isCompleted = isCompleted;
    }

    public override bool IsCompleted()
    {
        return _isCompleted;
    }

    public override void DoExercise()
    {
        Console.WriteLine($"\nYou completed {base.GetName()} ({_timeDurationMin} min)!");
    }

    override public string ExerciseInfo()
    {
        return $"{base.ExerciseInfo()} => Time: {_timeDurationMin} min)";
    }

    public override string MakeSavingFormat()
    {
        return $"TimeExercise#{base.MakeSavingFormat()}#{_timeDurationMin}#{_isCompleted}";
    }
}