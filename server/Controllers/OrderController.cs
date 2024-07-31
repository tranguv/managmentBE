using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.Utilities;

namespace server.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public OrderController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAll()
        {
            var orders = await _context.Orders.ToListAsync();
            return Ok(orders);
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(p => p.Id == id);
        }

        // GET: api/order
        // Method to get all orders
        [HttpGet]
        public async Task<PaginatedList<Order>> GetAllOrders(int pageIndex, int pageSize)
        {
            var orders = await _context.Orders
                    .OrderBy(b => b.Id)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

            var count = await _context.Orders.CountAsync();
            var totalPages = (int)Math.Ceiling(count / (double)pageSize);
            return new PaginatedList<Order>(orders, count, pageIndex, totalPages);
        }
    }
}
