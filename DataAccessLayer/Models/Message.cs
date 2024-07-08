namespace DataAccessLayer.Models
{
    public class Message : IEntity
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime DateTime { get; set; }

        public User? User { get; set; }

        public Chat? Chat { get; set; }
    }
}
