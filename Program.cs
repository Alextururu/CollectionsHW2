using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsHW2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\M-015\\Downloads\\Text1.txt";//путь к файлу
            string readText = File.ReadAllText(filePath);
            string noPunctuationText = new string(readText.Where(c => !char.IsPunctuation(c)).ToArray());
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (string line in noPunctuationText.Split(new char[] { '\n', '\r', ' ' }))
            {
                if(!String.IsNullOrEmpty(line))
                {
                    if (!dict.ContainsKey(line))
                    {
                        dict.Add(line, 1);
                    }
                    else
                    {
                        int oldCount = dict[line];
                        dict[line] = oldCount + 1;
                    }
                }
            }
            //Опередеяем сортированный списко кол-ва
            List<int> LintCounts = dict.Values.ToList();
            LintCounts.Sort();
            LintCounts.Reverse();
            //Получаем список слов по кол-ву
            List<string> SortedCountWords = new List<string>();
            foreach (string word in dict.Keys)
            {
                int con = dict[word];
                for (int i = 0; i < 10; i++)
                {
                    int listCon = LintCounts[i];
                    if(con== listCon)
                    {
                        SortedCountWords.Add(word);
                    }
                }
            }
            Console.WriteLine("10 самых популярных слов в тексте - " + String.Join(",",SortedCountWords));
            Console.ReadKey();
        }
    }
}
