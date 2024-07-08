using BusinessAccessLayer.Services;
using DataAccessLayer.Models;
using DataAccessLayer.Repositors;
using Microsoft.Extensions.Logging;

namespace Tests.BALTests
{
    public class TestsMessage
    {
        private ServiceMessage _service;
        private Repository<Message> _repo;
        private Repository<User> _user;
        private Repository<Chat> _chat;
        private ILogger<Chat> _loggerChat;
        private ILogger<User> _loggerUser;
        private ILogger<Message> _logger;
        [SetUp]
        public void Setup()
        {
            _repo = new Repository<Message>(_logger);
            _user = new Repository<User>(_loggerUser);
            _chat = new Repository<Chat>(_loggerChat);
            _service = new ServiceMessage(_repo);
        }
        [Test]
        public void CreateChat()
        {
            var message = new Message() { Text = "Chat 565" };
            Assert.IsNotNull(_service.Create(message));
        }
        [Test]
        public void CreateWithNull()
        {
            var message = new Message() { Text = String.Empty };
            Assert.IsNull(_service.Create(message));
        }
        [Test]
        public void Update()
        {
            var message = new Message() { Id = 1, Text = "Alex" };
            Assert.DoesNotThrow(() => _service.Update(message));
        }
        [Test]
        public void UpdateNullText()
        {
            var message = new Message() { Id = 5, Text = String.Empty };
            Assert.IsNull(_service.Create(message));
        }
        [Test]
        public void UpdateNullId()
        {
            var message = new Message() { Id = 0, Text = "dima" };
            Assert.IsNull(_service.Create(message));
        }
        [Test]
        public void GetAll()
        {
            Assert.IsNotNull(_service.GetAll());
        }
        [Test]
        public void GetById()
        {
            Assert.IsNotNull(_service.GetById(5));
        }
        [Test]
        public void GetByNotExistId()
        {
            Assert.IsNull(_service.GetById(555));
        }
        [Test]
        public void Delete()
        {
            Assert.DoesNotThrow(() => _service.Delete(5));
        }
        [Test]
        public void DeleteNotExistId()
        {
            Assert.DoesNotThrow(() => _service.Delete(555));
        }
    }
}
