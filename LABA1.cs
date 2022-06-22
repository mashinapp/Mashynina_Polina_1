using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace laba11
{
    class laba1_1
    {
        public static void Main()
        {
            {
                string[] indexWithStreet;
                string[] nameOfStreet;//масиви для роботи з методом Split
                List<Adress> C1 = new List<Adress>();//створюємо список
                string[] lines = File.ReadAllLines(@"/Users/polinamashinina/Documents/laba1/op.txt");//зчитує весь текст як масив строчок 
                Console.WriteLine("File:");
                foreach (var i in lines)
                    Console.WriteLine(i);//виводимо в консоль інф. з файлу
                for (int i = 0; i < lines.Length; i++)
                {
                    indexWithStreet = lines[i].Split(',');//Split розбива даний рядок використовуючи , як роздільник 
                    nameOfStreet = indexWithStreet[0].Split('.');// перша записана інф до крапки 
                    C1.Add(new Adress() { Index = int.Parse(nameOfStreet[0]), Street = nameOfStreet[1] });
                }
                var orderedC1 = C1.OrderBy(x => x.Index).GroupBy(p => p.Street).Select(grp => grp.FirstOrDefault());//через LINQ сорт. за Index,групуємо за параметром Street і видаляємо всі повтори окрім першого
                Console.WriteLine("Ordered List of streets:");
                foreach (var i in orderedC1)
                    Console.WriteLine(i.Index + "." + i.Street);//запис результату
            }
        }
        public class Adress//створюємо клас об'єктів Adress 
        {
            public int Index { get; set; }
            public string Street { get; set; }
        }
    }
    class laba1_2
    {
        //Вивести елементи словника строка за строкою.Записати результат у файл.
        //Перетворити вміст файлу назад у словник. Результат записати в JSON форматі

        public static void Main(string[] args)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>()//створюємо словник де і ключ і значення стрінгові
            {
                {"Слава", "Україні"},
                {"Героям", "Cлава"}
            };//вписали значення
            Console.WriteLine("Dictionary:");//строка назви словник
            foreach (var item in dictionary)
                Console.WriteLine(item.Key + " - " + item.Value);// виведення на консоль ключ-значення
            string json = JsonConvert.SerializeObject(dictionary);
            File.WriteAllText(@"/Users/polinamashinina/Documents/laba1/222", json);//записуємо в файл
            var newDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);//в json формат
        }
    }
    class laba1_3
    {
        public static void Main(string[] args)
        {
            //Дана цифра D(ціле однозначне число) і послідовність цілих чисел A.
            //Витягти з A всі різні додатні числа, що закінчуються цифрою D(в вихідному порядку).
            //При наявності повторюваних елементів видаляти всі їх входження, крім останніх.
            //Порада: Послідовно застосувати методи Reverse, Distinct, Reverse. (2)

            int D = 2;//ціле однозначне число
            List<int> A = new List<int>();
            Random rnd = new Random();
            Console.WriteLine("poslidovnist:");
            for (int i = 0; i < 25; i++)
            {
                A.Add(rnd.Next(-500, 500));//рандомна послідовність А
                Console.Write(A[i] + " ");
            }
            var result = A.Where(p => p > 0 && p.ToString().EndsWith(D.ToString())).Reverse().Distinct().Reverse().OrderBy(p => p);
            //пошук елементів в А які більше 0,форматуємо Д в стрінг і шукаємо числа які закінчуються на Д
            //реверсуємо весь набір щоб видалити повтори, реверсуємо назад і перший неповторювальний елемент стає останнім
            Console.WriteLine("\n Ordered List:");
            foreach (var i in result)
                Console.WriteLine(i + " ");//виводимо всі елементи які підійшли по сортировці


        }
    }
        
}
