using System;
using System.Collections.Generic;

namespace TandemTrivia
{
    public static class Util
    {
        public static bool IsValidAnswer(string userAnswer)
        {
            int number;
            bool success = Int32.TryParse(userAnswer, out number);
            return success && number >= 1 && number <= 4;
        }

        public static string ReadAnswer()
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
        public static void Shuffle<T>(List<T> list)
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