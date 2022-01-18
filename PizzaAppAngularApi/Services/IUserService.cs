using PizzaAppAngularApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaAppAngularApi.Services
{
    public interface IUserService
    {
        /// <summary>
        /// get list of all users
        /// </summary>
        /// <returns></returns>
        Task<List<User>> GetUserList();

        /// <summary>
        /// get user details by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<User> GetUserDetailsById(int userId);

        /// <summary>
        ///  add edit user
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        Task<ResponseModel> SaveUser(User userModel);


        /// <summary>
        /// delete user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ResponseModel> DeleteUser(int userId);

        Task<User> GetUserDetailsByEmailPassword(string email, string password);
    }
}
