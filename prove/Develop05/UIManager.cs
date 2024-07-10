using System;
using System.Threading; // Required for Thread.Sleep

public class UIManager
{
    private GameManager gameManager;
    private string lastInput; // Track last user input

    public UIManager(GameManager manager)
    {
        gameManager = manager;
        lastInput = string.Empty;
    }

    public void Run()
    {
        Console.WriteLine("Welcome to Eternal Quest!");

        while (true)
        {
            DisplayMenu();

            string input = Console.ReadLine().Trim();
            lastInput = input; // Update last input

            switch (input)
            {
                case "1":
                    RecordEvent();
                    break;
                case "2":
                    AddGoal();
                    break;
                case "3":
                    SaveGame();
                    break;
                case "4":
                    WriteJournal();
                    break;
                case "5":
                    ShowAllGoals();
                    break;
                case "6":
                    ShowAllPoints();
                    break;
                case "7":
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        }
    }

    private void DisplayMenu()
    {
        Console.WriteLine("\nChoose Action:");
        Console.WriteLine("1. Record Event");
        Console.WriteLine("2. Add a Goal");
        Console.WriteLine("3. Save Game");
        Console.WriteLine("4. Write Journal");
        Console.WriteLine("5. Show all Goals");
        Console.WriteLine("6. Show all points");
        Console.WriteLine("7. Exit");

        Console.Write("Please Enter a number: ");
    }

    private void RecordEvent()
    {
        Console.WriteLine("Select a goal to record an event:");
        int count = 1;
        foreach (var goal in gameManager.GetAllGoals())
        {
            Console.WriteLine($"{count}. {goal.Name}");
            count++;
        }

        Console.Write("Enter the number of the goal: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= gameManager.GetAllGoals().Count)
        {
            string goalName = gameManager.GetAllGoals()[choice - 1].Name;
            gameManager.RecordEventForGoal(goalName);
        }
        else
        {
            Console.WriteLine("Invalid input. Please try again.");
        }
    }

    private void AddGoal()
    {
        Console.WriteLine("Enter the name of the goal you want to add:");
        string goalName = Console.ReadLine().Trim();

        // Example: Add a simple goal with fixed points
        gameManager.AddGoal(new SimpleGoal(goalName, 500));
        Console.WriteLine($"Goal '{goalName}' added successfully.");
    }

    private void SaveGame()
    {
        Console.WriteLine("Saving game...");
        // Show loading spinner
        ShowLoadingSpinner();

        // Example: Simulate saving delay with Thread.Sleep
        Thread.Sleep(2000); // Simulate 2 seconds delay

        // Save last input
        SaveLastInput();

        // Save goals
        gameManager.SaveGoalsToFile();

        Console.WriteLine("Game saved successfully.");
    }

    private void ShowLoadingSpinner()
    {
        Console.Write("Saving ");
        string[] spinner = { "/", "-", "\\", "|" };
        for (int i = 0; i < 10; i++)
        {
            Console.Write(spinner[i % 4]);
            Thread.Sleep(200); // Adjust sleep time for spinner speed
            Console.Write("\b");
        }
    }

    private void SaveLastInput()
    {
        // Example: Save last input to a file or database
        Console.WriteLine($"Saving last input: {lastInput}");
        // Implement saving mechanism
    }

    private void WriteJournal()
    {
        Console.WriteLine("Enter your journal entry:");
        string journalEntry = Console.ReadLine().Trim();

        // Example: Save journal entry to a file or database
        SaveJournalEntry(journalEntry);

        Console.WriteLine("Journal entry saved successfully.");
    }

    private void SaveJournalEntry(string entry)
    {
        // Example: Save journal entry to a file or database
        // Implement saving mechanism
        Console.WriteLine($"Saving journal entry: {entry}");
    }

    private void ShowAllGoals()
    {
        Console.WriteLine("\nAll Goals:");
        foreach (var goal in gameManager.GetAllGoals())
        {
            string status = goal.Completed ? "[X]" : "[ ]";
            Console.WriteLine($"{goal.Name} {status} - Points: {goal.Points}");
        }
    }

    private void ShowAllPoints()
    {
        int totalPoints = 0;
        foreach (var goal in gameManager.GetAllGoals())
        {
            totalPoints += goal.Points;
        }
        Console.WriteLine($"\nTotal Points: {totalPoints}");
    }
}
