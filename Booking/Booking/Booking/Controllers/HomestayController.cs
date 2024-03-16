using Booking.Repository;
using Booking.Request;
using Booking.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomestayController : ControllerBase
    {
        private readonly IHomestayRepository repository;
        public HomestayController(IHomestayRepository _repository)
        {
            repository = _repository;
        }
        [HttpGet("ListHomeStay")]
        [Authorize(Roles = "2")]
        public IActionResult Get(int id)
        {
            try
            {

                return Ok(repository.getAllHomeStay(id));
            }
            catch (Exception ex)
            {

                return BadRequest(null);
            }
        }
        [HttpGet("ListHomeStaybyAdmin")]
        [Authorize(Roles = "1")]
        public IActionResult Get()
        {
            try
            {

                return Ok(repository.getAllHomeStaybyAdmin());
            }
            catch (Exception ex)
            {

                return BadRequest(null);
            }
        }
        [HttpGet("ChangeStatus")]
        [Authorize(Roles = "2")]
        public void Change(int id,int status)
        {
            try
            {

                repository.change(id,status);
            }
            catch (Exception ex)
            {

                
            }
        }

        [HttpGet("AddHomestay")]
        [Authorize(Roles = "2")]
        public IActionResult AddHomestay()
        {
            try
            {

                return Ok(repository.GetCategories());
            }
            catch (Exception ex)
            {
                return BadRequest();

            }
        }
        [HttpPost("AddHomestay")]
        [Authorize(Roles = "2")]
        public void AddHomestay(AddHomestayRequest request)
        {
            try
            {

                repository.add(request);
            }
            catch (Exception ex)
            {


            }
        }
        [HttpGet("EditHomestay")]
        [Authorize(Roles = "2")]
        public IActionResult EditHomestay(int id)
        {
            try
            {
                return Ok(repository.getHomeStay(id));
                
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }
        [HttpPost("EditHomestay")]
        [Authorize(Roles = "2")]
        public void EditHomestay(EditHomestayRequest request)
        {
            try
            {
                repository.edit(request);

            }
            catch (Exception ex)
            {

            }
        }
        [HttpGet("Statistic")]
        [Authorize(Roles = "1")]
        public IActionResult Statistic()
        {
            try
            {

                return Ok(repository.Statistic());
            }
            catch (Exception ex)
            {

                return BadRequest(null);
            }
        }

    }
}
