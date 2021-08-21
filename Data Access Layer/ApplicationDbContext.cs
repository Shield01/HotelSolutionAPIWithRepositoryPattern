using HotelSolutionAPIWithRepositoryPattern.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSolutionAPIWithRepositoryPattern.Data_Access_Layer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
                
        }

        public DbSet<RoomModel> Rooms { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}
