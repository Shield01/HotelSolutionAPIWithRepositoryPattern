using HotelSolutionAPIWithRepositoryPattern.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSolutionAPIWithRepositoryPattern.Data_Access_Layer
{
    public class RoomModelRepository : IRoomModelRepository
    {
        private readonly ApplicationDbContext Db;
        public RoomModelRepository(ApplicationDbContext db)
        {
            Db = db;
        }

        public async Task<RoomModel> CreateRoom(RoomModel NewRoom)
        {
            var result = await Db.Rooms.AddAsync(NewRoom);
            await Db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<RoomModel>> GetAllRooms()
        {
            var result = await Db.Rooms.ToListAsync();
            return result;
        }

        public async Task<RoomModel> GetRoom(int id)
        {
            var value = await Db.Rooms.FirstOrDefaultAsync(x => x.RoomNumber == id);
            return value;
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<RoomModel>> GetRoomByStatus(string status)
        {
            IQueryable<RoomModel> query = Db.Rooms;
            if (status != null)
            {
                query = query.Where(x => x.IsOccupied == status);
            }

            return await query.ToListAsync();
        }

        public async Task<RoomModel> UpdateRoomStatus(int id, string status)
        {
            var value = await Db.Rooms.FirstOrDefaultAsync(x => x.RoomNumber == id);
            value.IsOccupied = status;
            await Db.SaveChangesAsync();
            return value;
            //throw new NotImplementedException();
        }
    }
}
