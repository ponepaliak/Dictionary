using System.ComponentModel.DataAnnotations.Schema;

namespace Dictionary.Models
{
    public class WordsPair
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int FirstLanguageID { get; set; }
        public int SecondLanguageID { get; set; }
        public string FirstWord { get; set; }
        public string SecondWord { get; set; }
        public byte Priority { get; set; }
        public int AttemptsNumber { get; set; }
        public int ProblemLevel { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public DateTime Added { get; set; }
        public DateTime Updated { get; set; }

        public virtual User User { get; set; }
        [ForeignKey("FirstLanguageID")]
        public virtual Language FirstLanguage { get; set; }
        [ForeignKey("SecondLanguageID")]
        public virtual Language SecondLanguage { get; set; }
    }
}
