using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade? ");
string answer = Console.ReadLine();
int percent;
if (int.TryParse(answer, out percent))
{
    string letter = "";
    if (percent >= 90)
    {
        letter = "A";
    }
    else if (percent >= 80)
    {
        letter = "B";
    }
    else if (percent >= 70)
    {
        letter = "C";
    }
    else if (percent >= 60)
    {
        letter = "D";
    }
    else
    {
        letter = "F";
    }

    // Adding plus and minus grades
    if (percent >= 60 && percent < 100)  // Only add + and - for valid grades
    {
        int lastDigit = percent % 10;
        Console.WriteLine("Last digit of percent: " + lastDigit);  // Debugging output

        if (lastDigit >= 7)
        {
            letter += "+";
        }
        else if (lastDigit < 3)
        {
            letter += "-";
        }
    }

    Console.WriteLine("Your grade is: " + letter);  // Output the letter grade

    if (percent >= 70)
    {
        Console.WriteLine("Congratulations! You passed!");
    }
}
else
{
    Console.WriteLine("Invalid input. Please enter a valid grade percentage.");
}


    }
}