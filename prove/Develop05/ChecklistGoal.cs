public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(
        string name, 
        string description, 
        int points, 
        int target, 
        int bonus) : base (name, description, points)
        {
            _amountCompleted = 0;
            _target = target;
            _bonus = bonus;
        }

    public ChecklistGoal(
        string name, 
        string description, 
        int points,
        int amountCompleted, 
        int target, 
        int bonus) : base (name, description, points)
        {
            _amountCompleted = amountCompleted;
            _target = target;
            _bonus = bonus;
        }
    
    public override void RecordEvent()
    {
        _amountCompleted++;
        Console.WriteLine($"Congratulations! You have earned {base.GetPoints()}!");
        if (IsComplete())
        {
            Console.WriteLine($"And bonus {_bonus}!");
            base.SetPoints(base.GetPoints() + _bonus);
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted>=_target;
    }

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal#{base.GetShortName()}#{base.GetDescription()}#{base.GetPoints()}#{_amountCompleted}#{_target}#{_bonus}";
    }
}