using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaAppAngularApi.Models;
using PizzaAppAngularApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaAppAngularApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<ResponseModel>> AddToCart(Cart cartItemModel)
        {
            return await _cartService.AddToCart(cartItemModel);
        }


        [HttpGet]
        [Route("[action]/{userID}")]
        public async Task<ActionResult<List<Cart>>> GetCartList(int? userID)
        {
            return await _cartService.GetCartList(userID);
        }
    }
}
