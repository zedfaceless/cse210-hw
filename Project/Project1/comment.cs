namespace YouTubeCommentsApp
{
    public class Comment
    {
        public string CommenterName { get; private set; }
        public string Text { get; private set; }

        public Comment(string commenterName, string text)
        {
            CommenterName = commenterName;
            Text = text;
        }
    }
}
