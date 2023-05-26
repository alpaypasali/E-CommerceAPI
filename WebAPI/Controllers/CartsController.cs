using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _cartService.GetCartByUserId(userId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _cartService.GetAllCarts();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost("add")]
        public IActionResult AddToCart(CartItem cartItem)
        {
            var result = _cartService.AddToCart(cartItem);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpDelete("remove")]
        public IActionResult RemoveFromCart(CartItem cartItem)
        {
            var result = _cartService.RemoveFromCart(cartItem);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpPut("update")]
        public IActionResult UpdateCart(Cart cart)
        {
            var result = _cartService.UpdateCart(cart);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpDelete("clear")]
        public IActionResult ClearCart(int cartId)
        {
            var result = _cartService.ClearCart(cartId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }
    }
}