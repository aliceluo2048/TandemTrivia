using System;

namespace TandemTrivia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var questions = TriviaQuestion.LoadFromFile(AppDomain.CurrentDomain.BaseDirectory + "\\" + "Apprentice_TandemFor400_Data.json");
        }
    }
}