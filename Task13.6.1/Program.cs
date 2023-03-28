using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Task13._6._1
{
    class Program
    {
        static List<string> List = new List<string>();
        static LinkedList<string> LinkList = new LinkedList<string>();

        static void Main(string[] args)
        {
            var filePath = Path.Combine(GetSolutionRoot(), "Text1.txt");
            try
            {
                string Text = File.ReadAllText(filePath);
                char[] separators = new char[] { ' ', '\r', '\n' };
                string[] words = Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                var Watch = Stopwatch.StartNew();
                foreach (var item in words)
                {
                    List.Add(item);
                }
                Console.WriteLine($"Время вставки в List<T>: {Watch.Elapsed.TotalMilliseconds} мс");

                Watch = Stopwatch.StartNew();

                foreach (var item in words)
                {
                    LinkList.AddLast(item);
                }
                Console.WriteLine($"Время вставки в LinkedList<T>: {Watch.Elapsed.TotalMilliseconds} мс");
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
