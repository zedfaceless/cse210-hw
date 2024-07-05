using System;

class ListingActivity : Activity
{
    private new Random random = new Random();

    public ListingActivity()
    {
        Name = "Listing";
    }

    public override void Start()
    {
        DisplayStartingMessage("This activity will help you reflect on the good things in your life by listing as many items as you can.");

        Console.WriteLine("Get ready to begin...");
        PauseWithAnimation(3); // Pause for 3 seconds before starting

        int itemCount = 0;
        bool continueListing = true;

        while (continueListing)
        {
            string prompt = GetRandomListingPrompt();
            Console.WriteLine($"Prompt: {prompt}");

            Console.WriteLine("Start listing...");

            while (true)
            {
                Console.Write($"{itemCount + 1}. ");
                PauseWithAnimation(2); // Pause for 2 seconds per item

                Console.WriteLine("Enter the next item (or type 'stop' to finish): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "stop")
                    break;

                itemCount++;
            }

            Console.WriteLine($"Number of items listed: {itemCount}");

            // Ask if the user wants to continue listing items
            Console.WriteLine("Do you want to continue listing items? (yes/no): ");
            string choice = Console.ReadLine();

            if (choice.ToLower() != "yes")
                continueListing = false;
        }

        DisplayEndingMessage();
    }

    private string GetRandomListingPrompt()
    {
        string[] prompts = {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt inspired this month?",
            "Who are some of your personal heroes?"
        };

        return prompts[random.Next(prompts.Length)];
    }
}
