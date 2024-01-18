public class Entry
{
    string _date;
    string _time;
    string _promptText;
    string _entryText;

    public void Display()
    {
        Console.WriteLine($"Date: {_date}, Time: {_time} - Prompt: {_promptText}\n{_entryText}\n");
    }

    // To make the variables or attributes of the Entry class private
    // (and we haven’t studied the constructor yet), 
    // I decided to create 2 mappers for converting data.

    public string MapToSavingFormat()
    {
        return $"{_date}|{_time}|{_promptText}|{_entryText}|";
    }

    public void MapToEntry(string date, string time, string promptText, string entryText)
    {
        _date = date;
        _time = time;
        _promptText = promptText;
        _entryText= entryText;
    }
}