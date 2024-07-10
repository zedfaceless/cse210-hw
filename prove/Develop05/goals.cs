public abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }
    public bool Completed { get; set; }

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
        Completed = false; // Initialize Completed to false by default
    }

    public abstract int RecordEvent();
    // Other methods as needed
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points)
    {
        // Additional constructor logic if needed
    }

    public override int RecordEvent()
    {
        Completed = true; // Example logic to mark goal as completed
        return Points; // Return points earned
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points)
    {
        // Additional constructor logic if needed
    }

    public override int RecordEvent()
    {
        // Example logic for EternalGoal record event
        // Since EternalGoal never really completes, logic may vary
        return Points; // Return points earned
    }
}

public class ChecklistGoal : Goal
{
    public int RequiredTimes { get; private set; }
    public int BonusPoints { get; private set; }
    public int TotalBonusPoints { get; private set; }

    public ChecklistGoal(string name, int requiredTimes, int bonusPoints, int totalBonusPoints) 
        : base(name, bonusPoints)
    {
        RequiredTimes = requiredTimes;
        BonusPoints = bonusPoints;
        TotalBonusPoints = totalBonusPoints;
    }

    public override int RecordEvent()
    {
        // Example logic for ChecklistGoal record event
        // Increment a counter or perform other necessary actions
        return Points; // Return points earned
    }
}
