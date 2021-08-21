using HotelSolutionAPIWithRepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSolutionAPIWithRepositoryPattern.Data_Access_Layer
{
    public interface IUserModelRepository
    {
        Task<IEnumerable<UserModel>> Search(string Name, string EmailAddress);
        Task<IEnumerable<UserModel>> GetAllUsers();
        Task <UserModel> GetUser(int id);
        Task<UserModel> AddUser(UserModel NewUser);
        Task<UserModel> UpdateUser(UserModel UpdatedUser);
        Task DeleteUser(int id);
    }
}
