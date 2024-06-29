using System;
using System.Collections.Generic;

class Program
{
    static List<Scripture> scriptures = new List<Scripture>();
    static Random random = new Random();

    static void Main()
    {
        LoadDefaultScriptures(); // Load default scriptures

        while (true)
        {
            ClearScreen();
            Console.WriteLine("Welcome to the Scripture Memorization Program\n");

            DisplayScripturesMenu();

            int choice = GetMenuChoice(1, scriptures.Count + 1);

            if (choice == 0)
            {
                break;
            }

            Scripture selectedScripture = scriptures[choice - 1];
            ManageScripture(selectedScripture);

            if (AllScripturesFullyMemorized())
            {
                Console.WriteLine("\nCongratulations! You have fully memorized all scriptures.");
                break;
            }

            if (!ContinueProgram())
            {
                break;
            }
        }

        Console.WriteLine("\nThank you for using the Scripture Memorization Program.");
    }

    static void LoadDefaultScriptures()
    {
        AddScripture("Alma 26:27", "Now when our hearts were depressed, and we were about to turn back, behold, the Lord comforted us, and said: Go amongst thy brethren, the Lamanites, and bear with patience thine afflictions, and I will give unto you success.");
        AddScripture("John 1:1", "In the beginning was the Word, and the Word was with God, and the Word was God.");
        AddScripture("Doctrine and Covenants 1:38", "What I the Lord have spoken, I have spoken, and I excuse not myself; and though the heavens and the earth pass away, my word shall not pass away, but shall all be fulfilled, whether by mine own voice or by the voice of my servants, it is the same.");
    }

    static void AddScripture(string reference, string text)
    {
        try
        {
            Reference parsedReference = ParseReference(reference);
            Scripture scripture = new Scripture(parsedReference, text);
            scriptures.Add(scripture);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding scripture '{reference}': {ex.Message}");
        }
    }

    static Reference ParseReference(string referenceString)
    {
        string[] parts = referenceString.Split(' ');

        if (parts.Length < 2)
        {
            throw new FormatException("Invalid reference format.");
        }

        string book = parts[0];
        string chapterVerse = parts[1];
        string[] chapterVerseParts = chapterVerse.Split(':');

        if (chapterVerseParts.Length != 2)
        {
            throw new FormatException("Invalid reference format.");
        }

        int chapter = int.Parse(chapterVerseParts[0]);

        string[] verseParts = chapterVerseParts[1].Split('-');

        int startVerse = int.Parse(verseParts[0]);

        int endVerse = startVerse;

        if (verseParts.Length > 1)
        {
            endVerse = int.Parse(verseParts[1]);
        }

        return new Reference(book, chapter, startVerse, endVerse);
    }

    static void ManageScripture(Scripture scripture)
    {
        while (true)
        {
            ClearScreen();
            scripture.Display();

            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Hide a word");
            Console.WriteLine("2. Show a hint");
            Console.WriteLine("3. Load a different scripture");
            Console.WriteLine("4. Add a new scripture");
            Console.WriteLine("Type 'quit' to exit.");
            Console.Write("Choose an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    scripture.HideRandomWord();
                    break;
                case "2":
                    scripture.ShowHint();
                    break;
                case "3":
                    return; // Exit ManageScripture to load a new scripture
                case "4":
                    AddNewScripture();
                    return; // Exit ManageScripture to add a new scripture
                case "quit":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            if (scripture.AllWordsHidden())
            {
                ClearScreen();
                Console.WriteLine("Congratulations! You have fully memorized this scripture.");
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                return; // Exit ManageScripture as scripture is fully memorized
            }
        }
    }

    static void AddNewScripture()
    {
        ClearScreen();
        Console.WriteLine("Enter the scripture reference (e.g., Alma 26:27):");
        string reference = Console.ReadLine().Trim();

        Console.WriteLine("\nEnter the scripture text:");
        string text = Console.ReadLine().Trim();

        try
        {
            AddScripture(reference, text);
            Console.WriteLine("\nScripture added successfully.");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError adding scripture: {ex.Message}");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
    }

    static void DisplayScripturesMenu()
    {
        Console.WriteLine("Choose a scripture to memorize:\n");
        for (int i = 0; i < scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scriptures[i].Reference.ToString()} - {scriptures[i].Text}");
        }
    }

    static int GetMenuChoice(int minValue, int maxValue)
    {
        int choice;
        while (true)
        {
            Console.Write("\nEnter your choice: ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= minValue && choice <= maxValue)
            {
                return choice;
            }
            else
            {
                Console.WriteLine($"Invalid choice. Please enter a number between {minValue} and {maxValue}.");
            }
        }
    }

    static void ClearScreen()
    {
        Console.Clear();
    }

    static bool AllScripturesFullyMemorized()
    {
        foreach (Scripture scripture in scriptures)
        {
            if (!scripture.AllWordsHidden())
            {
                return false;
            }
        }
        return true;
    }

    static bool ContinueProgram()
    {
        Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
        string input = Console.ReadLine();
        return input.ToLower() != "quit";
    }
}

class Reference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int StartVerse { get; private set; }
    public int EndVerse { get; private set; }
    public bool IsSingleVerse => StartVerse == EndVerse;

    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = verse;
        EndVerse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        if (IsSingleVerse)
        {
            return $"{Book} {Chapter}:{StartVerse}";
        }
        else
        {
            return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
        }
    }
}

class Scripture
{
    public Reference Reference { get; private set; }
    public string Text { get; private set; }
    private List<string> words;
    private List<bool> hiddenFlags;
    private Random random = new Random();

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Text = text;
        InitializeWords();
    }

    private void InitializeWords()
    {
        words = new List<string>();
        hiddenFlags = new List<bool>();

        string[] allWords = Text.Split(new char[] { ' ', ',', '.', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in allWords)
        {
            words.Add(word);
            hiddenFlags.Add(false);
        }
    }

    public void Display()
    {
        Console.WriteLine($"{Reference.ToString()} - {Text}");
        Console.WriteLine();
        for (int i = 0; i < words.Count; i++)
        {
            if (hiddenFlags[i])
            {
                Console.Write("____ ");
            }
            else
            {
                Console.Write($"{words[i]} ");
            }
        }
        Console.WriteLine();
    }

    public void HideRandomWord()
    {
        int index = random.Next(words.Count);
        while (hiddenFlags[index])
        {
            index = random.Next(words.Count);
        }
        hiddenFlags[index] = true;
    }

    public void ShowHint()
    {
        int index = random.Next(words.Count);
        while (!hiddenFlags[index])
        {
            index = random.Next(words.Count);
        }
        hiddenFlags[index] = false;
    }

    public bool AllWordsHidden()
    {
        foreach (bool flag in hiddenFlags)
        {
            if (!flag)
            {
                return false;
            }
        }
        return true;
    }
}
