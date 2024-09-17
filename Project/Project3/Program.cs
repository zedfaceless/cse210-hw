using System;

namespace EventPlanningApp
{
    // Address class
    class Address
    {
        private string street;
        private string city;
        private string state;
        private string zipCode;

        public Address(string street, string city, string state, string zipCode)
        {
            this.street = street;
            this.city = city;
            this.state = state;
            this.zipCode = zipCode;
        }

        public override string ToString()
        {
            return $"{street}, {city}, {state} {zipCode}";
        }
    }

    // Base Event class
    abstract class Event
    {
        private string title;
        private string description;
        private string date;
        private string time;
        private Address address;

        protected Event(string title, string description, string date, string time, Address address)
        {
            this.title = title;
            this.description = description;
            this.date = date;
            this.time = time;
            this.address = address;
        }

        public string GetStandardDetails()
        {
            return $"Title: {title}\nDescription: {description}\nDate: {date}\nTime: {time}\nAddress: {address}";
        }

        public abstract string GetFullDetails();

        public string GetShortDescription()
        {
            return $"{this.GetType().Name}: {title} on {date}";
        }
    }

    // Lecture class
    class Lecture : Event
    {
        private string speaker;
        private int capacity;

        public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity)
            : base(title, description, date, time, address)
        {
            this.speaker = speaker;
            this.capacity = capacity;
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nType: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
        }
    }

    // Reception class
    class Reception : Event
    {
        private string rsvpEmail;

        public Reception(string title, string description, string date, string time, Address address, string rsvpEmail)
            : base(title, description, date, time, address)
        {
            this.rsvpEmail = rsvpEmail;
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nType: Reception\nRSVP Email: {rsvpEmail}";
        }
    }

    // OutdoorGathering class
    class OutdoorGathering : Event
    {
        private string weatherForecast;

        public OutdoorGathering(string title, string description, string date, string time, Address address, string weatherForecast)
            : base(title, description, date, time, address)
        {
            this.weatherForecast = weatherForecast;
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nType: Outdoor Gathering\nWeather: {weatherForecast}";
        }
    }

    // Main program
    class Program
    {
        static void Main(string[] args)
        {
            // Creating address instances
            Address address1 = new Address("123 Tech Blvd", "Tech City", "CA", "90001");
            Address address2 = new Address("456 Gala Ave", "Event Town", "NY", "10001");
            Address address3 = new Address("789 Park St", "Nature City", "OR", "97035");

            // Creating event instances
            Lecture lecture = new Lecture("Tech Talk", "An insightful lecture on AI.", "2024-08-01", "10:00 AM", address1, "Dr. Smith", 150);
            Reception reception = new Reception("Company Gala", "An evening of networking.", "2024-09-15", "7:00 PM", address2, "rsvp@company.com");
            OutdoorGathering outdoorGathering = new OutdoorGathering("Community Picnic", "Join us for a fun day in the park!", "2024-08-20", "11:00 AM", address3, "Sunny");

            // Generating marketing messages
            Event[] events = { lecture, reception, outdoorGathering };
            foreach (Event e in events)
            {
                Console.WriteLine(e.GetStandardDetails());
                Console.WriteLine();
                Console.WriteLine(e.GetFullDetails());
                Console.WriteLine();
                Console.WriteLine(e.GetShortDescription());
                Console.WriteLine(new string('-', 50));
            }
        }
    }
}
