using CrudDapper.Handlers;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CrudDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserHandler _userHandler;

        public UserController(IConfiguration config, IUserHandler userHandler)
        {
            _config = config;
            _userHandler = userHandler;
        }
        [HttpGet]
        public async Task<ActionResult<List<Users>>> GetAllUsers()
        {
            var command = await _userHandler.GetUsers();
            return Ok(command);
        }
        [HttpGet("{UserId}")]

        public async Task<ActionResult<Users>> GetById(int UserId)
        {
            var command = await _userHandler.GetById(UserId);
            return Ok(command);
        }

        [HttpPost]

        public async Task CreateUsers(Users user)
        {
            await _userHandler.CreateUser(user);
        }

        [HttpPut]

        public async Task UpdateUsers(Users user)
        {
            await _userHandler.UpdateUser(user);
           
        }

        [HttpDelete("{UserId}")]

        public async Task DeleteById(int UserId)
        {
            await _userHandler.DeleteUser(UserId);
        }



    }
}
