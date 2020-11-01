using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace TandemTrivia
{
    public static class TriviaGame
    {
        public class Player
        {
            public string Name { get; set; }
            public int Score { get; set; } = 0;
        }

        public static void RunGame()
        {
            var players = GetPlayers();
            if (players == null)
            {
                return;
            }
            var questions = TriviaQuestion.LoadFromFile();
            Util.Shuffle(questions);
            var round = questions.Take(10).ToList();

            for (int questionIndex = 0; questionIndex < round.Count; questionIndex++)
            {
                foreach (var player in players)
                {
                    var question = round[questionIndex];
                    Console.Clear();
                    Console.Write("[");
                    Console.Write(new string('#', questionIndex * 6));
                    Console.Write(new string(' ', (round.Count - questionIndex) * 6));
                    Console.WriteLine("]");
                    if (players.Count > 1)
                    {
                        Console.WriteLine($"It's {player.Name}'s turn now");
                    }
                    Console.WriteLine($"You are on Question {questionIndex + 1} out of {round.Count}");
                    Console.WriteLine(question.Question);
                    var multipleChoiceAnswers = new List<string>();
                    multipleChoiceAnswers.AddRange(question.Incorrect);
                    multipleChoiceAnswers.Add(question.Correct);
                    Util.Shuffle(multipleChoiceAnswers);

                    var userAnswer = Util.ReadAnswer(multipleChoiceAnswers);
                    if (!userAnswer.HasValue)
                    {
                        return;
                    }
                    if (multipleChoiceAnswers[userAnswer.Value - 1] == question.Correct)
                    {
                        Console.WriteLine("Correct");
                        player.Score++;
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect! {question.Correct} was the correct answer");
                    }

                    Util.PromptContinue();
                }
            }

            UpdateSessionDetails(players);
            DisplayEndGameInfo(players);
        }

        private static List<Player> GetPlayers()
        {
            Console.Clear();
            Console.WriteLine("Choose a playing mode:");
            var gameModeOptions = new List<string>
            {
                "I'm a solo player",
                "I'm playing with a friend"
            };
            var playerCount = Util.ReadAnswer(gameModeOptions);
            if (!playerCount.HasValue)
            {
                return null;
            }
            var players = new List<Player>();
            for (int i = 0; i < playerCount; i++)
            {
                players.Add(new Player());
                Console.WriteLine(playerCount == 1 ? "Enter your name:" : $"Player {i + 1}, enter your name:");
                string playerName;
                while (true)
                {
                    playerName = Console.ReadLine();
                    if (!String.IsNullOrWhiteSpace(playerName))
                    {
                        break;
                    }
                    Console.WriteLine("Please enter a valid name");
                }
                players[i].Name = playerName;
            }
            return players;
        }

        private static void UpdateSessionDetails(List<Player> players)
        {
            foreach (var player in players)
            {
                SessionDetails.DetailsByUser.TryAdd(player.Name, new List<UserSessionDetails>());
                SessionDetails.DetailsByUser[player.Name].Add(new UserSessionDetails { Time = DateTime.Now, Score = player.Score });
            }
            SessionDetails.SaveToFile();
        }

        private static void DisplayEndGameInfo(List<Player> players)
        {
            Console.Clear();
            if (players.Count == 1)
            {
                Console.WriteLine($"You have finished a round of trivia. Your score is {players[0].Score} out of 10");
            }
            else
            {
                Console.WriteLine($"You have finished a round of trivia.");
                foreach (var player in players)
                {
                    Console.WriteLine($"{player.Name}'s score is {player.Score} out of 10");
                }
                if (players[0].Score != players[1].Score)
                {
                    var winningPlayerName = players.OrderByDescending(player => player.Score).First().Name;
                    Console.WriteLine($"{winningPlayerName} wins!");
                }
                else
                {
                    Console.WriteLine("Tie!");
                }
            }
            Util.PromptContinue();
        }
    }
}