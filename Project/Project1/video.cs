using System.Collections.Generic;

namespace YouTubeCommentsApp
{
    public class Video
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int Length { get; private set; } // Length in seconds
        private List<Comment> Comments { get; set; }

        public Video(string title, string author, int length)
        {
            Title = title;
            Author = author;
            Length = length;
            Comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public int GetCommentCount()
        {
            return Comments.Count;
        }

        public List<Comment> GetComments()
        {
            return Comments;
        }
    }
}
