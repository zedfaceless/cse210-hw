using System;

class Program
{
    static Journal journal = new Journal();
    static PromptGenerator promptGenerator = new PromptGenerator();

    static async Task Main(string [] args)
    {
        while (true)
        // creating list of question so that the journal will be recorded. 
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the Journal");
                Console.WriteLine("3. Save the journal to file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option ");

                string choice = Console.ReadLine();
                switch (choice)
                // In order for this cases to function you must create static to make these things work.
                {
                    case "1":
                        WriteNewEntry();
                        break;
                    case "2":
                        DisplayJournal();
                        break;
                    case "3":
                        await SaveJournalToFileAsync();
                        break;
                    case "4":
                        await LoadJournalFromFileAsync();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again!");
                        break;
                }
            }
    }

    static void WriteNewEntry()
    {
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Entry entry = new Entry(prompt, response);
        journal.AddEntry(entry);
        Console.WriteLine("Your Entry has been added.");

    }
    static void DisplayJournal()
    {
        journal.DisplayEntries();
    }

    static async Task SaveJournalToFileAsync()
    {
        Console.Write("Enter filename to save the journal you write: ");
        string filename = Console.ReadLine();

        await Task.Run(() => journal.SaveToFile(filename));

        Console.WriteLine("Journal saved to file.");
    }

    static async Task LoadJournalFromFileAsync()
    {
        Console.Write("Enter filename to load up the journal: ");
        string filename = Console.ReadLine();

        await Task.Run(() => journal.LoadFromFile(filename));

        Console.WriteLine("Journal loaded from file.");
    }
}