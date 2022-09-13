using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
 
namespace my_prog;

class Program
{
    static void Main(string[] args)
    {
        // принимаем только 1 аргумент на вход - имя файла
        if (args.Length != 1) {
            Console.WriteLine("Please, enter just one input file");
            return;
        }
        // проверка на существование файла по указанному пути
        string input = args[0];
        if (File.Exists(input) == false) {
            Console.WriteLine("Your file doesnt exist! :(");
            return;
        }
        // в мапу (словарь) запишем слова и их количество
        Dictionary<string, int> word_num_pairs = new Dictionary<string, int>();
        // в листы записываем файл 
        IEnumerable<string>fContent = new List<string>();
        //в массив запишем все символы, которые не могут войти в состав слова (возможно, сюда надо что-то еще добавить)
        char[] delimeters =  { ')', '(',']','[', '{', '}', ' ',',', '.', '!', '?', ':', ';', '-', '—'};
        fContent = File.ReadLines(input);
        foreach (var str in fContent)
        {
            // в цикле проходим по всем листам, сплитим строки файла по указанным символам.
            // Если слова нет в словаре, то добавляем его туда. Если есть, то +1 к счетчику этого слова
            var words = str.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
            foreach(var word in words)
            {
                if(word_num_pairs.ContainsKey(word) == false)
                {
                    word_num_pairs.Add(word, 1);
                }
                else
                {
                    word_num_pairs[word]++;
                }
            }
        }
        //сортируем по значению в порядке убывания и отсортированный словарь записываем в файл
        using (StreamWriter file = new StreamWriter("output.txt"))
        {
            var sort_words = word_num_pairs.OrderByDescending(_ => _.Value);
            foreach (var row in sort_words)
            {
                file.WriteLine($"{row.Key} {row.Value}");
            }
        }
        Console.WriteLine("Complited!");
    }      
}