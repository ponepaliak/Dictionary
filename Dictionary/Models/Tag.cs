namespace Dictionary.Models
{
    public class Tag
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<WordsPair> WordsPairs { get; set; }
    }
}
