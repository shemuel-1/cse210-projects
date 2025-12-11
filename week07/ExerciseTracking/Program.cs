using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 03), 30, 4.8),
            new Cycling(new DateTime(2022, 11, 04), 60, 25.0),
            new Swimming(new DateTime(2022, 11, 05), 45, 60)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }
    }
}
