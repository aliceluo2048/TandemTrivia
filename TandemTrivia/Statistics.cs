using System;
using System.Linq;
using System.Text;
using UserToSessionDetails = System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<TandemTrivia.UserSessionDetails>>;

namespace TandemTrivia
{
    public static class Statistics
    {
        public static void DisplayStats()
        {
            Console.Clear();
            Console.WriteLine("Stats");
            Console.Write(GetStatsText(SessionDetails.DetailsByUser));
            Util.PromptContinue();
        }

        public static string GetStatsText(UserToSessionDetails detailsByUser)
        {
            var statsByUser = detailsByUser
                .Select(kvp => new
                {
                    Name = kvp.Key,
                    SessionCount = kvp.Value.Count,
                    AverageScore = kvp.Value.Average(detail => detail.Score)
                })
                .OrderByDescending(stats => stats.AverageScore)
                .ToList();

            var sb = new StringBuilder();

            foreach (var stats in statsByUser)
            {
                var averageScore = stats.AverageScore.ToString("F2");
                sb.AppendLine($"{stats.Name} has an average score of {averageScore} over {stats.SessionCount} round(s)");
            }

            return sb.ToString();
        }
    }
}