using System;

static class Menu
{
    public static int ShowMenuAndGetChoice()
    {
        Console.WriteLine("Select an activity:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Visualization Activity");
        Console.WriteLine("5. Exit");
        Console.Write("Enter your choice (1-5): ");

        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
            Console.Write("Enter your choice (1-5): ");
        }

        return choice;
    }
}
