using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task13._6._2
{
    class Program
    {
        static Dictionary<string, int> Words = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            var filePath = Path.Combine(GetSolutionRoot(), "Text2.txt");
            try
            {
                // Читаем текст
                string text = File.ReadAllText(filePath);

                // Преобразуем в массив слов
                var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
                char[] separators = new char[] { ' ', '\r', '\n' };
                string[] wordsList = noPunctuationText.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                // Добавляем слово как ключ и увеличиваем значение при повторении
                foreach (var word in wordsList)
                {
                    if (Words.ContainsKey(word))
                    {
                        Words[word]++;
                    }
                    else
                    {
                        Words.Add(word, 1);
                    }
                }

                // Отбираем 10 самых часто встречающихся слов
                var rate = Words.OrderByDescending(w => w.Value).Take(10);
                Console.WriteLine("Самые распространенные слова в тексте:\n");
                foreach (var item in rate)
                {
                    Console.WriteLine($"---> ({item.Key}) повторяется {item.Value} раз");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static string GetSolutionRoot()
        {
            var dir = Path.GetDirectoryName(Directory.GetCurrentDirectory());
            var fullname = Directory.GetParent(dir).FullName;
            var projectRoot = fullname.Substring(0, fullname.Length - 4);
            return Directory.GetParent(projectRoot)?.FullName;
        }
    }
}
