using System;
using System.Threading;

public abstract class Activity
{
    protected Random random = new Random();

    public string Name { get; protected set; }
    public int Duration { get; private set; }

    public abstract void Start();

    protected void DisplayStartingMessage(string description)
    {
        Console.WriteLine($"Starting {Name} Activity...");
        Console.WriteLine(description);
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine($"You've completed the {Name} Activity!");
        Console.WriteLine($"Time spent: {Duration} seconds");
    }

    protected void PauseWithAnimation(int seconds)
    {
        int milliseconds = seconds * 1000;
        int animationIndex = 0;
        string[] spinner = { "|", "/", "-", "\\" };

        while (milliseconds > 0)
        {
            Console.Write(spinner[animationIndex % spinner.Length]);
            Thread.Sleep(100); // Adjust sleep time for animation speed
            Console.Write("\b"); // Move cursor back
            animationIndex++;
            milliseconds -= 100;
        }
    }

    protected void Pause(int seconds)
    {
        Thread.Sleep(seconds * 1000);
    }
}
