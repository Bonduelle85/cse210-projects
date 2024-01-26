// This class is a scripture repository. It contains scriptures from "Proverbs" CHAPTER 3
public class ScriptureLibrary
{
    private List<Scripture> _scriptures = new List<Scripture>()
    {
        new Scripture 
        (
            reference: new Reference(book: "Proverbs", chapter: 3, verse: 1, endVerse: 2),
            text: "My child, do not forget my teaching, but let your heart keep my commandments, for length of days and years of life and abundant welfare they will give you."
        ),
        new Scripture 
        (
            reference: new Reference(book: "Proverbs", chapter: 3, verse: 3, endVerse: 4),
            text: "Do not let loyalty and faithfulness forsake you; bind them around your neck; write them on the tablet of your heart. Then you will find favor and high regard in the sight of God and of people."
        ),
        new Scripture 
        (
            reference: new Reference(book: "Proverbs", chapter: 3, verse: 5, endVerse: 6),
            text: "Trust in the Lord with all your heart, and do not rely on your own insight. In all your ways acknowledge him, and he will make straight your paths."
        ),
        new Scripture 
        (
            reference: new Reference(book: "Proverbs", chapter: 3, verse: 7, endVerse: 8),
            text: "Do not be wise in your own eyes; fear the Lord and turn away from evil. It will be a healing for your flesh and a refreshment for your body."
        ),
        new Scripture 
        (
            reference: new Reference(book: "Proverbs", chapter: 3, verse: 9, endVerse: 10),
            text: "Honor the Lord with your substance and with the first fruits of all your produce; then your barns will be filled with plenty, and your vats will be bursting with wine."
        ),
        new Scripture 
        (
            reference: new Reference(book: "Proverbs", chapter: 3, verse: 11, endVerse: 12),
            text: "My child, do not despise the Lord`s discipline or be weary of his reproof, for the Lord reproves the one he loves, as a father the son in whom he delights."
        ),
        new Scripture 
        (
            reference: new Reference(book: "Proverbs", chapter: 3, verse: 13, endVerse: 14),
            text: "Happy are those who find wisdom and those who get understanding, for her income is better than silver and her revenue better than gold."
        ),
        new Scripture 
        (
            reference: new Reference(book: "Proverbs", chapter: 3, verse: 15, endVerse: 16),
            text: "She is more precious than jewels, and nothing you desire can compare with her. Long life is in her right hand; in her left hand are riches and honor."
        ),
        new Scripture 
        (
            reference: new Reference(book: "Proverbs", chapter: 3, verse: 17, endVerse: 18),
            text: "Her ways are ways of pleasantness, and all her paths are peace. She is a tree of life to those who lay hold of her; those who hold her fast are called happy."
        ),
        new Scripture 
        (
            reference: new Reference(book: "Proverbs", chapter: 3, verse: 19, endVerse: 20),
            text: "The Lord by wisdom founded the earth; by understanding he established the heavens; by his knowledge the deeps broke open, and the clouds drop down the dew."
        ),
        new Scripture 
        (
            reference: new Reference(book: "Proverbs", chapter: 3, verse: 21, endVerse: 22),
            text: "My child, do not let these escape from your sight: keep sound wisdom and prudence, and they will be life for your soul and adornment for your neck."
        ),
        new Scripture 
        (
            reference: new Reference(book: "Proverbs", chapter: 3, verse: 23, endVerse: 24),
            text: "Then you will walk on your way securely, and your foot will not stumble. If you sit down, you will not be afraid; when you lie down, your sleep will be sweet."
        ),
        new Scripture 
        (
            reference: new Reference(book: "Proverbs", chapter: 3, verse: 25, endVerse: 26),
            text: "Then you will not be afraid of sudden panic or of the storm that strikes the wicked, for the Lord will be your confidence and will keep your foot from being caught."
        ),
        new Scripture 
        (
            reference: new Reference(book: "Proverbs", chapter: 3, verse: 27, endVerse: 28),
            text: "Do not withhold good from those to whom it is due, when it is in your power to do it. Do not say to your neighbor, “Go and come again; tomorrow I will give it,” when you have it with you."
        ),
        new Scripture 
        (
            reference: new Reference(book: "Proverbs", chapter: 3, verse: 29, endVerse: 30),
            text: "Do not plan harm against your neighbor who lives trustingly beside you. Do not quarrel with anyone without cause, when no harm has been done to you."
        ),
        new Scripture 
        (
            reference: new Reference(book: "Proverbs", chapter: 3, verse: 31, endVerse: 32),
            text: "Do not envy the violent, and do not choose any of their ways, for the perverse are an abomination to the Lord, but the upright are in his confidence."
        ),
        new Scripture 
        (
            reference: new Reference(book: "Proverbs", chapter: 3, verse: 33, endVerse: 34),
            text: "The Lord`s curse is on the house of the wicked, but he blesses the abode of the righteous. Toward the scorners he is scornful, but to the humble he shows favor."
        ),
        new Scripture 
        (
            reference: new Reference(book: "Proverbs", chapter: 3, verse: 33),
            text: "The wise will inherit honor, but stubborn fools, disgrace."
        ),
    };
    
    public Scripture GetRamdomScripture()
    {
        Random randomGenerator = new Random();
        int randomIndex = randomGenerator.Next(0, _scriptures.Count-1);
        return _scriptures[randomIndex];
    }
}