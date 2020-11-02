using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TandemTrivia
{
    [JsonObject(MemberSerialization.OptIn)]
    public class TriviaQuestion
    {
        [JsonProperty("question")]
        public string Question { get; set; }
        [JsonProperty("incorrect")]
        public List<string> Incorrect { get; set; } = new List<string>();
        [JsonProperty("correct")]
        public string Correct { get; set; }

        public int CountUniqueAnswers()
        {
            var answers = new HashSet<string>();

            foreach (var answer in Incorrect)
            {
                answers.Add(answer);
            }
            answers.Add(Correct);

            return answers.Count;
        }

        public static List<TriviaQuestion> LoadFromFile()
        {
            return JsonConvert.DeserializeObject<List<TriviaQuestion>>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Apprentice_TandemFor400_Data.json"))
                .Where(question => question.CountUniqueAnswers() == 4)
                .ToList();
        }
    }
}