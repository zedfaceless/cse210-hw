public class Address
{
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }

    public Address(string streetAddress, string city, string state, string country)
    {
        StreetAddress = streetAddress;
        City = city;
        State = state;
        Country = country;
    }

    public override string ToString()
    {
        return $"{StreetAddress}\n{City}, {State}\n{Country}";
    }
}
