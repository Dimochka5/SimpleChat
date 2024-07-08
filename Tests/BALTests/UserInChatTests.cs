using BusinessAccessLayer.Services;
using DataAccessLayer.Models;
using DataAccessLayer.Repositors;
using Microsoft.Extensions.Logging;

namespace Tests.BALTests
{
    public class UserInChatTests
    {
        private ServiceUserInChat _service;
        private Repository<UserInChat> _repo;
        private ILogger<UserInChat> _logger;
        [SetUp]
        public void Setup()
        {
            _repo = new Repository<UserInChat>(_logger);
            _service = new ServiceUserInChat(_repo);
        }
        [Test]
        public void CreateChat()
        {
            var userInChat = new UserInChat() { User = new User() { Id = 1 }, Chat = new Chat() { Id = 1 } };
            Assert.IsNotNull(_service.Create(userInChat));
        }
        [Test]
        public void CreateUserWithNull()
        {
            var userInChat = new UserInChat() { User = new User() { Id = 0 }, Chat = new Chat() { Id = 0 } };
            Assert.IsNull(_service.Create(userInChat));
        }
        [Test]
        public void Update()
        {
            var userInChat = new UserInChat() { Id = 7, User = new User() { Id = 8 } };
            Assert.DoesNotThrow(() => _service.Update(userInChat));
        }
        [Test]
        public void UpdateUserNullId()
        {
            var userInChat = new UserInChat() { User = new User() { Id = 0 } };
            Assert.IsNull(_service.Create(userInChat));
        }
        [Test]
        public void GetAll()
        {
            Assert.IsNotNull(_service.GetAll());
        }
        [Test]
        public void GetByIdChat()
        {
            Assert.IsNotNull(_service.GetByIdChat(5));
        }
        [Test]
        public void GetByIdUser()
        {
            Assert.IsNotNull(_service.GetByIdUser(10));
        }
        [Test]
        public void Delete()
        {
            _service.Delete(5);
            Assert.DoesNotThrow(() => _service.Delete(5));
        }
        [Test]
        public void DeleteNotExistId()
        {
            Assert.Throws<Exception>(() => _service.Delete(555));
        }
    }
}
