public class Cycling : Activity
{
    public float Speed { get; set; } // in mph or kph

    public Cycling(string date, int length, float speed)
        : base(date, length)
    {
        Speed = speed;
    }

    public override float GetDistance()
    {
        return Speed * (Length / 60f);
    }

    public override float GetSpeed()
    {
        return Speed;
    }

    public override float GetPace()
    {
        return 60f / Speed;
    }
}
