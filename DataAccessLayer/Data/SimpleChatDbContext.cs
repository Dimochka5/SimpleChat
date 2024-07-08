using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data
{
    public class SimpleChatDbContext : DbContext
    {
        public SimpleChatDbContext(DbContextOptions<SimpleChatDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Chat> Chats { get; set; }

        public DbSet<UserInChat> UsersInChat { get; set; }

        public DbSet<Message> Messages { get; set; }
    }
}
