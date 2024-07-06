namespace DataAccessLayer.Models
{
    public class Chat
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<UserInChat> Users { get; set; }

        public List<Message> Messages { get; set; }
    }
}
