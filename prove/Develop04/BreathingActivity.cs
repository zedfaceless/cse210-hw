using System;
using System.Threading;

class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        Name = "Breathing";
    }

    public override void Start()
    {
        DisplayStartingMessage("This activity will help you relax by guiding you through deep breathing exercises.");

        int duration = GetDurationFromUser();

        Console.WriteLine($"You have chosen a duration of {duration} seconds.");
        PauseWithAnimation(3); // Pause for 3 seconds before starting

        int totalTimeElapsed = 0;
        int breatheCycleTime = 4; // Total time for one breathe in-out cycle (2 seconds in + 2 seconds out)

        while (totalTimeElapsed < duration)
        {
            Console.WriteLine("Breathe in...");
            PauseWithAnimation(2); // Pause for 2 seconds per breath in

            Console.WriteLine("Breathe out...");
            PauseWithAnimation(2); // Pause for 2 seconds per breath out

            totalTimeElapsed += breatheCycleTime;

            if (totalTimeElapsed < duration)
            {
                Console.WriteLine($"Time spent: {totalTimeElapsed} seconds...");
                PauseWithAnimation(2); // Pause for 2 seconds before next cycle
            }
        }

        // Display ending message only if the duration is fully completed
        if (totalTimeElapsed >= duration)
        {
            Console.WriteLine($"You've completed the Breathing Activity!");
            Console.WriteLine($"Time spent: {duration} seconds.");
            DisplayEndingMessage();
        }
    }

    private int GetDurationFromUser()
    {
        int duration = 0;
        while (true)
        {
            Console.Write("Enter duration (in seconds): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out duration) && duration > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
            }
        }
        return duration;
    }
}
