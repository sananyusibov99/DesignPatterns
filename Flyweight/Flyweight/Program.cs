using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    class Translate
    {
        public string Word { get; set; }
        public string Translation { get; set; }

        public override string ToString()
        {
            return $"{Translation}";
        }
    }

    interface ICache<TKey, TValue>
    {
        TValue GetValue(TKey key);
        void AddValue(TKey key, TValue value);
    }

    class TranslateCache : ICache<string, Translate>
    {
        Dictionary<string, Translate> words = new Dictionary<string, Translate>();

        public Translate GetValue(string key)
        {
            if (words.ContainsKey(key))
            {
                return words[key];
            }
            return null;
        }

        public void AddValue(string key, Translate value)
        {
            words.Add(key, value);
        }
    }

    class TranslateAPI
    {
        readonly string apiUrl = @"https://translate.yandex.net/api/v1.5/tr.json/translate";
        readonly string apiKey = "trnsl.1.1.20180519T085039Z.2c50b69f58c34887.7d37dc64e412a4142605130cdb6705d8e840df03";

        ICache<string, Translate> cache = new TranslateCache();

        public Translate Search(string Wordd)
        {
            var word = cache.GetValue(Wordd);
            if (word == null)
            {
                Console.WriteLine("Reading data from API...");

                var webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;

                try
                {
                    //Console.WriteLine(Wordd);
                   // Console.WriteLine($"{apiUrl}?key={apiKey}&text={Wordd}&lang=ru");
                    var result = webClient.DownloadString($"{apiUrl}?key={apiKey}&text={Wordd}&lang=ru");
                    dynamic data = JsonConvert.DeserializeObject(result);
                    word = new Translate
                    {
                        Word = Wordd,
                        Translation = data.text[0],
                    };

                    cache.AddValue(word.Word, word);
                }
                catch (WebException)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw new Exception("Not found!");
                }
            }
            else
            {
                Console.WriteLine("Reading data from cache...");
            }
            return word;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var search = new TranslateAPI();

            var Words = new List<string>()
            {
                "Thanks so much",
                "I really appreciate",
                "Excuse me",
                "How does that sound?",
                "That sounds great",
                "Never mind",
            };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose the word: ");
                int index = 1;
                foreach (var item in Words)
                {
                    Console.WriteLine($"{index++}) {item}");
                }

                Int32.TryParse(Console.ReadLine(), out int number);
                try
                {
                    var word = search.Search(Words[number - 1]);
                    Console.WriteLine(word);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("\nPress ESC to exit or any key to continue...");
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                    break;
            }
        }
    }
}
