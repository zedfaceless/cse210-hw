public class Swimming : Activity
{
    public int Laps { get; set; }
    private const float LapDistance = 50f; // assuming each lap is 50 meters

    public Swimming(string date, int length, int laps)
        : base(date, length)
    {
        Laps = laps;
    }

    public override float GetDistance()
    {
        return Laps * LapDistance / 1000f; // converting meters to kilometers
    }

    public override float GetSpeed()
    {
        return GetDistance() / (Length / 60f);
    }

    public override float GetPace()
    {
        return Length / GetDistance();
    }
}
