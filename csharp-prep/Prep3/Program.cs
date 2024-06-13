using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicnumber = randomGenerator.Next(1, 50);

        int guess = -1;

        while (guess !=magicnumber)
        {
            Console.Write("Guess my number: ");
            guess = int.Parse(Console.ReadLine());
            
            if (magicnumber > guess)
            {
                Console.WriteLine("Go Higher! ");
            }
            else if (magicnumber < guess)
            {
                Console.WriteLine("To high! Go lower! ");
            }
            else
            {
                Console.WriteLine("Amazing! You Guess it right");
            }

        }
    }
}