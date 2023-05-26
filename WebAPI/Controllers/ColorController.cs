using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {

        IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("getAllColor")]
        public IActionResult GetAll()
        {
            var result = _colorService.GetColors();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);


        }
        [HttpGet("getColorById")]
        public IActionResult GetById(int id)
        {
            var result = _colorService.GetColorID(id);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);


        }
        [HttpPost("AddColor")]
        public IActionResult AddColor(Color color)
        {
            var result = _colorService.Add(color);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);


        }
    }
}
