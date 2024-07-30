using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.Models;

namespace server.Controllers
{
    [Route("api/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public RoleController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateRole([FromBody] Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return Ok(role);

        }
    }
}
