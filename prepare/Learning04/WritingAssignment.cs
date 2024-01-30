public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment()
    {
        _title = "empty";
    }

    public WritingAssignment(
        string studentName, 
        string topic, 
        string title
        ) : base (studentName, topic)
    {
        _title = title;
    }

    public string GetTitle()
    {
        return _title;
    }

    public void SetTitle(string title)
    {
        _title = title;
    }

    public string GetWrittingInformation()
    {
        string studentName = base.GetStudentName();
        return $"{_title} by {studentName}";
    }
}