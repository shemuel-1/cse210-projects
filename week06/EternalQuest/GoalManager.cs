using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
    }

    private void UpdateLevel()
    {
        _level = (_score / 1000) + 1;
    }

    public void Start()
    {
        while (true)
        {
            DisplayPlayerInfo();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            Console.WriteLine();
        }
    }

    public void DisplayPlayerInfo()
    {
        UpdateLevel();
        Console.WriteLine($"You are Level {_level}.");
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine("-------------------------");
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("Your Goals are:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet. Create one!");
            return;
        }
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }
    
    private void ListGoalNames()
    {
         Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }


    public void CreateGoal()
    {
        try
        {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("  1. Simple Goal (one-time completion)");
            Console.WriteLine("  2. Eternal Goal (recurring)");
            Console.WriteLine("  3. Checklist Goal (multiple completions with a bonus)");
            Console.Write("Which type of goal would you like to create? ");
            string type = Console.ReadLine();

            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());

            switch (type)
            {
                case "1":
                    _goals.Add(new SimpleGoal(name, description, points));
                    break;
                case "2":
                    _goals.Add(new EternalGoal(name, description, points));
                    break;
                case "3":
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    int bonus = int.Parse(Console.ReadLine());
                    _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                    break;
                default:
                    Console.WriteLine("Invalid goal type. Goal not created.");
                    break;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number format. Goal not created.");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals to record. Please create a goal first.");
            return;
        }

        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        try
        {
            int goalIndex = int.Parse(Console.ReadLine()) - 1;

            if (goalIndex >= 0 && goalIndex < _goals.Count)
            {
                int previousLevel = _level;
                int pointsEarned = _goals[goalIndex].RecordEvent();

                if (pointsEarned > 0)
                {
                    _score += pointsEarned;
                    Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
                    Console.WriteLine($"You now have {_score} points.");
                    UpdateLevel();
                    if (_level > previousLevel)
                    {
                        Console.WriteLine($"LEVEL UP! You have reached Level {_level}!");
                    }
                }
                else
                {
                    Console.WriteLine("This goal has already been completed and cannot be recorded again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid goal selection.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);
                foreach (var goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("Goals saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            _goals.Clear();
            string[] lines = File.ReadAllLines(filename);

            if (lines.Length > 0)
            {
                _score = int.Parse(lines[0]);

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(new char[] { ':' }, 2);
                    if (parts.Length < 2) continue;

                    string goalType = parts[0];
                    string[] goalData = parts[1].Split(',');

                    string name = goalData[0];
                    string description = goalData[1];
                    int points = int.Parse(goalData[2]);

                    switch (goalType)
                    {
                        case "SimpleGoal":
                            bool isComplete = bool.Parse(goalData[3]);
                            _goals.Add(new SimpleGoal(name, description, points, isComplete));
                            break;
                        case "EternalGoal":
                            _goals.Add(new EternalGoal(name, description, points));
                            break;
                        case "ChecklistGoal":
                            int bonus = int.Parse(goalData[3]);
                            int target = int.Parse(goalData[4]);
                            int amountCompleted = int.Parse(goalData[5]);
                            _goals.Add(new ChecklistGoal(name, description, points, target, bonus, amountCompleted));
                            break;
                    }
                }
            }
            UpdateLevel();
            Console.WriteLine("Goals loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
            _goals.Clear(); 
            _score = 0;
        }
    }
}
