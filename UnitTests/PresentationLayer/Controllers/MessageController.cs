using BusinessAccessLayer.Services.Contracts;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("message")]
    public class MessageController : Controller
    {
        private readonly IService<Message> _service;

        public MessageController(IService<Message> service)
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
        public IActionResult Create([FromBody] string text)
        {
            Message message = new Message() { Text = text };
            _service.Create(message);
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
        public IActionResult Update([FromBody] int id, string text)
        {
            Message updateMessage = new Message() { Text = text, Id = id };
            _service.Update(updateMessage);
            return View();
        }
    }
}
