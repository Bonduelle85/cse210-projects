// This class describes an exercise that does not fit the criteria of other exercises.
public class CustomExercise : Exercise
{
    private bool _isCompleted;


    public CustomExercise(string name, string description) : base(name, description){}
    public CustomExercise(
        string name, 
        string description, 
        bool isCompleted
        ) : base(name, description)
    {
        _isCompleted = isCompleted;
    }

    public override bool IsCompleted()
    {
        return _isCompleted;
    }

    public override void DoExercise()
    {
        _isCompleted = true;
        Console.WriteLine($"Congratulations, you completed this Exercise!!!");
    }

    public override string MakeSavingFormat()
    {
        return $"CustomExercise#{base.MakeSavingFormat()}#{_isCompleted}";
    }
}