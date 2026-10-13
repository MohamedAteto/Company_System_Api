namespace Company_System_Api.Reposatories.Interface
{
    public interface IGenericRepo<T> where T : class
    {
         Task<List<T>> GetAllAsync();
        Task<T> GetByID(int id);
        Task Add(T entity);
        Task Update(int id ,T entity);
        Task Delete(int id);
    }
}
