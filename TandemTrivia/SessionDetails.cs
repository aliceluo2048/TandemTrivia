using System;
using System.IO;
using Newtonsoft.Json;
using UserToSessionDetails = System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<TandemTrivia.UserSessionDetails>>;

namespace TandemTrivia
{
    [JsonObject(MemberSerialization.OptIn)]
    public class UserSessionDetails
    {
        [JsonProperty]
        public DateTime Time { get; set; }
        [JsonProperty]
        public int Score { get; set; }
    }

    public static class SessionDetails
    {
        public static UserToSessionDetails DetailsByUser { get; set; } = new UserToSessionDetails();

        private static string FileName = AppDomain.CurrentDomain.BaseDirectory + "\\sessionDetails.json";

        public static void LoadFromFile()
        {
            if (!File.Exists(FileName))
            {
                DetailsByUser.Clear();

                return;
            }

            DetailsByUser = JsonConvert.DeserializeObject<UserToSessionDetails>(File.ReadAllText(FileName));
        }

        public static void SaveToFile()
        {
            File.WriteAllText(FileName, JsonConvert.SerializeObject(DetailsByUser));
        }
    }
}