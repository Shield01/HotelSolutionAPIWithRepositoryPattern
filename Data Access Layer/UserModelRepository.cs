using HotelSolutionAPIWithRepositoryPattern.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSolutionAPIWithRepositoryPattern.Data_Access_Layer
{
    public class UserModelRepository : IUserModelRepository
    {
        public ApplicationDbContext Db;
        public UserModelRepository(ApplicationDbContext db)
        {
            Db = db;
        }
        public async Task<UserModel> AddUser(UserModel NewUser)
        {
            var value = await Db.Users.AddAsync(NewUser);
            await Db.SaveChangesAsync();
            return value.Entity;
            //throw new NotImplementedException();
        }

        public async Task DeleteUser(int id)
        {
            var result = await Db.Users.FirstOrDefaultAsync(x => x.Id == id);
            Db.Users.Remove(result);
            await Db.SaveChangesAsync();
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            var result = await Db.Users.ToListAsync();
            return result;
            //throw new NotImplementedException();
        }

        public async Task<UserModel> GetUser(int id)
        {
            var user = await Db.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserModel>> Search(string Name, string EmailAddress)
        {
            IQueryable<UserModel> query = Db.Users;
            if (!string.IsNullOrEmpty(Name))
            {
                query = query.Where(x => x.FirstName.Contains(Name) || x.LastName.Contains(Name));
            }
            if (EmailAddress != null)
            {
                query = query.Where(x => x.EmailAddress == EmailAddress);
            }

            return await query.ToListAsync();
            //throw new NotImplementedException();
        }

        public async Task<UserModel> UpdateUser(UserModel UpdatedUser)
        {
            var value = await Db.Users.FirstOrDefaultAsync(x => x.Id == UpdatedUser.Id);
            if (value != null)
            {
                value.Id = UpdatedUser.Id;
                value.FirstName = UpdatedUser.FirstName;
                value.LastName = UpdatedUser.LastName;
                value.Nationality = UpdatedUser.Nationality;
                value.PhoneNumber = UpdatedUser.PhoneNumber;
                value.EmailAddress = UpdatedUser.EmailAddress;
                value.UserType = UpdatedUser.UserType;
                value.Password = UpdatedUser.Password;

                await Db.SaveChangesAsync();

                return value;
            }
            else
            {
                return null;
            }
            //throw new NotImplementedException();
        }
    }
}
