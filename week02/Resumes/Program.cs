using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Sofware Engineer";
        job1._company = "Microsoft";
        job1._endYear = 2070;
        job1._startYear = 2025;

        Job job2 = new Job();
        job2._jobTitle = "Graphic Designer";
        job2._company = "Meta";
        job2._endYear = 2070;
        job2._startYear = 2025;

        Resume resume1 = new Resume();
        resume1._name = "Samuel";
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);

        resume1.Display();
    }
}