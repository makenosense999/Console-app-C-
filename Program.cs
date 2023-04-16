using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace First
{
    class Program
    {
        static void Main(string[] args)
        {
            // Чтение файла.
            string text = File.ReadAllText("WarAndPeace.txt");

            // Делим текст на слова.
            string[] words = Regex.Split(text, @"\W+|\d+");

            // Считаем частоту употребления каждого слова.
            var wordCounts = words.GroupBy(x => x)
                                   .Select(x => new { Word = x.Key, Count = x.Count() })
                                   .OrderByDescending(x => x.Count);

            // Записываем результат в файл.
            using (StreamWriter writer = new StreamWriter("WordCounts.txt"))
            {
                foreach (var wc in wordCounts)
                {
                    writer.WriteLine("{0} {1}", wc.Word, wc.Count);
                }
            }
        }
    }
}
