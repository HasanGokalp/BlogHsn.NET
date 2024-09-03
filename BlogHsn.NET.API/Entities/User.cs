using System.ComponentModel.DataAnnotations;

namespace BlogHsn.NET.API.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public IEnumerable<Role> Roles { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
