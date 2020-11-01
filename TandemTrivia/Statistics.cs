using System;
using System.Linq;

namespace TandemTrivia
{
    public static class Statistics
    {
        public static void DisplayStats()
        {
            Console.Clear();
            Console.WriteLine("Stats");
            var statsByUser = SessionDetails.DetailsByUser
                .Select(kvp => new
                {
                    Name = kvp.Key,
                    SessionCount = kvp.Value.Count,
                    AverageScore = kvp.Value.Average(detail => detail.Score)
                })
                .OrderByDescending(stats => stats.AverageScore)
                .ToList();

            foreach (var stats in statsByUser)
            {
                var averageScore = stats.AverageScore.ToString("F2");
                Console.WriteLine($"{stats.Name} has an average score of {averageScore} over {stats.SessionCount} round(s)");
            }

            Util.PromptContinue();
        }
    }
}