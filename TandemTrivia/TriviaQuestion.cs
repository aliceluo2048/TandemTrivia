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
        public List<string> Incorrect { get; set; }
        [JsonProperty("correct")]
        public string Correct { get; set; }

        public static List<TriviaQuestion> LoadFromFile()
        {
            // TODO: Validate that all four choices are unique
            return JsonConvert.DeserializeObject<List<TriviaQuestion>>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Apprentice_TandemFor400_Data.json"))
                .Where(question => question.Incorrect.Count == 3)
                .ToList();
        }
    }
}