using DataAccessLayer.Models;
using DataAccessLayer.Repositors;
using Microsoft.Extensions.Logging;

namespace Tests
{
    public class TestsMessage
    {
        private Repository<Message> _repo;
        private Repository<User> _user;
        private Repository<Chat> _chat;
        private ILogger<Message> _logger;
        private ILogger<User> _userLogger;
        private ILogger<Chat> _chatLogger;

        [SetUp]
        public void Setup()
        {
            _repo = new Repository<Message>(_logger);
            _chat = new Repository<Chat>(_chatLogger);
            _user = new Repository<User>(_userLogger);
        }

        [Test]
        public void TestCreateMessage()
        {
            Message newMessage = new Message() { Text = "Hi", DateTime = DateTime.Now, User = new User { Name = "Frank" }, Chat = new Chat { Name = "ChatNewYork" } };
            Assert.IsNotNull(_repo.Create(newMessage));
        }
        [Test]
        public void TestCreateMessageWithId()
        {
            Message newMessage = new Message() { Text = "Hi", Id = 199, DateTime = DateTime.Now, User = _user.GetById(1), Chat = _chat.GetById(1) };
            Assert.IsNull(_repo.Create(newMessage));
        }
        [Test]
        public void TestGetAll()
        {
            Assert.IsNotNull(_repo.GetAll());
        }
        [Test]
        public void TestGetById()
        {
            Assert.IsNotNull(_repo.GetById(7));
        }
        [Test]
        public void TestGetByNotExistId()
        {
            Assert.IsNull(_repo.GetById(999));
        }
        [Test]
        public void TestUpdate()
        {
            Message updateMessage = new Message() { Id = 7, Text = "Hello" };
            Assert.DoesNotThrow(() => _repo.Update(updateMessage));
        }
        [Test]
        public void TestDelete()
        {
            Message deleteMessage = new Message() { Id = 7 };
            Assert.DoesNotThrow(() => _repo.Delete(deleteMessage));
        }
    }
}
