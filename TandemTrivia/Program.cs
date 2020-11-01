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
            for (int i = 0; i <10 ; i++)
            {
                round.Add(questions[i]);
            }

            int score = 0; 

            foreach (TriviaQuestion question in round)
            {
                Console.WriteLine(question.Question);
                var multipleChoiceAnswers = new List<MultipleChoiceAnswers>();
                // no shuffling yet
                // 3 will only work assuming there are 3 incorrect, otherwise will error out
                for (int i = 0; i < 3; i++)
                {
                    multipleChoiceAnswers.Add(
                    new MultipleChoiceAnswers
                    {
                        AnswerNumber = i + 1,
                        Answer = question.Incorrect[i]
                    });
                };

                multipleChoiceAnswers.Add(new MultipleChoiceAnswers
                {
                    AnswerNumber = 4,
                    Answer = question.Correct
                });
         
                multipleChoiceAnswers.ForEach(answer => Console.WriteLine($"{answer.AnswerNumber}" + " " + $"{answer.Answer}"));
                var userAnswer = ReadAnswer();

                if (multipleChoiceAnswers[int.Parse(userAnswer) - 1].Answer == question.Correct)
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

        public class MultipleChoiceAnswers
        {
            public int AnswerNumber { get; set; }
            public string Answer { get; set; }
        }
    }
}