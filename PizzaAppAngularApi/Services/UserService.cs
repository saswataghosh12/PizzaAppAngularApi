using Microsoft.EntityFrameworkCore;
using PizzaAppAngularApi.DB;
using PizzaAppAngularApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaAppAngularApi.Services
{
    public class UserService : IUserService
    {
        private PizzaAppDbContext _context;
        public UserService(PizzaAppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> DeleteUser(int userId)
        {
            var response = new ResponseModel();
            var userDetail = await _context.User.FindAsync(userId);
            if (userDetail == null)
            {
                response.IsSuccess = false;
                response.Messsage = "User not found";
            }
            else
            {
                response.IsSuccess = true;
                response.Messsage = "User deleted";
                _context.User.Remove(userDetail);
            }
            await _context.SaveChangesAsync();
            return response;
        }

        public async Task<User> GetUserDetailsById(int userId)
        {
            return await _context.User.FindAsync(userId);
        }

        public async Task<List<User>> GetUserList()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<ResponseModel> SaveUser(User userModel)
        {
            var response = new ResponseModel();
            var userDetail = _context.User.Where(x=>x.Email == userModel.Email)?.FirstOrDefault() ?? null;
            if (userDetail == null)
            {
                response.IsSuccess = true;
                response.Messsage = "User added successfully";
                await _context.User.AddAsync(userModel);
            }
            else
            {
                response.IsSuccess = false;
                response.Messsage = "User already exist";
            }
            await _context.SaveChangesAsync();
            return response;
        }

        public async Task<User> GetUserDetailsByEmailPassword(string email,string password)
        {
            return _context.User.Where(x => x.Email == email && x.Password == password)?.FirstOrDefault() ?? null;
        }
    }
}
