using DataAccessLayer.Contacts;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccessLayer.Repositors
{
    public class MessageRepository:IRepository<Message>
    {
        private readonly SimpleChatDbContext _chatDbContext;
        private readonly ILogger _logger;
        public MessageRepository(ILogger<User> logger)
        {
            _logger = logger;
        }
        public async Task<Message> Create(Message newMessage)
        {
            try
            {
                if (newMessage != null)
                {
                    var obj = _chatDbContext.Add<Message>(newMessage);
                    await _chatDbContext.SaveChangesAsync();
                    return obj.Entity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Delete(Message message)
        {
            try
            {
                if (message != null)
                {
                    var obj = _chatDbContext.Remove(message);
                    if (obj != null)
                    {
                        await _chatDbContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Message> GetAll()
        {
            try
            {
                var messages = _chatDbContext.Messages.ToList();
                if (messages != null)
                {
                    return messages;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<Message> GetById(int id)
        {
            try
            {
                if (id != null)
                {
                    var message = _chatDbContext.Messages.FirstOrDefaultAsync(message => message.Id == id);
                    if (message != null)
                    {
                        return message;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Message message)
        {
            try
            {
                if (message != null)
                {
                    var isUpdate = _chatDbContext.Update(message);
                    if (isUpdate != null)
                    {
                        _chatDbContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
