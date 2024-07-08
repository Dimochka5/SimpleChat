using BusinessAccessLayer.Services;
using DataAccessLayer.Models;
using DataAccessLayer.Repositors;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace BusinessAccessLayer.SignalR
{
    public class ChatHub : Hub
    {
        private ServiceMessage _service;
        private Repository<Message> _repo;
        private ILogger<Message> _logger;
        private Repository<Chat> _repoChat;
        private ILogger<Chat> _loggerChat;
        private Repository<User> _repoUser;
        private ILogger<User> _loggerUSer;

        private ChatHub()
        {
            _repo = new Repository<Message>(_logger);
            _service = new ServiceMessage(_repo);
            _repoChat = new Repository<Chat>(_loggerChat);
            _repoUser = new Repository<User>(_loggerUSer);
        }
        public async Task JoinChat(int idChat, int idUser)
        {
            await Groups.AddToGroupAsync(idChat.ToString(), idUser.ToString());
        }
        public async Task LeaveChat(int idChat, int idUser)
        {
            await Groups.RemoveFromGroupAsync(idChat.ToString(), idUser.ToString());
        }
        public async Task SendMessage(int idChat, int idUser, string message)
        {
            Message newMessage = new Message() { Chat = _repoChat.GetById(idChat), User = _repoUser.GetById(idUser), DateTime = DateTime.Now, Text = message };
            _service.Create(newMessage);
            await Clients.Group(idChat.ToString()).SendAsync(message);
        }
        public void DeleteMessage(int idChat, int idUser, int idMessage)
        {
            _service.Delete(idMessage);
        }
        public async Task UpdateMessage(int idChat, int idUser, int idMessage, string message)
        {
            Message newMessage = new Message() { Chat = _repoChat.GetById(idChat), User = _repoUser.GetById(idUser), DateTime = DateTime.Now, Text = message, Id = idMessage };
            _service.Update(newMessage);
            await Clients.Group(idChat.ToString()).SendAsync(message, idMessage);
        }
    }
}
