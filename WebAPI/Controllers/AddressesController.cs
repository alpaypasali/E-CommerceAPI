using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet("{userId}")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _addressService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


        [HttpPost("AddAddress")]
        public IActionResult AddAddress(Address address)
        {
            var result = _addressService.Add(address);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);


        }
    }
}