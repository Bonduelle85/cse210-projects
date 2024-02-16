abstract public class Exercise
{
    // exercise name
    private string _name;

    // exercise description
    private string _description;
    protected AnimationMaker _animationMaker;

    public Exercise(string name, string description)
    {
        _name = name;
        _description = description;
        _animationMaker = new AnimationMaker();
    }

    // name getter
    public string GetName()
    {
        return _name;
    }
    
    abstract public bool IsCompleted();

    abstract public void DoExercise();

    virtual public string ExerciseInfo()
    {
        return $"[{_name}] -- |{_description}|";
    }

    // This function generates a string to store class data in a file.
   virtual public string MakeSavingFormat()
   {
     return $"{_name}#{_description}";
   }
   
}