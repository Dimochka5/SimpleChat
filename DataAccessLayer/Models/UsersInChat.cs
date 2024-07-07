namespace DataAccessLayer.Models
{
    public class UserInChat:IEntity
    {
        public int Id { get; set; }

        public User User { get; set; }

        public Chat Chat { get; set; }
    }
}
