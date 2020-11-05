using System;

namespace api.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DatePublished { get; set; }
        public string Author { get; set; }
        public byte[] ImageBytes { get; set; }
        public string ThumbnailUrl { get; internal set; }
    }
}