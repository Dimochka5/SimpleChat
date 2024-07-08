using BusinessAccessLayer.Services.Contracts;
using DataAccessLayer.Contacts;
using DataAccessLayer.Models;

namespace BusinessAccessLayer.Services
{
    public class ServiceUser : IService<User>
    {
        public readonly IRepository<User> _repository;
        public ServiceUser(IRepository<User> repository)
        {
            _repository = repository;
        }
        public User Create(User newUser)
        {
            try
            {
                if (newUser == null)
                {
                    return null;
                }
                else
                {
                    if (!String.IsNullOrEmpty(newUser.Name))
                    {
                        return _repository.Create(newUser);
                    }
                    else
                    {
                        return null;
                    }
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
        public void Update(User updateUser)
        {
            try
            {
                if (updateUser.Id != 0)
                {
                    if (!String.IsNullOrEmpty(updateUser.Name))
                    {
                        var user = _repository.GetAll().Where(user => user.Id == updateUser.Id).FirstOrDefault();
                        if (user != null)
                        {
                            user.Name = updateUser.Name;
                            _repository.Update(user);
                        }
                    }
                    else
                    {
                        return;
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
        public User GetById(int id)
        {
            try
            {
                return _repository.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
