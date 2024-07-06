using DataAccessLayer.Contacts;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccessLayer.Repositors
{
    public class ChatRepository:IRepository<Chat>
    {
        private readonly SimpleChatDbContext _chatDbContext;
        private readonly ILogger _logger;
        public ChatRepository(ILogger<User> logger)
        {
            _logger = logger;
        }
        public async Task<Chat> Create(Chat newChat)
        {
            try
            {
                if (newChat != null)
                {
                    var obj = _chatDbContext.Add<Chat>(newChat);
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

        public async Task Delete(Chat chat)
        {
            try
            {
                if (chat != null)
                {
                    var obj = _chatDbContext.Remove(chat);
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

        public List<Chat> GetAll()
        {
            try
            {
                var chats = _chatDbContext.Chats.ToList();
                if (chats != null)
                {
                    return chats;
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

        public Task<Chat> GetById(int id)
        {
            try
            {
                if (id != null)
                {
                    var chat = _chatDbContext.Chats.FirstOrDefaultAsync(chat=>chat.Id==id);
                    if (chat != null)
                    {
                        return chat;
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

        public void Update(Chat chat)
        {
            try
            {
                if (chat != null)
                {
                    var isUpdate = _chatDbContext.Update(chat);
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
