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
    public class ServiceChat:IService<Chat>
    {
        public readonly IRepository<Chat> _repository;
        public ServiceChat(IRepository<Chat> repository)
        {
            _repository = repository;
        }
        public async Task<Chat> Create(Chat newChat)
        {
            try
            {
                if (newChat == null)
                {
                    throw new ArgumentNullException(nameof(newChat));
                }
                else
                {
                    return await _repository.Create(newChat);
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
                    var chat = _repository.GetAll().Where(user => user.Id == Id).FirstOrDefault();
                    if (chat != null)
                    {
                        _repository.Delete(chat);
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
                    var chat = _repository.GetAll().Where(chat=>chat.Id==Id).FirstOrDefault();
                    if (chat != null)
                    {
                        _repository.Update(chat);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Chat> GetAll()
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
