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

    public static class SessionDetails
    {
        public static Dictionary<string, List<UserSessionDetails>> DetailsByUser { get; set; } = new Dictionary<string, List<UserSessionDetails>>();

        private static string FileName = AppDomain.CurrentDomain.BaseDirectory + "\\sessionDetails.json";

        public static void LoadFromFile()
        {
            if (!File.Exists(FileName))
            {
                DetailsByUser.Clear();
                return;
            }
            DetailsByUser = JsonConvert.DeserializeObject<Dictionary<string, List<UserSessionDetails>>>(File.ReadAllText(FileName));
        }

        public static void SaveToFile()
        {
            File.WriteAllText(FileName, JsonConvert.SerializeObject(DetailsByUser));
        }
    }
}
