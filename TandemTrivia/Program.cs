using System;
using System.Collections.Generic;

namespace TandemTrivia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SessionDetails.LoadFromFile();

            while (true)
            {
                Console.Clear();
                var menuOptions = new List<string>
                {
                    "New Game",
                    "Stats"
                };

                Console.WriteLine("Welcome to the Tandem Trivia Training app!");
                var userResponse = Util.ReadAnswer(menuOptions);

                if (!userResponse.HasValue)
                {
                    return;
                }
                else if (userResponse.Value == 1)
                {
                    TriviaGame.RunGame();
                }
                else if (userResponse.Value == 2)
                {
                    Statistics.DisplayStats();
                }
            }
        }
    }
}