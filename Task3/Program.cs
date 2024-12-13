using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task3
{

    internal class Program
    {
        static void UpdateTestValues(JToken tests, JToken values)
        {
            //Создаем словарь для values 
            var valueDict = new Dictionary<int, string>();

            foreach (var value in values)
            {
                var id = Convert.ToInt32(value["id"]);
                var resultValue = Convert.ToString(value["value"]);
                valueDict[id] = resultValue;
            }

            // Обновляем значения в tests
            foreach (var test in tests)
            {

                // Устанавливаем значение из словаря
                var testId = (int)test["id"];
                if (valueDict.TryGetValue(testId, out string testValue))
                {
                    test["value"] = testValue;
                }

                // Рекурсивно обновляем значения в вложенных структурах
                if (test["values"] != null)
                {
                    UpdateNestedArrayValues(test["values"], valueDict);
                }
            }
        }

        //Обновление значений во вложенных массивах
        static void UpdateNestedArrayValues(JToken values, Dictionary<int, string> valueDict)
        {
            foreach (var item in values)
            {
                var itemId = (int)item["id"];
                if (valueDict.TryGetValue(itemId, out string itemValue))
                {
                    // Устанавливаем значение из словаря
                    item["value"] = itemValue;
                }

                // Рекурсивно обновляем значения во вложенных массивах
                if (item["values"] != null)
                {
                    UpdateNestedArrayValues(item["values"], valueDict);
                }
            }
        }

        //Перезапись данных
        public static void Set(string path, string value)
        {
            var writer = new StreamWriter(path, false, Encoding.UTF8);
            writer.WriteLine(value);
            writer.Close();
        }


        //Проверяем существует ли такой файл
        public static bool IsExists(string path)
        {
            return File.Exists(path);
        }
        //Считывание данных из файла
        public static string Get(string path)
        {
            StreamReader reader = new StreamReader(path);
            {
                string result = reader.ReadToEnd();
                reader.Close();
                return result;
            }
        }


        static void Main(string[] args)
        {
            //Путь до файла values
            var valuesFilePath = args[0];

            // Путь до файла tests
            var testsFilePath = args[1];

            // Путь до файла report
            var reportFilePath = args[2];

            //Считываем значения из файлов
            var values = Get(@valuesFilePath);
            var tests = Get(@testsFilePath);

            var valuesObject = JObject.Parse(values);
            var testsObject = JObject.Parse(tests);

            //Обновляем значения
            UpdateTestValues(testsObject["tests"], valuesObject["values"]);

            //Преобразуем обратно в строку JSON
            string reportJson = JsonConvert.SerializeObject(testsObject,Formatting.Indented);

            //Записываем в файл
            Set(reportFilePath, reportJson);

            Console.WriteLine("Данные сохранены");


        }


    }

}
