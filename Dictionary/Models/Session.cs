namespace Dictionary.Models
{
    public class Session
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public bool IsClosed{ get; set; }
        public ICollection<SessionSet> SessionSets { get; set; }
        public DateTime Added { get; set; }

        public User User { get; set; }
    }
}
