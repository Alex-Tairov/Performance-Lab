using System;
using System.Collections.Generic;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Длина массива
            var arrayLenght = Convert.ToInt32(args[0]);
            
            //Длина интервала
            var interval = Convert.ToInt32(args[1]);
          
            //Создание и заполнение массива
            var arrayNumbers = new int[arrayLenght];

            for (int i = 0; i < arrayLenght; i++)
            {
                arrayNumbers[i] = i + 1;
            }

            //Список хранящий числа,полученные при обходе массива
            var temporaryResultList = new List<int>();

            //Индекс числа ,полученный при обходе
            int currentElementIndex = 0;

            //Обход массива
            do
            {
                temporaryResultList.Add(arrayNumbers[currentElementIndex]);
                currentElementIndex = (currentElementIndex + interval - 1) % arrayLenght;
            }
            while (currentElementIndex != 0);

            //Преобразование списка в массив
            var resultArray = temporaryResultList.ToArray();

            //Вывод массива
            for (int i = 0; i < resultArray.Length; i++)
            {
                Console.Write(resultArray[i]);
            }

        }
    }
}
