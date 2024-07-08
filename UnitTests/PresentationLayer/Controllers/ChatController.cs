using BusinessAccessLayer.Services.Contracts;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class ChatController : Controller
    {
        private readonly IService<Chat> _service;

        public ChatController(IService<Chat> service)
        {
            _service = service;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var users = _service.GetAll();
            return View(users);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] string name)
        {
            Chat chat = new Chat() { Name = name };
            _service.Create(chat);
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
        public IActionResult Update([FromBody] int id, string name)
        {
            Chat updateChat = new Chat() { Name = name, Id = id };
            _service.Update(updateChat);
            return View();
        }
    }
}
