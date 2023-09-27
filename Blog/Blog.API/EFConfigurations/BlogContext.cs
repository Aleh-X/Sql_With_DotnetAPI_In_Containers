using Blog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.EFConfigurations;

public class BlogContext : DbContext
{
    public BlogContext(DbContextOptions<BlogContext> options)
        : base(options)
    {
    }

    public DbSet<Post> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PostEntityTypeConfiguration());
    }
}

