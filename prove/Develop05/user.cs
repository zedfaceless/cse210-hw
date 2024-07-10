using System;

public class User
{
    public string Username { get; set; }
    public int Level { get; set; }
    public int ExperiencePoints { get; set; }

    public void GainExperience(int points)
    {
        ExperiencePoints += points;
        // Check if user levels up
        int experienceRequiredForNextLevel = CalculateExperienceRequiredForNextLevel();
        if (ExperiencePoints >= experienceRequiredForNextLevel)
        {
            Level++;
            ExperiencePoints -= experienceRequiredForNextLevel;
            Console.WriteLine($"Congratulations! You've leveled up to Level {Level}.");
        }
    }

    private int CalculateExperienceRequiredForNextLevel()
    {
        // Example: Increase experience requirement exponentially for each level
        return Level * 100;
    }
}

// Implement other user-related classes in this file
