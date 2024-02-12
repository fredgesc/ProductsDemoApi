namespace ProductsDemoApi.Repositories
{
    public interface IDataRepository<T>
    {
        List<T> GetAll();
        T? GetById(int id);
        void Save(T entity);
        void Delete(int id);
    }
}
