using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using PresentationLayer.Controllers;
using System.Text;
using Xunit;

namespace Tests.LA
{
    public class ChatTests : IClassFixture<WebApplicationFactory<ChatController>>
    {
        private readonly WebApplicationFactory<ChatController> _factory;
        private readonly HttpClient _client;

        public ChatTests(WebApplicationFactory<ChatController> factory)
        {
            _factory = factory;

            _client = factory.WithWebHostBuilder(builder =>
            { }).CreateClient();
        }

        private void SeedTestData(SimpleChatDbContext context)
        {
            context.Chats.AddRange(
                new Chat { Name = "Test name 1" },
                new Chat { Name = "Test name 2" }
            );
            context.SaveChanges();
        }

        [Fact]
        public async Task GetAll()
        {
            var response = await _client.GetAsync("/chat/getAll");

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var chats = JsonConvert.DeserializeObject<List<Chat>>(responseString);

            Assert.NotNull(chats);
            Assert.True(chats.Count > 0);
        }

        [Fact]
        public async Task Create()
        {
            var chatsName = "New chat";
            var content = new StringContent(JsonConvert.SerializeObject(chatsName), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/chat/create", content);
            response.EnsureSuccessStatusCode();

            var getAllResponse = await _client.GetAsync("/chat/getAll");
            getAllResponse.EnsureSuccessStatusCode();
            var responseString = await getAllResponse.Content.ReadAsStringAsync();
            var chats = JsonConvert.DeserializeObject<List<Chat>>(responseString);

            Assert.Contains(chats, u => u.Name == chatsName);
        }

        [Fact]
        public async Task Delete()
        {
            var userId = 1;
            var content = new StringContent(JsonConvert.SerializeObject(userId), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/chat/delete", content);
            response.EnsureSuccessStatusCode();

            var getAllResponse = await _client.GetAsync("/chat/getAll");
            getAllResponse.EnsureSuccessStatusCode();
            var responseString = await getAllResponse.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<Chat>>(responseString);

            Assert.DoesNotContain(users, u => u.Id == userId);
        }

        [Fact]
        public async Task GetById()
        {
            var chatId = 1;

            var response = await _client.GetAsync($"/chat/get?id={chatId}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var chat = JsonConvert.DeserializeObject<Chat>(responseString);

            Assert.NotNull(chat);
            Assert.Equal(chatId, chat.Id);
        }

        [Fact]
        public async Task Update()
        {
            var userId = 1;
            var newName = "Updated name";
            var content = new StringContent(JsonConvert.SerializeObject(new { id = userId, name = newName }), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/chat/update", content);
            response.EnsureSuccessStatusCode();

            var getResponse = await _client.GetAsync($"/chat/get?id={userId}");
            getResponse.EnsureSuccessStatusCode();
            var responseString = await getResponse.Content.ReadAsStringAsync();
            var chat = JsonConvert.DeserializeObject<Chat>(responseString);

            Assert.NotNull(chat);
            Assert.Equal(newName, chat.Name);
        }
    }
}

