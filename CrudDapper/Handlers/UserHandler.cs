using CrudDapper.Repository;
using Dapper;
using System.Data.SqlClient;

namespace CrudDapper.Handlers
{
    public class UserHandler : IUserHandler
    {

        private readonly IUserRepository _userRepository;
        public UserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<Users>> GetUsers()
        {
            string queryString = "select * from users";
            List<Users> users = await _userRepository.GetRecords(queryString);
            return users;
        }

        public async Task<Users> GetById(int UserId)
        {
            string queryString = $"select * from users where UserId={UserId}";
            Users users= await _userRepository.GetRecord(queryString);
            return users;
        }

        public async Task CreateUser(Users user)
        {
            string queryString = $"INSERT INTO Users (UserId, UserName, Email) VALUES ({user.UserId},'{user.UserName}','{user.Email}')";
            await _userRepository.SaveRecord(queryString);
        }

        public async Task UpdateUser(Users user)
        {
            string queryString = $"UPDATE Users SET UserName='{user.UserName}',Email='{user.Email}' WHERE UserId={user.UserId}";
             await _userRepository.SaveRecord(queryString);
        }

        public async Task DeleteUser(int UserId)
        {
            string queryString = $"Delete from users where UserId={UserId}";
             await _userRepository.SaveRecord(queryString);
        }
    }
}
