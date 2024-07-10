using System;
using System.Collections.Generic;
using System.IO;

public class GameManager
{
    private List<Goal> goals;
    private string goalsFilePath = "goals.txt"; // Example file path for saving goals

    public GameManager()
    {
        goals = new List<Goal>();
        LoadGoalsFromFile(); // Load existing goals from file
        InitializeDefaultGoals(); // Initialize default goals
    }

    private void InitializeDefaultGoals()
    {
        // Add default goals
        AddGoal(new SimpleGoal("Push up 10 times", 1000));
        AddGoal(new SimpleGoal("Reading Scripture", 100));
        AddGoal(new EternalGoal("Attending Church (Eternal Quest)", 10)); // Add points here
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEventForGoal(string goalName)
    {
        Goal goal = goals.Find(g => g.Name.Equals(goalName, StringComparison.OrdinalIgnoreCase));
        if (goal != null)
        {
            int pointsEarned = goal.RecordEvent();
            Console.WriteLine($"Event recorded for {goal.Name}, Points: {pointsEarned}");
        }
        else
        {
            Console.WriteLine($"Goal '{goalName}' not found.");
        }
    }

    public List<Goal> GetAllGoals()
    {
        return goals;
    }

    public void SaveGoalsToFile()
    {
        using (StreamWriter writer = new StreamWriter(goalsFilePath))
        {
            foreach (var goal in goals)
            {
                string typeName = GetGoalTypeName(goal); // Get type name manually
                writer.WriteLine($"{typeName},{goal.Name},{goal.Completed},{goal.Points}");
            }
        }
        Console.WriteLine("Game saved successfully.");
    }

    private string GetGoalTypeName(Goal goal)
    {
        if (goal.GetType() == typeof(SimpleGoal))
            return "SimpleGoal";
        else if (goal.GetType() == typeof(EternalGoal))
            return "EternalGoal";
        else if (goal.GetType() == typeof(ChecklistGoal))
            return "ChecklistGoal";
        // Add cases for other goal types as needed
        else
            throw new ArgumentException($"Unknown goal type: {goal.GetType().Name}");
    }

    private void LoadGoalsFromFile()
    {
        if (File.Exists(goalsFilePath))
        {
            goals.Clear();
            using (StreamReader reader = new StreamReader(goalsFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string typeName = parts[0];
                    string name = parts[1];
                    bool completed = Convert.ToBoolean(parts[2]);
                    int points = Convert.ToInt32(parts[3]);

                    Goal goal = null;
                    switch (typeName)
                    {
                        case "SimpleGoal":
                            goal = new SimpleGoal(name, points);
                            break;
                        case "EternalGoal":
                            goal = new EternalGoal(name, points); // Include points here
                            break;
                        case "ChecklistGoal":
                            // Adjust according to your ChecklistGoal constructor
                            goal = new ChecklistGoal(name, 10, 50, 500);
                            break;
                        // Add cases for other goal types as needed
                        default:
                            throw new ArgumentException($"Unknown goal type: {typeName}");
                    }

                    if (goal != null)
                    {
                        goal.Completed = completed;
                        goals.Add(goal);
                    }
                }
            }
        }
    }
}
