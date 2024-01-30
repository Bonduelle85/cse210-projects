public class Assignment
{
    private string _studentName;
    private string _topic;

    public Assignment()
    {
        _studentName = "empty";
        _topic = "empty";
    }
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    public string GetStudentName()
    {
        return _studentName;
    }

    public string SetStudentName(string studentName)
    {
        return _studentName = studentName;
    }

    public string GetTopic()
    {
        return _topic;
    }

    public string SetTopic(string topic)
    {
        return _topic = topic;
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}