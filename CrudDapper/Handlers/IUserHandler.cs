namespace CrudDapper.Handlers
{
    public interface IUserHandler
    {
        Task<List<Users>> GetUsers();

        Task<Users> GetById(int UserId);

        Task CreateUser(Users user);

        Task UpdateUser(Users user);

        Task DeleteUser(int UserId);
      
    }
}
