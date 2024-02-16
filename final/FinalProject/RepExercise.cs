// This type of exercise or physical is performed in a number of repetitions (_repTarget)
// and sets (_setTarget).
public class RepExercise : Exercise
{
    // _repTarget - number of exercises performed per set
    private int _repTarget;

    // _setTarget - blok of reps (between rests)
    private int _setTarget;

    // amount of completed sets
    private int _setCompleted = 0;

    public RepExercise(
        string name, 
        string description, 
        int repTarget, 
        int setTarget
        ) : base(name, description)
    {
        _repTarget = repTarget;
        _setTarget = setTarget;
    }

    override public bool IsCompleted()
    {
        return _setCompleted >= _setTarget;
    }

    public override void DoExercise()
    {
        _setCompleted++;
        Console.WriteLine($"Keep it up! You have completed one set ({_repTarget} repetitions).");
        if (IsCompleted())
        {
            Console.WriteLine($"Congratulations, you completed all sets ({_setTarget})!!!");
        }
    }

    override public string ExerciseInfo()
    {
        return $"{base.ExerciseInfo} -> Sets: {_setCompleted}/{_setTarget} ({_repTarget} reps)";
    }

    public override string MakeSavingFormat()
    {
        return $"RepExercise#{base.MakeSavingFormat()}#{_repTarget}#{_setTarget}#{IsCompleted()}";
    }
}