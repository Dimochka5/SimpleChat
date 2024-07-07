using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services.Contracts
{
    public interface IService<T> where T : class
    {
        public Task<T> Create(T _object);
        public void Delete(int Id);
        public void Update(int Id);
        public IEnumerable<T> GetAll();
    }
}
