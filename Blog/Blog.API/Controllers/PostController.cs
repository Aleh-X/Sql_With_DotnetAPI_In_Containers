using Blog.API.EFConfigurations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Controllers;

[Route("api/v1/")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly BlogContext blogContext;

    public PostController(BlogContext blogContext)
    {
        this.blogContext = blogContext;
    }

    [HttpGet("posts")]
    public async Task<IActionResult> GetPosts()
    {
        var result = await this.blogContext.Posts.ToListAsync();

        return Ok(result);
    }
}

