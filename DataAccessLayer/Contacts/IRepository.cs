namespace DataAccessLayer.Contacts
{
    public interface IRepository<T> where T : class
    {
        public T Create(T _object);
        public void Delete(T _object);
        public void Update(T _object);
        public List<T> GetAll();
        public T GetById(int Id);
    }
}
