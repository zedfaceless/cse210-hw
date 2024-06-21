using System;
using System.Net.Mail;

public class Entry 
{
    public string Prompt { get; set; }
    public string Response { get; set;}
    public string Date { get; set;}

    public Entry( string prompt, string response)

    {
        Prompt = prompt;
        Response = response;
        Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt {Prompt}");
        Console.WriteLine($"Response {Response}");
        Console.WriteLine(new string('-', 20));
    }

    public override string ToString()
    {
        return $"{Date}|{Prompt}|{Response}";
    }

    public static Entry FromString(string entryString)
    {
        var parts = entryString.Split('|');
        return new Entry(parts[1], parts[2]) {Date = parts[0] };

    }
}
