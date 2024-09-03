using System.ComponentModel.DataAnnotations;

namespace BlogHsn.NET.API.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? Viewed { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
