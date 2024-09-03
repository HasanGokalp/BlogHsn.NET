namespace BlogHsn.NET.UI.Models.Dtos
{
    public class PostDto
    {
        public string Content { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public int? Viewed { get; set; }
    }
}
