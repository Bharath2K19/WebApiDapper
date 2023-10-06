using Dapper;
using System.Data.SqlClient;

namespace CrudDapper.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly IConfiguration _config;

        public UserRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<Users>> GetRecords(string queryString)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var command = await connection.QueryAsync<Users>(queryString);
            return (List<Users>)command;
        }

        public async Task<Users> GetRecord(string queryString)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var command = await connection.QueryFirstAsync<Users>(queryString);
            return (Users)command;
        }

        public async Task SaveRecord(string queryString)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync(queryString);
        }

    }
}
