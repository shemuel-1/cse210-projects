using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your current grade percentage? ");
        string gradeInput = Console.ReadLine();
        int grade = int.Parse(gradeInput);
        string letter = "A";

        if (grade >= 90)
        {
            letter = "A";
        }

        else if (grade >= 80)
        {
            letter = "B";
        }

        else if (grade >= 70)
        {
            letter = "C";
        }

        else if (grade >= 60)
        {
            letter = "D";
        }

        else if (grade < 60)
        {
            letter = "F";
        }

        Console.WriteLine($"Your letter grade is {letter}");


        // To determine if student passed or failed
        if (grade >= 70)
        {
            Console.WriteLine("You passed!");
        }

        else
        {
            Console.WriteLine("Sorry. You failed");
        }
    }
}