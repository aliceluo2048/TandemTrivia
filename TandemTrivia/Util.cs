using System;
using System.Collections.Generic;

namespace TandemTrivia
{
    public static class Util
    {
        public static bool IsValidAnswer(string userAnswer, int optionsCount)
        {
            int number;
            bool success = Int32.TryParse(userAnswer, out number);
            return success && number >= 1 && number <= optionsCount;
        }

        public static int? ReadAnswer(List<string> options)
        {
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
            while (true)
            {
                Console.WriteLine($"Please enter a response between 1 - {options.Count} or uppercase Q to quit");
                var userAnswer = Console.ReadLine();
                if (userAnswer == "Q")
                {
                    Console.WriteLine("Are you sure you want to quit? Confirm with uppercase Q");
                    userAnswer = Console.ReadLine();
                    if (userAnswer == "Q")
                    {
                        return null;
                    }
                }
                if (IsValidAnswer(userAnswer, options.Count))
                {
                    return int.Parse(userAnswer);
                }
            }
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

        public static string GetProgressBarText(int progressIndex, int progressTotal)
        {
            return "["
                + new string('#', progressIndex * 6)
                + new string(' ', (progressTotal - progressIndex) * 6)
                + "]";
        }
    }
}