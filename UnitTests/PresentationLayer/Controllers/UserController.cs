﻿using BusinessAccessLayer.Services.Contracts;
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
            var users = _service.GetAll();
            return View(users);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] string name)
        {
            User user = new User() { Name = name };
            _service.Create(user);
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
            User updateUser = new User() { Name = name, Id = id };
            _service.Update(updateUser);
            return View();
        }
    }
}
