using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

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

    public class SessionDetails
    {
        [JsonProperty]
        public Dictionary<string, List<UserSessionDetails>> DetailsByUser { get; set; } = new Dictionary<string, List<UserSessionDetails>>();

        private static string FileName = AppDomain.CurrentDomain.BaseDirectory + "\\sessionDetails.json";
        public static SessionDetails Instance = new SessionDetails();

        public static void LoadFromFile()
        {
            if (!File.Exists(FileName))
            {
                Instance = new SessionDetails();
                return;
            }
            Instance = JsonConvert.DeserializeObject<SessionDetails>(File.ReadAllText(FileName));
        }

        public static void SaveToFile()
        {
            File.WriteAllText(FileName, JsonConvert.SerializeObject(Instance));
        }
    }
}
