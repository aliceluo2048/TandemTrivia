using System;
using System.Collections.Generic;

namespace TandemTrivia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var questions = TriviaQuestion.LoadFromFile(AppDomain.CurrentDomain.BaseDirectory + "\\" + "Apprentice_TandemFor400_Data.json");

            // creates a round 
            var round = new List<TriviaQuestion>();
            // to do filter valid questions first
            // to do shuffle
            for (int i = 0; i < 10; i++)
            {
                round.Add(questions[i]);
            }

            Shuffle(round);

            int score = 0; 

            foreach (TriviaQuestion question in round)
            {
                Console.WriteLine(question.Question);
                var multipleChoiceAnswers = new List<string>();
                multipleChoiceAnswers.AddRange(question.Incorrect);
                multipleChoiceAnswers.Add(question.Correct);
                Shuffle(multipleChoiceAnswers);
         
                for (int i = 0; i < multipleChoiceAnswers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}" + " " + $"{multipleChoiceAnswers[i]}");
                }

                var userAnswer = ReadAnswer();

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

        static bool IsValidAnswer (string userAnswer)
        {
            int number;
            bool success = Int32.TryParse(userAnswer, out number);
            return success && number >= 1 && number <= 4;
        }

        static string ReadAnswer()
        {
            var userAnswer = Console.ReadLine();
            while (!IsValidAnswer(userAnswer))
            {
                Console.WriteLine("Please enter a valid answer. It should be between 1 - 4");
                userAnswer = Console.ReadLine();
            }

            return userAnswer;
        }

        // Fisher-Yates shuffle code from https://developerslogblog.wordpress.com/2020/02/04/how-to-shuffle-an-array/
        static void Shuffle<T>(List<T> list)
        {
            var random = new Random();
            for (int i = list.Count - 1; i > 0; i--)
            {
                int randomIndex = random.Next(0, i + 1);
                T temp = list[i];
                list[i] = list[randomIndex];
                list[randomIndex] = temp;
            }
        }
    }
}