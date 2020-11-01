using System;
using System.Collections.Generic;
using System.Linq;

namespace TandemTrivia
{
    public static class TriviaGame
    {
        public static void RunGame()
        {
            var questions = TriviaQuestion.LoadFromFile(AppDomain.CurrentDomain.BaseDirectory + "\\" + "Apprentice_TandemFor400_Data.json");
            Util.Shuffle(questions);
            var round = questions.Take(10).ToList();
            int score = 0;

            foreach (TriviaQuestion question in round)
            {
                Console.Clear();
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

            Console.Clear();
            Console.WriteLine($"You have finished a round of trivia. Your score is {score} out of 10");
            Util.PromptContinue();
        }
    }
}