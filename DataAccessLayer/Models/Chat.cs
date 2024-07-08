namespace DataAccessLayer.Models
{
    public class Chat : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = "Default name";

        public List<UserInChat> Users { get; set; }

        public List<Message> Messages { get; set; }
    }
}
