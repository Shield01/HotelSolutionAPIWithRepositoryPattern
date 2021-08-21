using HotelSolutionAPIWithRepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSolutionAPIWithRepositoryPattern.Data_Access_Layer
{
    public interface IRoomModelRepository
    {
        public Task<IEnumerable<RoomModel>> GetAllRooms();
        public Task<RoomModel> GetRoom(int id);
        public Task<RoomModel> UpdateRoomStatus(int id, string status);
        public Task<IEnumerable<RoomModel>> GetRoomByStatus(string status);
        public Task<RoomModel> CreateRoom(RoomModel NewRoom);
    }
}
