public class OutdoorGathering : Event
{
    public string WeatherForecast { get; set; }

    public OutdoorGathering(string title, string description, string date, string time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        WeatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nWeather Forecast: {WeatherForecast}";
    }
}
