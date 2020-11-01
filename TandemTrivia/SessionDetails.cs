using System;
using System.Collections.Generic;

namespace TandemTrivia
{
    public class UserSessionDetails
    {
        public DateTime Time { get; set; }
        public int Score { get; set; }
    }

    public class SessionDetails
    {
        public Dictionary<string, List<UserSessionDetails>> DetailsByUser { get; set; } = new Dictionary<string, List<UserSessionDetails>>();
    }
}
