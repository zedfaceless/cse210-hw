using System;
using System.Threading;

static class Animation
{
    public static void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("-");
            Thread.Sleep(1000); // Pause for 1 second
            Console.Write("\b \b"); // Erase the spinner
        }
        Console.WriteLine(); // Move to the next line after spinner
    }
}
