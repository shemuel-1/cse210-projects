using System;

class Program
{
    static void Main(string[] args)
    {
        PromptGenerator promptGen = new PromptGenerator();
        Entry entry = new Entry();
        Journal journal = new Journal();

        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();

        entry._date = dateText;
        entry._promptText = promptGen.GetRandomPrompt();

        Console.WriteLine("Welcome To The Journal Program!");

        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1.Write\n2.Display\n3.Load\n4.Save\n5.Quit");
        Console.Write("What would you like to do?  ");
        string userInput = Console.ReadLine();
        int input = int.Parse(userInput);

        while (input != 5)
        {


            if (input == 1)
            {
                entry.Display();
                journal.AddEntry(entry);
            }

            else if (input == 2)
            {
                journal.DisplayAll();
            }

            else if (input == 3)
            {
                Console.WriteLine("What is the filename?");
                string file = Console.ReadLine();
                journal.LoadFromFile(file);
            }

            else if (input == 4)
            {
                Console.WriteLine("What is the filename?");
                string file = Console.ReadLine();
                journal.SaveToFile(file);
            }
            
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1.Write\n2.Display\n3.Load\n4.Save\n5.Quit");
            Console.Write("What would you like to do?  ");
            userInput = Console.ReadLine();
            input = int.Parse(userInput);
        }
    }
}