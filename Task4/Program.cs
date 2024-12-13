using System;
using System.IO;
using System.Linq;


namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Путь до файла
            var dataPath = args[0];
            
            //Считываем данные и преобразовываем в массив целых чисел
            var array = File.ReadAllLines(@dataPath).
                Select(x=>Convert.ToInt32(x)).ToArray();

            //Сортируем массив
            Array.Sort(array);

            //Считаем шаги
            var i = 0;
            var j = array.Length - 1;
            var steps = 0;
            while (i < j)
            {
                steps += (array[j] - array[i]);
                i++;
                j--;
            }

            Console.WriteLine(steps);
            
        }
    }
}
