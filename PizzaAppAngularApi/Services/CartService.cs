using Microsoft.EntityFrameworkCore;
using PizzaAppAngularApi.DB;
using PizzaAppAngularApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaAppAngularApi.Services
{
    public class CartService : ICartService
    {
        private PizzaAppDbContext _context;
        public CartService(PizzaAppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> AddToCart(Cart cartItem)
        {
            var response = new ResponseModel();
            var cartDetails = _context.Cart.Where(x => x.id == cartItem.id)?.FirstOrDefault() ?? null;
            if (cartDetails == null)
            {
                response.IsSuccess = true;
                response.Messsage = "Pizza added successfully";
                await _context.Cart.AddAsync(cartItem);
            }
            else
            {
                response.IsSuccess = false;
                response.Messsage = "Cart already exist";
            }
            await _context.SaveChangesAsync();
            return response;
        }

        public async Task<List<Cart>> GetCartList(int? userId)
        {
            if (userId.HasValue)
                return await _context.Cart.Where(x => x.userId == userId).ToListAsync();
            else
                return await _context.Cart.ToListAsync();
        }
    }
}
