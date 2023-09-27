namespace Blog.API.Models;

public class Post
{
    public required int Id { get; set; }

    public required string Title { get; set; }

    public required string Content { get; set; }
}

