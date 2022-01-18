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
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<ResponseModel>> AddPizza(Pizza pizzaModel)
        {
            return await _pizzaService.SavePizza(pizzaModel);
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Pizza>>> GetPizzaList()
        {
            return await _pizzaService.GetPizzaList();
        }
    }
}
