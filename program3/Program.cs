using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        Address address1 = new Address("123 Elm St", "Springfield", "IL", "USA");
        Event lecture = new Lecture("Lecture Title", "Lecture Description", "2024-07-18", "10:00 AM", address1, "John Doe", 100);

        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Event reception = new Reception("Reception Title", "Reception Description", "2024-07-19", "5:00 PM", address2, "rsvp@example.com");

        Address address3 = new Address("789 Pine St", "Vancouver", "BC", "Canada");
        Event outdoorGathering = new OutdoorGathering("Outdoor Gathering Title", "Outdoor Gathering Description", "2024-07-20", "2:00 PM", address3, "Sunny");

        List<Event> events = new List<Event> { lecture, reception, outdoorGathering };

        foreach (var eventItem in events)
        {
            Console.WriteLine(eventItem.GetFullDetails());
            Console.WriteLine();
        }
    }
}
