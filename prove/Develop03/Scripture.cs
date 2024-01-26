public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        string[] words = text.Split(" ");
        foreach (string word in words)
        {
            Word newWord = new Word(word);
            _words.Add(newWord);
        }
    }

    public void HideRandomWords()
    {   
        Random randomGenerator = new Random();

        if (!_words.All(word => word.IsHidden()))
        {
            int numberToHide = _words.Count(word => !word.IsHidden());
            if (numberToHide % 2 == 0 || numberToHide > 1)
            {
                HideRandomWord(randomGenerator);
                HideRandomWord(randomGenerator);
            }
            else
            {
                HideRandomWord(randomGenerator);
            }
        }
    }

    public string GetDisplayText()
    {
        string result;
        if (_reference.IsStartVerseOnly())
        {
            result = $"{_reference.GetDisplayTextShort()}";
        }
        else
        {
            result = $"{_reference.GetDisplayText()}";
        }
 
        foreach (Word word in _words)
        {
            result += $"{word.GetDisplayText()} ";
        }
        return result;
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }


    private void HideRandomWord(Random randomGenerator)
    {
        int numberToHide = _words.Count(word => !word.IsHidden());
        int randomIndex = randomGenerator.Next(0, numberToHide-1);
        _words.FindAll(word => !word.IsHidden())[randomIndex].Hide();
    }
}