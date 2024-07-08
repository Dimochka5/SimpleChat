using DataAccessLayer.Contacts;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.Extensions.Logging;

namespace DataAccessLayer.Repositors
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly SimpleChatDbContext _chatDbContext;
        private readonly ILogger _logger;
        public Repository(ILogger<T> logger)
        {
            SimpleChatDBContextFactory factory = new SimpleChatDBContextFactory();
            _chatDbContext = factory.CreateDbContext(["c", "c"]);
            _logger = logger;
        }
        public T Create(T _object)
        {
            try
            {
                if (_object != null && _object.Id == 0)
                {
                    if (_object is UserInChat)
                    {
                        if ((_object as UserInChat).User != null)
                            _chatDbContext.Users.Attach((_object as UserInChat).User);
                        if ((_object as UserInChat).Chat != null)
                            _chatDbContext.Chats.Attach((_object as UserInChat).Chat);
                    }
                    else if (_object is Message)
                    {
                        if ((_object as UserInChat).User != null)
                            _chatDbContext.Users.Attach((_object as Message).User);
                        if ((_object as UserInChat).Chat != null)
                            _chatDbContext.Chats.Attach((_object as Message).Chat);
                    }
                    var obj = _chatDbContext.Add<T>(_object);
                    _chatDbContext.SaveChanges();
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

        public void Delete(T _object)
        {
            try
            {
                if (_object != null)
                {
                    var obj = _chatDbContext.Remove(_object);
                    if (obj != null)
                    {
                        _chatDbContext.SaveChanges();
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
                var obj = _chatDbContext.Set<T>().ToList();
                if (obj is List<UserInChat> userInChatList)
                {
                    foreach (UserInChat item in userInChatList)
                    {
                        if (item.User != null)
                        {
                            _chatDbContext.Users.Attach(item.User);
                        }
                        if (item.Chat != null)
                        {
                            _chatDbContext.Chats.Attach(item.Chat);
                        }
                    }
                }
                else if (obj is List<Message> messageList)
                {
                    foreach (var item in messageList)
                    {
                        if (item.User != null)
                        {
                            _chatDbContext.Users.Attach(item.User);
                        }
                        if (item.Chat != null)
                        {
                            _chatDbContext.Chats.Attach(item.Chat);
                        }
                    }
                }
                if (obj != null)
                {
                    return obj;
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

        public T GetById(int id)
        {
            try
            {
                if (id != null)
                {
                    var obj = _chatDbContext.Set<T>().Find(id);
                    if (obj is UserInChat)
                    {
                        _chatDbContext.Users.Attach((obj as UserInChat).User);
                        _chatDbContext.Chats.Attach((obj as UserInChat).Chat);
                    }
                    else if (obj is Message)
                    {
                        _chatDbContext.Users.Attach((obj as Message).User);
                        _chatDbContext.Chats.Attach((obj as Message).Chat);
                    }
                    if (obj != null)
                    {
                        return obj;
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
                        _chatDbContext.SaveChanges();
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
