using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data;

public class BlogDataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost,1433;Database=Blog;User ID=sa;Password=Teste@123;Trusted_Connection=False;TrustServerCertificate=True;");
        //options.LogTo(Console.WriteLine);
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<User> Users { get; set; }
}
