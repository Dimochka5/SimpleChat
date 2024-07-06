using DataAccessLayer.Contacts;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccessLayer.Repositors
{
    public class UserRepository : IRepository<User>
    {
        private readonly SimpleChatDbContext _chatDbContext;
        private readonly ILogger _logger;
        public UserRepository(ILogger<User> logger)
        {
            _logger = logger;
        }
        public async Task<User> Create(User newUser)
        {
            try
            {
                if (newUser != null)
                {
                    var obj = _chatDbContext.Add<User>(newUser);
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

        public async Task Delete(User user)
        {
            try
            {
                if (user != null)
                {
                    var obj = _chatDbContext.Remove(user);
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

        public List<User> GetAll()
        {
            try
            {
                var users = _chatDbContext.Users.ToList();
                if (users != null)
                {
                    return users;
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

        public Task<User> GetById(int id)
        {
            try
            {
                if (id != null)
                {
                    var user = _chatDbContext.Users.FirstOrDefaultAsync(user=>user.Id==id);
                    if (user != null)
                    {
                        return user;
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

        public void Update(User user)
        {
            try
            {
                if (user != null)
                {
                    var isUpdate = _chatDbContext.Update(user);
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
