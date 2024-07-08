using BusinessAccessLayer.Services;
using DataAccessLayer.Models;
using DataAccessLayer.Repositors;
using Microsoft.Extensions.Logging;

namespace Tests.BALTests
{
    public class TestsUser
    {
        private ServiceUser _service;
        private Repository<User> _repo;
        private ILogger<User> _logger;
        [SetUp]
        public void Setup()
        {
            _repo = new Repository<User>(_logger);
            _service = new ServiceUser(_repo);
        }
        [Test]
        public void CreateUser()
        {
            var user = new User() { Name = "Albert" };
            Assert.IsNotNull(_service.Create(user));
        }
        [Test]
        public void CreateUserWithNull()
        {
            var user = new User() { Name = String.Empty };
            Assert.IsNull(_service.Create(user));
        }
        [Test]
        public void UpdateUser()
        {
            var user = new User() { Id = 5, Name = "Alex" };
            Assert.DoesNotThrow(() => _service.Update(user));
        }
        [Test]
        public void UpdateUserNullName()
        {
            var user = new User() { Id = 5, Name = String.Empty };
            Assert.IsNull(_service.Create(user));
        }
        [Test]
        public void UpdateUserNullId()
        {
            var user = new User() { Id = 0, Name = "dima" };
            Assert.IsNull(_service.Create(user));
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
