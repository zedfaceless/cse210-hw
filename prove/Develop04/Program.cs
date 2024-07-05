using System;

class Program
{
    static void Main()
    {
        bool exit = false;
        do
        {
            int choice = Menu.ShowMenuAndGetChoice();

            switch (choice)
            {
                case 1:
                    StartActivity(new BreathingActivity());
                    break;
                case 2:
                    StartActivity(new ReflectionActivity());
                    break;
                case 3:
                    StartActivity(new ListingActivity());
                    break;
                case 4:
                    StartActivity(new VisualizationActivity());
                    break;
                case 5:
                    exit = true;
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        } while (!exit);
    }

    static void StartActivity(Activity activity)
    {
        Console.WriteLine($"Starting {activity.Name} Activity...");
        activity.Start();
    }
}
