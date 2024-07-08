using BusinessAccessLayer.Services.Contracts;
using DataAccessLayer.Contacts;
using DataAccessLayer.Models;

namespace BusinessAccessLayer.Services
{
    public class ServiceMessage : IService<Message>
    {

        public readonly IRepository<Message> _repository;
        public ServiceMessage(IRepository<Message> repository)
        {
            _repository = repository;
        }
        public Message Create(Message newMessage)
        {
            try
            {
                if (newMessage == null)
                {
                    throw new ArgumentNullException(nameof(newMessage));
                }
                else
                {
                    return _repository.Create(newMessage);
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
        public void Update(Message updateMessage)
        {
            try
            {
                if (updateMessage.Id != 0)
                {
                    var message = _repository.GetAll().Where(message => message.Id == updateMessage.Id).FirstOrDefault();
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
        public Message GetById(int id)
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
