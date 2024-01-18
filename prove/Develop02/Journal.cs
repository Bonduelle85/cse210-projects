
public class Journal
{
    List<Entry> _entries = new List<Entry>();

    public void Display()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void Clear()
    {
        _entries.Clear();
    }

    public void SaveToFile(string fileName)
    {
        Console.WriteLine($"Saving to file {fileName}...");

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.MapToSavingFormat());
            }
        }
    }

    public void LoadFromFile(string fileName)
    {
        Console.WriteLine($"Loading from file {fileName}...");

        _entries.Clear();
        
        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] entryParts = line.Split("|");

            string date = entryParts[0];
            string time = entryParts[1];
            string promptText = entryParts[2];
            string entryText = entryParts[3];

            Entry entry = new Entry();
            
            entry.MapToEntry(date, time, promptText, entryText);

            _entries.Add(entry);
        }
    }
}