using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running("2024-07-18", 30, 5)); // 5 km in 30 minutes
        activities.Add(new Cycling("2024-07-19", 45, 20)); // 20 kph for 45 minutes
        activities.Add(new Swimming("2024-07-20", 60, 40)); // 40 laps in 60 minutes

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }
    }
}
