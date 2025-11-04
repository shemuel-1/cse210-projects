using System;

class Program
{
    static void Main(string[] args)
    {

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        Console.Write("What is your guess?  ");
        string userGuess = Console.ReadLine();
        int guess = int.Parse(userGuess);

        while (guess != magicNumber)
        {

            if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
                Console.Write("What is your guess?  ");
                userGuess = Console.ReadLine();
                guess = int.Parse(userGuess);
            }

            else if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
                Console.Write("What is your guess?  ");
                userGuess = Console.ReadLine();
                guess = int.Parse(userGuess);
            }
        }

        if (guess == magicNumber)
            {
                Console.WriteLine("You guessed it!");
            }
        

    }
}