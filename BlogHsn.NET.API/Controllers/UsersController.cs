using BlogHsn.NET.API.Contexts;
using BlogHsn.NET.API.Dtos;
using BlogHsn.NET.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogHsn.NET.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            var ctx = new BlogHsnCtx();
            var users = ctx.Users;
            ctx.Dispose();
            return Ok(users);
        }
        [HttpPost]
        public IActionResult AddUser([FromBody] UserDto user)
        {
            var ctx = new BlogHsnCtx();
            var entity = new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            };
            ctx.Users.Add(entity);
            ctx.SaveChanges();
            ctx.Dispose();
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserDto user)
        {
            var ctx = new BlogHsnCtx();
            var entity = ctx.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            if (entity == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }
            ctx.Dispose();
            return Ok();
        }
    }
}
