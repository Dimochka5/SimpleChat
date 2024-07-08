using BusinessAccessLayer.Services.Contracts;
using BusinessAccessLayer.SignalR;
using DataAccessLayer.Contacts;
using DataAccessLayer.Models;

namespace BusinessAccessLayer.Services
{
    public class ServiceUserInChat : IService<UserInChat>
    {
        public readonly IRepository<UserInChat> _repository;
        public ServiceUserInChat(IRepository<UserInChat> repository)
        {
            _repository = repository;
        }
        public UserInChat Create(UserInChat newUserInChat)
        {
            try
            {
                if (newUserInChat == null)
                {
                    throw new ArgumentNullException(nameof(newUserInChat));
                }
                else
                {
                    if (newUserInChat.User != null && newUserInChat.Chat != null && newUserInChat.Chat.Id != 0 && newUserInChat.User.Id != 0)
                    {
                        ChatHub hub = new ChatHub();
                        hub.JoinChat(newUserInChat.Chat.Id, newUserInChat.User.Id);
                        return _repository.Create(newUserInChat);
                    }
                    else
                    {
                        return null;
                    }
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
                    ChatHub hub = new ChatHub();
                    hub.LeaveChat(user.Chat.Id, user.User.Id);
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
        public void Update(UserInChat updateUserInChat)
        {
            try
            {
                if (updateUserInChat.Id != 0)
                {
                    var userInChat = _repository.GetAll().Where(userInChat => userInChat.Id == updateUserInChat.Id).FirstOrDefault();
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

        public IEnumerable<UserInChat> GetByIdChat(int idChat)
        {
            try
            {
                return _repository.GetAll().ToList().Where(u => u.Chat.Id == idChat);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<UserInChat> GetByIdUser(int idUser)
        {
            try
            {
                return _repository.GetAll().ToList().Where(u => u.User.Id == idUser);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
