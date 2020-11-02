using System;
using System.Collections.Generic;
using Xunit;
using UserToSessionDetails = System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<TandemTrivia.UserSessionDetails>>;

namespace TandemTrivia.Tests
{
    public class StatisticsTests
    {
        [Fact]
        public void TestGetStatsText()
        {
            Assert.Equal("", Statistics.GetStatsText(new UserToSessionDetails()));

            Assert.Throws<InvalidOperationException>(() => Statistics.GetStatsText(new UserToSessionDetails
            {
                { "Alice", new List<UserSessionDetails>() }
            }));

            Assert.Equal("Alice has an average score of 6.00 over 1 round(s)\r\n", Statistics.GetStatsText(new UserToSessionDetails
            {
                { "Alice", new List<UserSessionDetails>
                {
                    new UserSessionDetails { Score = 6 }
                } }
            }));

            Assert.Equal("Alice has an average score of 4.50 over 2 round(s)\r\n", Statistics.GetStatsText(new UserToSessionDetails
            {
                { "Alice", new List<UserSessionDetails>
                {
                    new UserSessionDetails { Score = 6 },
                    new UserSessionDetails { Score = 3 }
                } }
            }));

            Assert.Equal(
                "Charlie has an average score of 9.67 over 3 round(s)\r\n" +
                "Alice has an average score of 4.50 over 2 round(s)\r\n" +
                "Bob has an average score of 1.00 over 1 round(s)\r\n"
                , Statistics.GetStatsText(new UserToSessionDetails
            {
                { "Alice", new List<UserSessionDetails>
                {
                    new UserSessionDetails { Score = 6 },
                    new UserSessionDetails { Score = 3 }
                } },
                { "Bob", new List<UserSessionDetails>
                {
                    new UserSessionDetails { Score = 1 }
                } },
                { "Charlie", new List<UserSessionDetails>
                {
                    new UserSessionDetails { Score = 9 },
                    new UserSessionDetails { Score = 10 },
                    new UserSessionDetails { Score = 10 }
                } }
            }));
        }
    }
}
