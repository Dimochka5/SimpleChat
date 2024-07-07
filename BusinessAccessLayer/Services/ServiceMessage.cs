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
    public class ServiceMessage:IService<Message>
    {

        public readonly IRepository<Message> _repository;
        public ServiceMessage(IRepository<Message> repository)
        {
            _repository = repository;
        }
        public async Task<Message> Create(Message newMessage)
        {
            try
            {
                if (newMessage == null)
                {
                    throw new ArgumentNullException(nameof(newMessage));
                }
                else
                {
                    return await _repository.Create(newMessage);
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
                    var message = _repository.GetAll().Where(message => message.Id == Id).FirstOrDefault();
                    if (message != null)
                    {
                        _repository.Delete(message);
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
                    var message = _repository.GetAll().Where(message => message.Id == Id).FirstOrDefault();
                    if (message != null)
                    {
                        _repository.Update(message);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Message> GetAll()
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
