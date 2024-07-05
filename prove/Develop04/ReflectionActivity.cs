using System;

class ReflectionActivity : Activity
{
    public ReflectionActivity()
    {
        Name = "Reflection";
    }

    public override void Start()
    {
        DisplayStartingMessage("This activity will help you reflect on times in your life when you have shown strength and resilience.");

        int duration = GetDurationFromUser();

        Console.WriteLine($"You have chosen a duration of {duration} seconds.");
        PauseWithAnimation(3); // Pause for 3 seconds before starting

        int timeLeft = duration;

        while (timeLeft > 0)
        {
            string prompt = GetRandomReflectionPrompt();
            Console.WriteLine($"Prompt: {prompt}");

            foreach (var question in GetRandomReflectionQuestions())
            {
                Console.WriteLine(question);
                PauseWithAnimation(3); // Pause for 3 seconds per question
                timeLeft -= 3;
                if (timeLeft <= 0)
                    break;
            }

            if (timeLeft > 0)
            {
                Console.WriteLine($"Time left: {timeLeft} seconds...");
                PauseWithAnimation(3); // Pause for 3 seconds before showing next prompt
            }
        }

        DisplayEndingMessage();
    }

    private string GetRandomReflectionPrompt()
    {
        string[] prompts = {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        return prompts[random.Next(prompts.Length)];
    }

    private string[] GetRandomReflectionQuestions()
    {
        string[] questions = {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        return questions;
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
