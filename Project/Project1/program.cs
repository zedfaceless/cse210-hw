using System;
using System.Collections.Generic;

namespace YouTubeCommentsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create 3-4 videos
            Video video1 = new Video("Introduction to C#", "John Doe", 600);
            Video video2 = new Video("Advanced C# Techniques", "Jane Smith", 1200);
            Video video3 = new Video("C# Design Patterns", "Alice Johnson", 1800);

            // Add comments to each video
            video1.AddComment(new Comment("User1", "Great introduction!"));
            video1.AddComment(new Comment("User2", "Very helpful, thanks!"));
            video1.AddComment(new Comment("User3", "Looking forward to more videos."));

            video2.AddComment(new Comment("User4", "Awesome techniques!"));
            video2.AddComment(new Comment("User5", "Very detailed explanation."));
            video2.AddComment(new Comment("User6", "Helpful for my project."));

            video3.AddComment(new Comment("User7", "Design patterns are crucial!"));
            video3.AddComment(new Comment("User8", "Great examples."));
            video3.AddComment(new Comment("User9", "Easy to understand."));

            // Store videos in a list
            List<Video> videos = new List<Video> { video1, video2, video3 };

            // Iterate through the list and display video details and comments
            foreach (Video video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.Length} seconds");
                Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
                Console.WriteLine("Comments:");

                foreach (Comment comment in video.GetComments())
                {
                    Console.WriteLine($" - {comment.CommenterName}: {comment.Text}");
                }

                Console.WriteLine();
            }
        }
    }
}
