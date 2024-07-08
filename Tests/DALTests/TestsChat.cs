using DataAccessLayer.Models;
using DataAccessLayer.Repositors;
using Microsoft.Extensions.Logging;

namespace Tests
{
    public class TestsChat
    {
        private Repository<Chat> _repo;
        private ILogger<Chat> _logger;

        [SetUp]
        public void Setup()
        {
            _repo = new Repository<Chat>(_logger);
        }

        [Test]
        public void TestCreateChat()
        {
            Chat newChat = new Chat() { Name = "Chat1" };
            Assert.IsNotNull(_repo.Create(newChat));
        }
        [Test]
        public void TestCreateChatWithId()
        {
            Chat newChat = new Chat { Id = 99 };
            Assert.IsNull(_repo.Create(newChat));
        }
        [Test]
        public void TestCreateWithoutName()
        {
            Chat newChat = new Chat();
            Assert.IsNotNull(_repo.Create(newChat));
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
            Chat updateChat = new Chat() { Name = "Chat 5", Id = 3 };
            Assert.DoesNotThrow(() => _repo.Update(updateChat));
        }
        [Test]
        public void TestDelete()
        {
            Chat deleteChat = new Chat() { Id = 3 };
            Assert.DoesNotThrow(() => _repo.Delete(deleteChat));
        }
    }
}
