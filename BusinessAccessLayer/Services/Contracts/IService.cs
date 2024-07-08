namespace BusinessAccessLayer.Services.Contracts
{
    public interface IService<T> where T : class
    {
        public T Create(T _object);
        public void Delete(int Id);
        public void Update(T _object);
        public IEnumerable<T> GetAll();
    }
}
