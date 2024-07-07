using BusinessAccessLayer.Services.Contracts;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IService<User> _service;

        public UserController(IService<User> service)
        {
            _service = service;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var users= _service.GetAll();
            return View(users);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody]string name)
        {
            User user = new User() {Name=name };
            _service.Create(user);
            return View();
        }
    }
}
