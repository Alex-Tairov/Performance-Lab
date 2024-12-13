using System;
using System.IO;

namespace Task2
{
    internal class Program
    {
        private static void CalculationResult(double hypotenuse,double radiusCircle)
        {
            if (hypotenuse == radiusCircle)
            {
                Console.WriteLine("0");

            }
            else if (hypotenuse < radiusCircle)
            {
                Console.WriteLine("1");
            }
            else if (hypotenuse > radiusCircle)
            {
                Console.WriteLine("2");
            }
        }
        static void Main(string[] args)
        {
           
            //Путь до файла,хранящий параметы окружности
             var cicleFilePath = args[0];

            //Путь до файла,хранящий список точек
            var pointFilePath = args[1];
            
            //Считываем данные из файла с оружностями
            var dataCircleFile = File.ReadAllLines(@cicleFilePath);

            //Вычисляем координаты окружности и ее радиус
            var circleCoordinates = dataCircleFile[0].Split();
            var xCoordinateCenterCircle = Convert.ToDouble(circleCoordinates[0]);
            var yCoordinateCenterCircle = Convert.ToDouble(circleCoordinates[1]);
            var radiusCircle = Convert.ToDouble(dataCircleFile[1]);

            //Считываем данные из файла с точками
            var dataPointFile = File.ReadAllLines(@pointFilePath);
            for (int i = 0; i < dataPointFile.Length; i++)
            {
                //Вычисляем координаты точек и гипотенузу
                var pointCoordinates = dataPointFile[i].Split();
                var xPointCoordinate = Convert.ToDouble(pointCoordinates[0]);
                var yPointCoordinate = Convert.ToDouble(pointCoordinates[1]);
                var hypotenuse = Math.Sqrt(Math.Pow((xPointCoordinate - xCoordinateCenterCircle), 2)
                    + Math.Pow((yPointCoordinate - yCoordinateCenterCircle), 2));

                //Выводим результат
                CalculationResult(hypotenuse, radiusCircle);
            }



        }
    }
}
