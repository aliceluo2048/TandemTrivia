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
                Console.WriteLine("Please select the following options:");
                Util.PrintOptions(menuOptions);
                int userResponse = Util.ReadAnswer(menuOptions.Count);
                if (userResponse == 1)
                {
                    TriviaGame.RunGame();
                }
            }
        }
    }
}