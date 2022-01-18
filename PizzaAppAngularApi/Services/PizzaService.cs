using Microsoft.EntityFrameworkCore;
using PizzaAppAngularApi.DB;
using PizzaAppAngularApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaAppAngularApi.Services
{
    public class PizzaService : IPizzaService
    {
        private PizzaAppDbContext _context;
        public PizzaService(PizzaAppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> SavePizza(Pizza pizza)
        {
            var response = new ResponseModel();
            var userDetail = _context.Pizza.Where(x => x.name == pizza.name || x.id == pizza.id)?.FirstOrDefault() ?? null;
            if (userDetail == null)
            {
                response.IsSuccess = true;
                response.Messsage = "Pizza added successfully";
                await _context.Pizza.AddAsync(pizza);
            }
            else
            {
                response.IsSuccess = false;
                response.Messsage = "Pizza already exist";
            }
            await _context.SaveChangesAsync();
            return response;
        }

        public async Task<List<Pizza>> GetPizzaList()
        {
            return await _context.Pizza.ToListAsync();
        }
    }
}
