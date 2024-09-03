using System.ComponentModel.DataAnnotations;

namespace BlogHsn.NET.API.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Yetki { get; set; }
    }
}
