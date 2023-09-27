using Blog.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.API.EFConfigurations;

public class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Post");

        builder.HasKey(post => post.Id);

        builder.Property(post => post.Content)
            .IsRequired()
            .HasMaxLength(1000);

        builder.HasData(new List<Post>
            {
                new Post
                {
                    Id = 1,
                    Title = "Post 1",
                    Content = "Post 1 Content"
                },
                new Post
                {
                    Id = 2,
                    Title = "Post 2",
                    Content = "Post 2 Content"
                }
            });
    }
}

