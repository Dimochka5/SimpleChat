using DataAccessLayer.Contacts;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccessLayer.Repositors
{
    public class UserInChatRepository: IRepository<UserInChat>
    {
        private readonly SimpleChatDbContext _chatDbContext;
        private readonly ILogger _logger;
        public UserInChatRepository(ILogger<User> logger)
        {
            _logger = logger;
        }
        public async Task<UserInChat> Create(UserInChat userInChat)
        {
            try
            {
                if (userInChat != null)
                {
                    var obj = _chatDbContext.Add<UserInChat>(userInChat);
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

        public async Task Delete(UserInChat userInChat)
        {
            try
            {
                if (userInChat != null)
                {
                    var obj = _chatDbContext.Remove(userInChat);
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

        public List<UserInChat> GetAll()
        {
            try
            {
                var userInChat = _chatDbContext.UsersInChat.ToList();
                if (userInChat != null)
                {
                    return userInChat;
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

        public Task<UserInChat> GetById(int id)
        {
            try
            {
                if (id != null)
                {
                    var userInChat = _chatDbContext.UsersInChat.FirstOrDefaultAsync(userInChat => userInChat.Id == id);
                    if (userInChat != null)
                    {
                        return userInChat;
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

        public void Update(UserInChat userInChat)
        {
            try
            {
                if (userInChat != null)
                {
                    var isUpdate = _chatDbContext.Update(userInChat);
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
