using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();


        Console.WriteLine("Enter a list of numbers. Type 0 when finished");
        Console.Write("Enter number: ");
        string input = Console.ReadLine();
        int userNumber = int.Parse(input);

        if (input != "0")
        {
            numbers.Add(userNumber);
        }
        



        while (userNumber != 0)
        {
            Console.Write("Input a number: ");
            input = Console.ReadLine();
            userNumber = int.Parse(input);

            if (input != "0")
            {
                numbers.Add(userNumber);
            }
        
        }
        

        int total = 0;
        foreach (int n in numbers)
        {
            total += n;
        }

        Console.WriteLine($"The sum is: {total}");

        
        double average = (double)total / numbers.Count;
        Console.WriteLine($"The average is: {average}");


        int largest = numbers[0]; 
        foreach (int n in numbers)
        {
            if (n > largest)
            {
                largest = n;
            }
        }
        Console.WriteLine($"The largest number is: {largest}");
    }
}