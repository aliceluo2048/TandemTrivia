using System;
using System.Collections.Generic;
using System.Linq;

namespace TandemTrivia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var questions = TriviaQuestion.LoadFromFile(AppDomain.CurrentDomain.BaseDirectory + "\\" + "Apprentice_TandemFor400_Data.json");
            Util.Shuffle(questions);
            var round = questions.Take(10).ToList();
            int score = 0;

            foreach (TriviaQuestion question in round)
            {
                Console.WriteLine(question.Question);
                var multipleChoiceAnswers = new List<string>();
                multipleChoiceAnswers.AddRange(question.Incorrect);
                multipleChoiceAnswers.Add(question.Correct);
                Util.Shuffle(multipleChoiceAnswers);

                for (int i = 0; i < multipleChoiceAnswers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}" + " " + $"{multipleChoiceAnswers[i]}");
                }

                var userAnswer = Util.ReadAnswer();

                if (multipleChoiceAnswers[int.Parse(userAnswer) - 1] == question.Correct)
                {
                    Console.WriteLine("Correct");
                    score++;
                }
                else
                {
                    Console.WriteLine($"Incorrect! {question.Correct} was the correct answer");
                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine($"You have finished a round of trivia. Your score is {score} out of 10");
        }
    }
}