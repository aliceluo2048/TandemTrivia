using System;
using System.Collections.Generic;

namespace TandemTrivia
{
    public static class Util
    {
        public static void PrintOptions(List<string> options)
        {
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}" + " " + $"{options[i]}");
            }
        }

        public static bool IsValidAnswer(string userAnswer, int optionsCount)
        {
            int number;
            bool success = Int32.TryParse(userAnswer, out number);
            return success && number >= 1 && number <= optionsCount;
        }

        public static int ReadAnswer(int optionsCount)
        {
            var userAnswer = Console.ReadLine();
            while (!IsValidAnswer(userAnswer, optionsCount))
            {
                Console.WriteLine($"Please enter a valid response. It should be between 1 - {optionsCount}");
                userAnswer = Console.ReadLine();
            }

            return int.Parse(userAnswer);
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

        public static void PromptContinue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}