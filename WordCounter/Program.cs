using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = ReadFileToEnd(@"..\..\FileTxt.txt");

            ShowWordCount(
                GetWordGroups(
                    GetAllWords(text, GetSeparators(text))));
        }

       

        static string ReadFileToEnd(string pathToFile)
        {
            return File.ReadAllText(pathToFile);
        }
        static IEnumerable<char> GetSeparators(string text)
        {
            var separatorList = text.Where(Char.IsPunctuation).Distinct().ToList();
            separatorList.Add('\n');
            separatorList.Add(' ');

            if (separatorList.Contains('#'))
            {
                separatorList.Remove('#');
            }

            return separatorList;
        }
        static IEnumerable<string> GetAllWords(string text, IEnumerable<char> punctuation)
        {
            return text.Split().Select(x => x.Trim(punctuation.ToArray()));
        }
        static IEnumerable<IGrouping<string, string>> GetWordGroups(IEnumerable<string> words)
        {
            return words.GroupBy(x => x);
        }
        static void ShowWordCount(IEnumerable<IGrouping<string, string>> wordGroups)
        {
            foreach (var wordGroup in wordGroups)
            {
                Console.WriteLine($"{wordGroup.First()} : {wordGroup.Count()}");
            }
        }
    }
}
