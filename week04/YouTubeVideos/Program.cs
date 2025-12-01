using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create Video 1
        Video video1 = new Video("C# Basics Tutorial", "Code Master", 450);
        video1.AddComment(new Comment("Alice", "This tutorial is very helpful!"));
        video1.AddComment(new Comment("Bob", "Great explanation of classes."));
        video1.AddComment(new Comment("Charlie", "I finally understand inheritance now."));
        video1.AddComment(new Comment("Diana", "Best teacher on YouTube!"));
        videos.Add(video1);

        // Create Video 2
        Video video2 = new Video("Web Development Guide", "Web Pro", 720);
        video2.AddComment(new Comment("Eve", "Loved the HTML section."));
        video2.AddComment(new Comment("Frank", "CSS tips were amazing."));
        video2.AddComment(new Comment("Grace", "Looking forward to the JavaScript part."));
        videos.Add(video2);

        // Create Video 3
        Video video3 = new Video("Data Structures Explained", "Tech Talk", 600);
        video3.AddComment(new Comment("Henry", "Finally understand linked lists!"));
        video3.AddComment(new Comment("Ivy", "The examples were crystal clear."));
        video3.AddComment(new Comment("Jack", "Please make more videos on algorithms."));
        video3.AddComment(new Comment("Karen", "Saved me for my exam!"));
        videos.Add(video3);

        // Create Video 4
        Video video4 = new Video("Python for Beginners", "Python Guru", 540);
        video4.AddComment(new Comment("Leo", "Python is so much easier now!"));
        video4.AddComment(new Comment("Mona", "Best intro course ever."));
        video4.AddComment(new Comment("Nathan", "Great project examples."));
        videos.Add(video4);

        // Display all videos with their comments
        foreach (Video video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}