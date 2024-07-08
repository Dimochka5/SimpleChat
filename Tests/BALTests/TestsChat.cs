using BusinessAccessLayer.Services;
using DataAccessLayer.Models;
using DataAccessLayer.Repositors;
using Microsoft.Extensions.Logging;

namespace Tests.BALTests
{
    public class TestsChat
    {
        private ServiceChat _service;
        private Repository<Chat> _repo;
        private Repository<UserInChat> _user;
        private ILogger<Chat> _logger;
        private ILogger<UserInChat> _loggerUser;
        [SetUp]
        public void Setup()
        {
            _repo = new Repository<Chat>(_logger);
            _user = new Repository<UserInChat>(_loggerUser);
            _service = new ServiceChat(_repo, _user);
        }
        [Test]
        public void CreateChat()
        {
            var chat = new Chat() { Name = "Chat 565" };
            Assert.IsNotNull(_service.Create(chat));
        }
        [Test]
        public void CreateWithNull()
        {
            var chat = new Chat() { Name = String.Empty };
            Assert.IsNull(_service.Create(chat));
        }
        [Test]
        public void Update()
        {
            var chat = new Chat() { Id = 5, Name = "Alex" };
            Assert.DoesNotThrow(() => _service.Update(chat));
        }
        [Test]
        public void UpdateNullName()
        {
            var chat = new Chat() { Id = 5, Name = String.Empty };
            Assert.IsNull(_service.Create(chat));
        }
        [Test]
        public void UpdateNullId()
        {
            var chat = new Chat() { Id = 0, Name = "dima" };
            Assert.IsNull(_service.Create(chat));
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
