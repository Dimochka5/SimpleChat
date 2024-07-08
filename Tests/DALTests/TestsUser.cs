using DataAccessLayer.Models;
using DataAccessLayer.Repositors;
using Microsoft.Extensions.Logging;
using NUnit.Framework.Internal;
namespace Tests
{
    public class TestsUser
    {
        private Repository<User> _repo;
        private ILogger<User> _logger;

        [SetUp]
        public void Setup()
        {
            _repo = new Repository<User>(_logger);
        }

        [Test]
        public void TestCreateUser()
        {
            User newUser = new User() { Name = "Test name" };
            Assert.IsNotNull(_repo.Create(newUser));
        }
        [Test]
        public void TestCreateUserWithId()
        {
            User newUser = new User() { Id = 99 };
            Assert.IsNull(_repo.Create(newUser));
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
            User updateUser = new User() { Id = 1, Name = "Alexander" };
            Assert.DoesNotThrow(() => _repo.Update(updateUser));
        }
        [Test]
        public void TestDelete()
        {
            User deleteUser = new User() { Id = 3 };
            Assert.DoesNotThrow(() => _repo.Delete(deleteUser));
        }
    }
}