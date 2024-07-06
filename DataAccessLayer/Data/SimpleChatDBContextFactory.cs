using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccessLayer.Data
{
    public class SimpleChatDBContextFactory: IDesignTimeDbContextFactory<SimpleChatDbContext>
    {
        public SimpleChatDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SimpleChatDbContext>();
            optionsBuilder.UseSqlServer("Data Source=desktop-cpi51i3;Initial Catalog=ChatDB;Integrated Security=True;Trust Server Certificate=True");

            return new SimpleChatDbContext(optionsBuilder.Options);
        }
    }
}
