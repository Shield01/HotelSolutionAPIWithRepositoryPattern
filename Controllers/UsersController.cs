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
    public class UsersController : ControllerBase
    {
        private readonly IUserModelRepository ModelRepository;

        public UsersController(IUserModelRepository modelRepository)
        {
            ModelRepository = modelRepository;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await ModelRepository.GetAllUsers());
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> Get(int id)
        {
            return Ok(await ModelRepository.GetUser(id));
        }


        // GET api/<UsersController>/5
        //[HttpGet("{Search}")]
        //public async Task<ActionResult<UserModel>> Search(string Name, string EmailAddress)
        //{
        //    var result = await ModelRepository.Search(Name, EmailAddress);
        //    if (result.Any())
        //    {
        //        return Ok(result);
        //    }

        //    return NotFound();  
        //}

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<UserModel>> Post(UserModel user)
        {
            var CreatedUser = await ModelRepository.AddUser(user);
            return CreatedAtAction(nameof(Get),
                new { id = CreatedUser.Id }, CreatedUser);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Put(int id, UserModel UpdatedUser)
        {
            var UserToUpdate = await ModelRepository.GetUser(id);
           var NewUpdate = await ModelRepository.UpdateUser(UpdatedUser);
            return Ok(NewUpdate);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ModelRepository.DeleteUser(id);
            return Ok(null);
        }
    }
}
