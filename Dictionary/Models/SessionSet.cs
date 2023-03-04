namespace Dictionary.Models
{
    public class SessionSet
    {
        public int ID { get; set; }
        public int SessionID { get; set; }
        public int WordsPairID { get; set; }
        public bool WasShowedOnFirstLang { get; set; }
        public bool WasShowedOnSecondLang { get; set; }
        public bool WasSuccessfulOnFirstLang { get; set; }
        public bool WasSuccessfulOnSecondLang { get; set; }

        public virtual Session Session { get; set; }
        public virtual WordsPair WordsPair { get; set; }
    }
}
