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
    public class ServiceUserInChat:IService<UserInChat>
    {
        public readonly IRepository<UserInChat> _repository;
        public ServiceUserInChat(IRepository<UserInChat> repository)
        {
            _repository = repository;
        }
        public async Task<UserInChat> Create(UserInChat newUserInChat)
        {
            try
            {
                if (newUserInChat == null)
                {
                    throw new ArgumentNullException(nameof(newUserInChat));
                }
                else
                {
                    return await _repository.Create(newUserInChat);
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
                    var user = _repository.GetAll().Where(userInChat => userInChat.Id == Id).FirstOrDefault();
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
                    var userInChat = _repository.GetAll().Where(userInChat => userInChat.Id == Id).FirstOrDefault();
                    if (userInChat != null)
                    {
                        _repository.Update(userInChat);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<UserInChat> GetAll()
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
