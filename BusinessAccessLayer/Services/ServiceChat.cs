using BusinessAccessLayer.Services.Contracts;
using DataAccessLayer.Contacts;
using DataAccessLayer.Models;

namespace BusinessAccessLayer.Services
{
    public class ServiceChat : IService<Chat>
    {
        public readonly IRepository<Chat> _repository;
        public readonly IRepository<UserInChat> _userInChatRepository;
        public ServiceChat(IRepository<Chat> repository, IRepository<UserInChat> userInChatRepository)
        {
            _repository = repository;
            _userInChatRepository = userInChatRepository;
        }
        public Chat Create(Chat newChat)
        {
            try
            {
                if (newChat == null)
                {
                    throw new ArgumentNullException(nameof(newChat));
                }
                else
                {
                    if (!String.IsNullOrEmpty(newChat.Name))
                    {
                        var chat = _repository.Create(newChat);
                        UserInChat userInChat = new UserInChat() { Chat = chat, IsAdmin = true };
                        _userInChatRepository.Create(userInChat);
                        return chat;
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
        public void Update(Chat updateChat)
        {
            try
            {
                if (updateChat.Id != 0)
                {
                    var chat = _repository.GetAll().Where(chat => chat.Id == updateChat.Id).FirstOrDefault();
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

        public Chat GetById(int id)
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
