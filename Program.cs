using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Practic18
{
    public class Program
    {
        public static void Main()
        {
            string path = "data.txt";
            Console.Write("Введите число: ");
            Console.WriteLine(SumSetFinder(Console.ReadLine(), path));
            Console.ReadKey();
        }

        public static string SumSetFinder(string number, string path)
        {
            short m;
            if (Enter(number, out m))
            {
                short[] data = new short[33554432];
                string answer = "";
                if (File.Exists(path))
                {
                    Fill(15);
                    try
                    {
                        Console.WriteLine("Наборы");
                        string input = File.ReadAllText(path);
                        if (input=="" || input.Split(new char[] { ' ', '\n', '\t' }).Length!=0) 
                            return "Файл пуст";
                        data=input.Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(x => Int16.Parse(x))
                                  .ToArray();
                        if (data.Length>20)
                            return "Большой объём входных данных";

                        var list = Count(data, m);

                        if (list.Count != 0)
                        {
                            foreach (var item in list)
                            {
                                foreach (var i in SetFromCode(data, item))
                                    answer += $"{i} ";
                                answer += "\n";
                            }
                            return answer;
                        }
                        else return "Нет таких комбинаций";
                    }
                    catch
                    {
                        return "Информация записана в файле неверно";
                    }
                }
                else
                {
                    return "Файл не найден";
                }
            }
            else return "Ввод неверен";
        }
        public static bool Enter(string number, out short output)
        {
            return Int16.TryParse(number, out output);
        }
        public static List<string> Count(short[] data, int needSum)
        {
            var list = new List<string>();
            for (int i = 0; i < Math.Pow(2, data.Length); i++) 
            {
                var temp = GenerateCode(i, data.Length);
                if (SetSum(data, temp)== needSum)
                list.Add(temp);
            }
            return list;
        }
        public static int SetSum(short[] set, string code)
        {
            int sum = 0;
            for (int i = 0; i < set.Length; i++)
            {
                if (code[i] == '1')
                    sum += set[i];
            }
            return sum;
        }
        public static string GenerateCode(int number, int length)
        {
            string code = Convert.ToString(number, 2);
                while (code.Length != length)
                {
                    code = '0' + code;
                }
            return code;
        }
        public static List<int> SetFromCode(short[] set, string code)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < code.Length; i++)
            { 
                if (code[i] == '1')
                        list.Add(set[i]);
            }
            return list;
        }

        //Генерация данных
        static void Fill(int count)
        {
            int[] set = new int[count];
            Random random = new Random();
            for (int i=0;i< count; i++)
                set[i] = random.Next(-count, count);

            File.WriteAllText("data.txt", String.Join(" ", set));
        }

    }
}
