using System;
using System.Collections.Generic;
using System.IO;

namespace TandemTrivia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            LoadJson();
        }

        public class Trivia
        {
            public string Question { get; set; }
            public List<string> Incorrect { get; set; }
            public string Correct { get; set; }
        }

        public static void LoadJson()
        {
            string fileName = "Apprentice_TandemFor400_Data.json";
            try
            {
                using (StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\" + fileName))
                {
                    //var json = r.ReadToEnd();
                    //var items = JsonConvert.DeserializeObject<List<Trivia>>(json);
                    //foreach (var item in items)
                    //{
                    //    Console.WriteLine(item.Question);
                    //}
                    Console.WriteLine(r.ReadToEnd());
                    Console.ReadKey();
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.ToString());
            }


            //JObject o1 = JObject.Parse(File.ReadAllText("Apprentice_TandemFor400_Data.json"));

            //// read JSON directly from a file
            //using (StreamReader file = File.OpenText("Apprentice_TandemFor400_Data.json"))
            //using (JsonTextReader reader = new JsonTextReader(file))
            //{
            //    JObject o2 = (JObject)JToken.ReadFrom(reader);
            //}
        }
    }
}
