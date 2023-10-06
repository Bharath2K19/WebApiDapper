namespace CrudDapper.Repository
{
    public interface IUserRepository
    {
        Task<List<Users>> GetRecords(string queryString);

        Task<Users> GetRecord(string queryString);
        
        Task SaveRecord(string queryString);
    }
}
