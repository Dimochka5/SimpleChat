using DataAccessLayer.Models;
using DataAccessLayer.Repositors;
using Microsoft.Extensions.Logging;

namespace Tests
{
    public class TestsUserInChat
    {
        private Repository<UserInChat> _repo;
        private Repository<User> _user;
        private Repository<Chat> _chat;
        private ILogger<UserInChat> _logger;
        private ILogger<User> _userLogger;
        private ILogger<Chat> _chatLogger;

        [SetUp]
        public void Setup()
        {
            _repo = new Repository<UserInChat>(_logger);
            _chat = new Repository<Chat>(_chatLogger);
            _user = new Repository<User>(_userLogger);
        }

        [Test]
        public void TestCreate()
        {
            UserInChat newUserInChat = new UserInChat { User = new User { Id = 6 }, Chat = new Chat { Id = 2 } };
            Assert.IsNotNull(_repo.Create(newUserInChat));
        }
        [Test]
        public void TestCreateWithId()
        {
            UserInChat newUserInChat = new UserInChat { Id = 3 };
            Assert.IsNull(_repo.Create(newUserInChat));
        }
        [Test]
        public void TestGetAll()
        {
            Assert.IsNotNull(_repo.GetAll());
        }
        [Test]
        public void TestGetById()
        {
            Assert.IsNotNull(_repo.GetById(1));
        }
        [Test]
        public void TestGetByNotExistId()
        {
            Assert.IsNull(_repo.GetById(999));
        }
        [Test]
        public void TestUpdate()
        {
            UserInChat updateUserInChat = new UserInChat { Id = 1, User = new User { Name = "Frank" } };
            Assert.DoesNotThrow(() => _repo.Update(updateUserInChat));
        }
        [Test]
        public void TestDelete()
        {
            UserInChat deleteUserInChat = new UserInChat { Id = 1 };
            Assert.DoesNotThrow(() => _repo.Delete(deleteUserInChat));
        }
    }
}
