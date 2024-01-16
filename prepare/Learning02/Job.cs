public class Job
{
    public string _company;
    public string _jobTitle;
    public int _stratYear;
    public int _endYear;

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_stratYear}-{_endYear}");
    }
}