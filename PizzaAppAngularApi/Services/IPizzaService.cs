using PizzaAppAngularApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaAppAngularApi.Services
{
    public interface IPizzaService
    {
        Task<ResponseModel> SavePizza(Pizza pizza);
        Task<List<Pizza>> GetPizzaList();
    }
}
