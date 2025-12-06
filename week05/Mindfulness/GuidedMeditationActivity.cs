using System;
using System.Collections.Generic;

public class GuidedMeditationActivity : Activity
{
    private List<string> _guidanceSteps;

    public GuidedMeditationActivity() : base("Guided Meditation Activity", "This activity will guide you through a peaceful meditation session. Find a quiet place, sit comfortably, and follow the guidance to achieve a state of calm and inner peace.")
    {
        _guidanceSteps = new List<string>
        {
            "Take a deep breath.",
            "Focus on the sensation of your breath entering and leaving your body.",
            "Notice any tension in your shoulders and let it melt away.",
            "Imagine yourself in a peaceful, serene place.",
            "Feel the warmth of the sun on your skin.",
            "Listen to the gentle sounds of nature around you.",
            "Release any thoughts that come to mind and return to your breath.",
            "Feel a sense of calm spreading through your entire body.",
            "You are safe, relaxed, and at peace.",
            "Begin to deepen your breath and prepare to return to the present moment."
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine();
        Console.WriteLine("Get ready to begin your guided meditation...");
        ShowSpinner(3);
        Console.WriteLine();

        Random random = new Random();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int stepIndex = 0;

        while (DateTime.Now < endTime)
        {
            string step = _guidanceSteps[stepIndex % _guidanceSteps.Count];
            Console.WriteLine($"> {step}");
            ShowSpinner(5);
            Console.WriteLine();
            stepIndex++;
        }

        Console.WriteLine("Now, slowly return your awareness to the present moment...");
        ShowCountdown(3);
        Console.WriteLine();

        DisplayEndingMessage();
    }

    public string GetRandomGuidanceStep()
    {
        Random rand = new Random();
        int index = rand.Next(_guidanceSteps.Count);
        return _guidanceSteps[index];
    }
}
