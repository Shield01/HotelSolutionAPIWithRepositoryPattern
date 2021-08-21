using HotelSolutionAPIWithRepositoryPattern.Data_Access_Layer;
using HotelSolutionAPIWithRepositoryPattern.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelSolutionAPIWithRepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomModelRepository ModelRepository;
        public RoomsController(IRoomModelRepository modelRepository)
        {
            ModelRepository = modelRepository;
        }
        // GET: api/<RoomsController>
        [HttpGet]
        public async Task<ActionResult>  Get()
        {
            return Ok(await ModelRepository.GetAllRooms());
            //return new string[] { "value1", "value2" };
        }

        // GET api/<RoomsController>/5
        //[HttpGet("{status}")]
        //public async Task<ActionResult<RoomModel>> GetByStatus(string status)
        //{
        //    return Ok(await ModelRepository.GetRoomByStatus(status));
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomModel>> GetById(int id)
        {
            return Ok(await ModelRepository.GetRoom(id));
        }

        // POST api/<RoomsController>
        [HttpPost]
        public async Task<ActionResult<RoomModel>> Post([FromBody] RoomModel NewRoom)
        {
            var value = await ModelRepository.CreateRoom(NewRoom);
            return CreatedAtAction(nameof(GetById),
                new { id = value.RoomNumber }, value);
        }

        // PUT api/<RoomsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RoomModel>> UpdateRoomStatus(int id, [FromBody] string status)
        {
            var NewUpdate = await ModelRepository.UpdateRoomStatus(id, status);
            return Ok(NewUpdate);
        }

        // DELETE api/<RoomsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
