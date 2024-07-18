using System;

public class Event
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
    public Address Address { get; set; }

    public Event(string title, string description, string date, string time, Address address)
    {
        Title = title;
        Description = description;
        Date = date;
        Time = time;
        Address = address;
    }

    public virtual string GetFullDetails()
    {
        return $"Event: {Title}\nDescription: {Description}\nDate: {Date}\nTime: {Time}\nAddress: {Address.ToString()}";
    }

    public string GetStandardDetails()
    {
        return GetFullDetails();
    }

    public string GetShortDescription()
    {
        return $"Event Type: {this.GetType().Name}\nTitle: {Title}\nDate: {Date}";
    }
}
