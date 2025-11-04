using System;

class Program
{
    static void Main(string[] args)
    {
        static void Main()
        {
            DisplayMessage();

            string userName = PromptUserName();

            int number = PromptUserNumber();

            int squaredNumber = SquareNumber(number);

            DisplayResult(userName, squaredNumber);
        }
        
        static void DisplayMessage()
        {
            Console.WriteLine("Welcome to the Program!");
        }

        static string PromptUserName()
        {
            Console.Write("What is your name? ");
            string name = Console.ReadLine();
            return name;
        }

        static int PromptUserNumber()
        {
            Console.Write("What is your favourite number? ");
            string number = Console.ReadLine();
            int favNumber = int.Parse(number);
            return favNumber;
        }

        static int SquareNumber(int number)
        {
            int squaredNumber = number * number;
            return squaredNumber;
        }

        static void DisplayResult( string name , int squaredNumber)
        {
            Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
        }

        Main();
    }
}