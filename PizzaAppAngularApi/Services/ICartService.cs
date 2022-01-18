using PizzaAppAngularApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaAppAngularApi.Services
{
    public interface ICartService
    {
        Task<ResponseModel> AddToCart(Cart cartItem);
        Task<List<Cart>> GetCartList(int ? userId);
    }
}
