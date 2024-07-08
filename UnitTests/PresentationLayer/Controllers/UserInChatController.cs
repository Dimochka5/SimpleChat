using BusinessAccessLayer.Services.Contracts;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class UserInChatController : Controller
    {
        private readonly IService<UserInChat> _service;
        private readonly IService<User> _serviceUser;
        private readonly IService<Chat> _serviceChat;

        public UserInChatController(IService<UserInChat> service, IService<User> serviceUser, IService<Chat> serviceChat)
        {
            _service = service;
            _serviceUser = serviceUser;
            _serviceChat = serviceChat;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var users = _service.GetAll();
            return View(users);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] int idChat, int idUser)
        {
            UserInChat userInChat = new UserInChat() { Chat = _serviceChat.GetAll().FirstOrDefault(chat => chat.Id == idChat), User = _serviceUser.GetAll().FirstOrDefault(user => user.Id == idUser) };
            _service.Create(userInChat);
            return View();
        }
        [HttpPost("delete")]
        public IActionResult Delete([FromBody] int id)
        {
            _service.Delete(id);
            return View();
        }
        [HttpGet("get")]
        public IActionResult GetById([FromBody] int id)
        {
            var user = _service.GetAll().Where(x => x.Id == id);
            return View(user);
        }
        [HttpPost("update")]
        public IActionResult Update([FromBody] int id, int idChat, int idUser)
        {
            UserInChat userInChat = new UserInChat() { Id = id, Chat = _serviceChat.GetAll().FirstOrDefault(chat => chat.Id == idChat), User = _serviceUser.GetAll().FirstOrDefault(user => user.Id == idUser) };
            _service.Update(userInChat);
            return View();
        }
    }
}
