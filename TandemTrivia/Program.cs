using System;
using System.Collections.Generic;

namespace TandemTrivia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                var menuOptions = new List<string>
                {
                    "New Game",
                    "Help",
                    "Leaderboard"
                };

                Console.WriteLine("Welcome to the Tandem Trivia Training app!");
                var userResponse = Util.ReadAnswer(menuOptions);
                if (!userResponse.HasValue)
                {
                    return;
                }
                if (userResponse.Value == 1)
                {
                    TriviaGame.RunGame();
                }
            }
        }
    }
}