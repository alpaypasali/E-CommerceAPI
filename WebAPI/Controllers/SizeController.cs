using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        ISizeService _sizeService;

        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        [HttpGet("getAllSize")]
        public IActionResult GetAll()
        {
            var result = _sizeService.GetSize();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);


        }
        [HttpGet("getSizeById")]
        public IActionResult GetById(int id)
        {
            var result = _sizeService.GetSizeID(id);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);


        }
        [HttpPost("AddSize")]
        public IActionResult AddBrand(Size size)
        {
            var result = _sizeService.Add(size);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);


        }

        [HttpPost("AddSizesToProduct")]
        public IActionResult AddSizesToProduct(int productId, ICollection<SizeDTO> sizeDTOs)
        {
            var result = _sizeService.AddSizesToProduct(productId, sizeDTOs);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
