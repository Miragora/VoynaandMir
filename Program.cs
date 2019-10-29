using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace net
{
    class Program
    {
         private const string file_name = "voyna-i-mir-tom-1.txt";

        static void Main(string[] args)
        {
            var file = new FileInfo(file_name);
           
            if( !file.Exists)
            {
                Console.WriteLine (" Ne sushestvuet");
                return;
            }
            Console.WriteLine (" Razmer fayla {0}", file.Length);
            var words_dict = new Dictionary<string,int>(); // присваиваем словам их количество
            using (var reader = new StreamReader(file_name, Encoding.UTF8)) // читаем файл построчно 
            {
              while(!reader.EndOfStream)
              {
                  var line = reader.ReadLine(); // считываем строку
                  if( line.Length ==0) continue; // continue перебрасывает нас на начало цикла
                  var words = line.Split(' '); // разбиваем строку по пробелам, string[] - получается массив из слов
                  
                  foreach (var word in words)
                  {
                      var w = word.Trim().Trim(".,;!?[]()".ToCharArray()).ToLower(); //ToLower() делает нижний регистр, чтобы 'слова с большой буквы' = 'слова с маленькой'
                      //var w = word.Trim().Trim('.', ',', ';', '!', '?', ')');//удаляет символы в слове

                      if(w==null||w.Length==0) // || - оператор "ИЛИ" ("ленивый" оператор), 
                                                    //ленивые операторы минимизируют количество работы 
                                                    //(если слева истина, то он проверяет то что справа. если слева ложь, то то что справа он не проверяет)
                      continue;
                      if( words_dict.ContainsKey(w))

                      words_dict[w]++; 
                      else 
                      words_dict.Add(w, 1); // если слово встретилось 1 раз
                  }

              }
            }
            foreach (var item in words_dict)
            {
                Console.WriteLine("{0}-{1}", item.Key, item.Value);
             }
        }

       


    }
}
