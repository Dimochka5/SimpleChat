using BusinessAccessLayer.Services.Contracts;
using DataAccessLayer.Contacts;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public class ServiceUser:IService<User>
    {
        public readonly IRepository<User> _repository;
        public ServiceUser(IRepository<User> repository)
        {
            _repository = repository;
        }
        public async Task<User> Create(User newUser)
        {
            try
            {
                if (newUser == null)
                {
                    throw new ArgumentNullException(nameof(newUser));
                }
                else
                {
                    return await _repository.Create(newUser);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Delete(int Id)
        {
            try
            {
                if (Id != 0)
                {
                    var user = _repository.GetAll().Where(user => user.Id == Id).FirstOrDefault();
                    if (user != null)
                    {
                        _repository.Delete(user);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Update(int Id)
        {
            try
            {
                if (Id != 0)
                {
                    var user = _repository.GetAll().Where(user=>user.Id==Id).FirstOrDefault();
                    if (user != null) { 
                        _repository.Update(user); 
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<User> GetAll()
        {
            try
            {
                return _repository.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
