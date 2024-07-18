using System;

public abstract class Activity
{
    public string Date { get; set; }
    public int Length { get; set; } // in minutes

    public Activity(string date, int length)
    {
        Date = date;
        Length = length;
    }

    public abstract float GetDistance();
    public abstract float GetSpeed();
    public abstract float GetPace();

    public virtual string GetSummary()
    {
        return $"Date: {Date}\nLength: {Length} minutes\nDistance: {GetDistance()} units\nSpeed: {GetSpeed()} units/hour\nPace: {GetPace()} units/minute";
    }
}
