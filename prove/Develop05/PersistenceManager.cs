using System;
using System.IO;

public static class PersistenceManager
{
    public static void SaveToFile(string fileName, string content)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.Write(content);
            }
            Console.WriteLine("File saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public static string ReadFromFile(string fileName)
    {
        string content = "";
        try
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                content = reader.ReadToEnd();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
        return content;
    }
}
