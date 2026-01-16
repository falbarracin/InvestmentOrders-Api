using InvestmentOrders.Application.DTOs;
using InvestmentOrders.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentOrders.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _service;

        public OrdersController(OrderService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest request)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState); 

            var id = await _service.CreateAsync(request);

            return CreatedAtAction(
                nameof(GetById),
                new { id },
                null
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _service.GetByIdAsync(id);
            if (order == null) return NotFound();
            return Ok(order);
        }
    }
}
