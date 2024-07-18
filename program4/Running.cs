public class Running : Activity
{
    public float Distance { get; set; } // in miles or kilometers

    public Running(string date, int length, float distance)
        : base(date, length)
    {
        Distance = distance;
    }

    public override float GetDistance()
    {
        return Distance;
    }

    public override float GetSpeed()
    {
        return Distance / (Length / 60f);
    }

    public override float GetPace()
    {
        return Length / Distance;
    }
}
