﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace TandemTrivia
{
    public class TriviaQuestion
    {
        public string Question { get; set; }
        public List<string> Incorrect { get; set; }
        public string Correct { get; set; }

        public static List<TriviaQuestion> LoadFromFile(string fileName)
        {
            // TODO: Some questions only seem to have < 3 incorrect answers, we should throw them out
            return JArray.Parse(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Apprentice_TandemFor400_Data.json"))
                .Select(questionElement => new TriviaQuestion
                {
                    Question = questionElement["question"].ToString(),
                    Correct = questionElement["correct"].ToString(),
                    Incorrect = questionElement["incorrect"].Select(elem => elem.ToString()).ToList()
                })
                .ToList();
        }
    }
}