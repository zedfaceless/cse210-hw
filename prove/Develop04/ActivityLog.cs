using System;
using System.Collections.Generic;

static class ActivityLog
{
    private static List<string> log = new List<string>();

    public static void LogActivity(string activityName, int duration)
    {
        string logEntry = $"Activity: {activityName}, Duration: {duration} seconds, Completed: {DateTime.Now}";
        log.Add(logEntry);
        Console.WriteLine("Activity logged.");
    }

    public static void DisplayLog()
    {
        Console.WriteLine("Activity Log:");
        foreach (var entry in log)
        {
            Console.WriteLine(entry);
        }
    }
}
