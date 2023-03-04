using Dictionary.Models;
using Microsoft.EntityFrameworkCore;

namespace Dictionary.DAL.Seeds
{
    public class DictionarySeeder
    {
        private readonly DictionaryContext Context;
        public DictionarySeeder(DictionaryContext context)
        {
            Context = context;
        }

        public void Seed()
        {
            var users = new List<User>
            {
                new User { Name = "Andrii", IsAdmin = true }
            };

            var languages = new List<Language>
            {
                new Language { Name = "English", Code = "eng" },
                new Language { Name = "Ukrainian", Code = "ua" }
            };

            var wordsPairs = new List<WordsPair>
            {
                new WordsPair { 
                    User = users[0], 
                    FirstLanguage = languages[0],
                    SecondLanguage = languages[1],
                    FirstWord = "Done",
                    SecondWord = "Готово",
                    Priority = 0,
                    AttemptsNumber = 0,
                    ProblemLevel = 0,
                    Added = DateTime.Now,
                    Updated = DateTime.Now
                },
                new WordsPair {
                    User = users.First(),
                    FirstLanguage = languages[0],
                    SecondLanguage = languages[1],
                    FirstWord = "Is",
                    SecondWord = "Є",
                    Priority = 0,
                    AttemptsNumber = 0,
                    ProblemLevel = 0,
                    Added = DateTime.Now,
                    Updated = DateTime.Now
                }
            };

            var tags = new List<Tag>
            {
                new Tag { 
                    User = users[0],
                    Name = "Important",
                    WordsPairs = new List<WordsPair> { wordsPairs[0] }
                },
                new Tag { 
                    User = users[0], 
                    Name = "Very important",
                    WordsPairs = new List<WordsPair> { wordsPairs[1] }
                }
            };

            wordsPairs[0].Tags = new List<Tag> { tags[0] };
            wordsPairs[1].Tags = new List<Tag> { tags[1] };

            var sessions = new List<Session>
            {
                new Session
                {
                    User = users[0],
                    IsClosed = false,
                    Added = DateTime.Now
                }
            };

            var sessionSets = new List<SessionSet>
            {
                new SessionSet
                {
                    Session = sessions[0],
                    WordsPair = wordsPairs[0],
                    WasShowedOnFirstLang = false,
                    WasShowedOnSecondLang = false,
                    WasSuccessfulOnFirstLang = false,
                    WasSuccessfulOnSecondLang = false
                },
                new SessionSet
                {
                    Session = sessions[0],
                    WordsPair = wordsPairs[1],
                    WasShowedOnFirstLang = false,
                    WasShowedOnSecondLang = false,
                    WasSuccessfulOnFirstLang = false,
                    WasSuccessfulOnSecondLang = false
                }
            };

            sessions[0].SessionSets = sessionSets;

            Context.Set<Language>().AddRange(languages);
            Context.Set<User>().AddRange(users);
            Context.Set<WordsPair>().AddRange(wordsPairs);
            Context.Set<Tag>().AddRange(tags);
            Context.Set<Session>().AddRange(sessions);
            Context.Set<SessionSet>().AddRange(sessionSets);

            Context.SaveChanges();
        }
    }
}
