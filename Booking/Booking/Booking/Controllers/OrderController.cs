using Booking.Repository;
using Booking.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository repository;
        public OrderController(IOrderRepository _repository)
        {
            repository = _repository;
        }

        [HttpGet("ListOrder")]
        [Authorize(Roles = "2")]
        public IActionResult ListOrder(int id,DateTime? checkin,DateTime? checkout)
        {
            try
            {

                return Ok(repository.getListOrder(id,checkin,checkout));
            }
            catch (Exception ex)
            {

                return BadRequest(null);
            }
        }
    }
}
