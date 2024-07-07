using DataAccessLayer.Contacts;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositors
{
    public class Repository<T> : IRepository<T> where T : class,IEntity
    {
        private readonly SimpleChatDbContext _chatDbContext;
        private readonly ILogger _logger;
        public Repository(ILogger<T> logger)
        {
            _logger = logger;
        }
        public async Task<T> Create(T _object)
        {
            try
            {
                if (_object != null)
                {
                    var obj = _chatDbContext.Add<T>(_object);
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

        public async Task Delete(T _object)
        {
            try
            {
                if (_object != null)
                {
                    var obj = _chatDbContext.Remove(_object);
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

        public List<T> GetAll()
        {
            try
            {
                var chats = _chatDbContext.Set<T>().ToList();
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

        public Task<T> GetById(int id)
        {
            try
            {
                if (id != null)
                {
                    var chat = _chatDbContext.Set<T>().FirstOrDefaultAsync(t=>t.Id==id);
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

        public void Update(T _object)
        {
            try
            {
                if (_object != null)
                {
                    var isUpdate = _chatDbContext.Update(_object);
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
