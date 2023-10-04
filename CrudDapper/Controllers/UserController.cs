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

        public UserController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        public async Task<ActionResult<List<Users>>> GetAllUsers()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            using var command = connection.QueryAsync<Users>("select * from users");
            return Ok(command.Result);
        }
        [HttpGet("{UserId}")]

        public async Task<ActionResult<List<Users>>> GetById(int UserId)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            using var command = connection.QueryAsync<Users>($"select * from users where UserId={UserId}");
            return Ok(command.Result);
        }

        [HttpPost]

        public async Task<ActionResult<List<Users>>> CreateUsers(Users user)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync($"INSERT INTO Users (UserId, UserName, Email) VALUES ('{user.UserId}','{user.UserName}','{user.Email}')");
            return Ok("Done");
        }

        
    }
}
