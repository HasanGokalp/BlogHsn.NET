using BlogHsn.NET.API.Contexts;
using BlogHsn.NET.API.Dtos;
using BlogHsn.NET.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogHsn.NET.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPosts()
        {
            var ctx = new BlogHsnCtx();
            var posts = ctx.Posts.ToList();
            ctx.Dispose();
            return Ok(posts);
        }

        [HttpPost]
        public IActionResult AddPost([FromBody] PostDto post)
        {
            var ctx = new BlogHsnCtx();
            var entity = new Post
            {
                Content = post.Content,
                CreatedAt = post.CreatedAt,
                Viewed = post.Viewed,
                UserId = post.UserId ?? 1
            };
            ctx.Posts.Add(entity);
            ctx.SaveChanges();
            ctx.Dispose();
            return Ok();
        }
    }
}
