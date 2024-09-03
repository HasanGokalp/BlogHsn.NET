using BlogHsn.NET.API.Contexts;
using BlogHsn.NET.API.Dtos;
using BlogHsn.NET.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogHsn.NET.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRoles()
        {
            var ctx = new BlogHsnCtx();
            var roles = ctx.Roles;
            ctx.Dispose();
            return Ok(roles);
        }

        [HttpPost]
        public IActionResult AddRole([FromBody] RoleDto role)
        {
            var ctx = new BlogHsnCtx();
            var entity = new Role
            {
                Yetki = role.Yetki
            };
            ctx.Roles.Add(entity);
            ctx.SaveChanges();
            ctx.Dispose();
            return Ok("Ok");
        }
    }
}
