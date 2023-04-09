namespace DapperDemo.Data
{
    public interface IDataAccess
    {
        Task<IEnumerable<T>> GetData<T, P>(string query, P parameters, string connctionId = "DefaultConnection");
        Task SaveData<P>(string query, P parameters, string connctionId = "DefaultConnection");
    }
}