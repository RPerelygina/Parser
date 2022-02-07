using System.Net.Http;
using HtmlAgilityPack;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;

namespace Parser
{
    public class LoadHtml
    {
        
        public string InnerText(string Url)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(Url);
            return doc.DocumentNode.InnerText;
        }
    }
    public class SplitText
    {
        private static string CleanedString(string str)
        {
            var pattern = "[^а-яА-ЯёЁa-zA-Z0-9]";
            var reg_exp = new Regex(pattern);
            return reg_exp.Replace(str, " ");
        }

        public string[] SplitString(string str)
        {
            var cleanedString = CleanedString(str);
            return cleanedString.Split(new char[] { ' ' },
                     StringSplitOptions.RemoveEmptyEntries);

        }
    }
        public class UniqueWords
        {
            public void UniqueWordsCount(string[] splitedItems)
            {

                var groupedItems = splitedItems.GroupBy(x => x);

                foreach (var item in groupedItems)

                    Console.WriteLine(item.Key + "-" + item.Count());

            }
        }
    
    public class Program
    {
        public static void Main()
        {
            
            try
            {
                var loadHtml = new LoadHtml();

                Console.WriteLine("Введите ссылку");
                var str = loadHtml.InnerText(Console.ReadLine());
            
                var splitText = new SplitText();
                var myarray = splitText.SplitString(str);

                var WordCount = new UniqueWords();
                WordCount.UniqueWordsCount(myarray);

            }

            catch (Exception ex)

            {
                Console.WriteLine($"Во время работы парсера произошла ошибка. Ошибка:{ex}");
                Main();
            }


            Console.ReadLine();
        }
    }
}