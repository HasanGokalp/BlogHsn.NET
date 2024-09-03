using Microsoft.EntityFrameworkCore;

namespace BlogHsn.NET.API.Contexts
{
    public class BlogHsnCtx : DbContext
    {
        public BlogHsnCtx(DbContextOptions<BlogHsnCtx> options) : base(options)
        {

        }

        public BlogHsnCtx()
        {

        }

        public DbSet<Entities.User> Users { get; set; }
        public DbSet<Entities.Post> Posts { get; set; }
        public DbSet<Entities.Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=BlogHsn.NET;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
