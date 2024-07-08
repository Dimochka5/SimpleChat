namespace DataAccessLayer.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = "John Doe";

        public List<UserInChat> Chats { get; set; }

        public List<Message> Messages { get; set; }

    }
}
