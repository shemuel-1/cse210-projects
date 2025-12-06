using System;

class Program
{
    static void Main(string[] args)
    {
        int choice = 0;

        while (choice != 4)
        {
            DisplayMenu();

            choice = GetUserChoice();

            RunActivity(choice);
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Start Breathing Activity");
        Console.WriteLine("2. Start Reflecting Activity");
        Console.WriteLine("3. Start Listing Activity");
        Console.WriteLine("4. Quit");
    }

    static int GetUserChoice()
    {
        Console.Write("Select a choice from the menu: ");
        string input = Console.ReadLine();
        int choice = int.Parse(input);
        return choice;
    }

    static void RunActivity(int choice)
    {
        if (choice == 1)
        {
            BreathingActivity breathing = new BreathingActivity();
            breathing.Run();
        }
        else if (choice == 2)
        {
            ReflectingActivity reflecting = new ReflectingActivity();
            reflecting.Run();
        }
        else if (choice == 3)
        {
            ListingActivity listing = new ListingActivity();
            listing.Run();
        }
        else if (choice == 4)
        {
            Console.WriteLine("Thank you for using the Mindfulness App. Goodbye!");
        }
        else
        {
            Console.WriteLine("Invalid choice. Please try again.");
            Console.ReadLine();
        }
    }
}