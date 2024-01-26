public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {   
        string result = "";
        if (_isHidden)
        {
            result = ToHiddenWord(_text);
        } 
        else
        {
            result = _text;
        }
        return result;
    }

    // Text to underscores private function 
    private string ToHiddenWord(string text)
    {
        string hiddenWord = "";
        foreach (char letter in text)
        {
            hiddenWord += "_";
        }
        text = hiddenWord;
        return text;
    }
}