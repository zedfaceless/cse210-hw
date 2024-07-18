using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Video Title 1", "Author 1", 120);
        video1.AddComment(new Comment("User1", "Great video!"));
        video1.AddComment(new Comment("User2", "Thanks for sharing."));
        video1.AddComment(new Comment("User3", "Very informative."));

        Video video2 = new Video("Video Title 2", "Author 2", 150);
        video2.AddComment(new Comment("User4", "Awesome content!"));
        video2.AddComment(new Comment("User5", "Keep it up!"));

        Video video3 = new Video("Video Title 3", "Author 3", 180);
        video3.AddComment(new Comment("User6", "Loved it!"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}
