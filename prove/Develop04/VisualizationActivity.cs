using System;

class VisualizationActivity : Activity
{
    public VisualizationActivity()
    {
        Name = "Visualization";
    }

    public override void Start()
    {
        DisplayStartingMessage("This activity will help you visualize calming scenes to reduce stress.");

        int duration = GetDurationFromUser();

        Console.WriteLine($"You have chosen a duration of {duration} seconds.");
        PauseWithAnimation(3); // Pause for 3 seconds before starting

        int timeLeft = duration;

        // Visualize for the specified duration
        while (timeLeft > 0)
        {
            // Replace this placeholder with your actual visualization logic
            Console.WriteLine($"Visualizing... Time left: {timeLeft} seconds.");
            PauseWithAnimation(1); // Pause for 1 second before updating

            timeLeft--;
        }

        DisplayEndingMessage();
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
