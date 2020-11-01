using System;
using System.Collections.Generic;
using System.Linq;

namespace TandemTrivia
{
    public static class TriviaGame
    {
        public static void RunGame()
        {
            Console.WriteLine("Enter your name:");
            var playerName = Console.ReadLine();

            var questions = TriviaQuestion.LoadFromFile(AppDomain.CurrentDomain.BaseDirectory + "\\" + "Apprentice_TandemFor400_Data.json");
            Util.Shuffle(questions);
            var round = questions.Take(10).ToList();
            int score = 0;

            for (int questionIndex = 0; questionIndex < round.Count; questionIndex++)
            {
                var question = round[questionIndex];
                Console.Clear();
                Console.Write("[");
                Console.Write(new string('#', questionIndex * 6));
                Console.Write(new string(' ', (round.Count - questionIndex) * 6));
                Console.WriteLine("]");
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
                    score++;
                }
                else
                {
                    Console.WriteLine($"Incorrect! {question.Correct} was the correct answer");
                }

                Util.PromptContinue();
            }

            Statistics.SessionDetails.DetailsByUser.TryAdd(playerName, new List<UserSessionDetails>());
            Statistics.SessionDetails.DetailsByUser[playerName].Add(new UserSessionDetails { Time = DateTime.Now, Score = score });

            Console.Clear();
            Console.WriteLine($"You have finished a round of trivia. Your score is {score} out of 10");
            Util.PromptContinue();
        }
    }
}