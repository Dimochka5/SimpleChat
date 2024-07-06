using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contacts
{
    public interface IRepository<T> where T : class
    {
        public Task<T> Create(T _object);
        public Task Delete(T _object);
        public void Update(T _object);
        public List<T> GetAll();
        public Task<T> GetById(int Id);
    }
}
