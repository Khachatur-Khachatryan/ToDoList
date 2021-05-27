using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ToDoList
{
    class Program
    {
        private static readonly string parseFormat = "dd.MM.yyyy";
        private static readonly Formatting serializeFormatting = Formatting.Indented;
        private static readonly CultureInfo cultureInfo = new CultureInfo("ru-RU");

        static void Main(string[] args)
        {
            bool exists = File.Exists(@"ToDo.json");
            if (exists)
            {
                ApplicationStart();
            }
            else
            {
                var toDo = new ToDo();
                var toDoList = toDo.ToDoList;

                Console.WriteLine("Список задач пуст. Добавьте задачу");
                Console.WriteLine();

                var toDoItem = new ToDoItem();

                toDoItem.Id = toDoList.Count + 1;

                Console.WriteLine("Введите дату начала выполнения задачи");
                try
                {
                    toDoItem.Start = DateTime.ParseExact(Console.ReadLine(), parseFormat, cultureInfo);
                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка. Введите дату начала выполнения задачи");
                    toDoItem.Start = DateTime.ParseExact(Console.ReadLine(), parseFormat, cultureInfo);
                }


                Console.WriteLine("Введите дату окончания выполнения задачи");
                try
                {
                    toDoItem.End = DateTime.ParseExact(Console.ReadLine(), parseFormat, cultureInfo);
                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка. Введите дату начала выполнения задачи");
                    toDoItem.End = DateTime.ParseExact(Console.ReadLine(), parseFormat, cultureInfo);
                }

                Console.WriteLine("Введите содержимое задачи");
                toDoItem.Content = Console.ReadLine();

                toDo.Post(toDoItem);
                SerializeToJson(toDo);

                Console.Clear();

                ApplicationStart();
            }
        }

        /// <summary>
        /// Метод для запуска основного приложения
        /// </summary>
        public static void ApplicationStart()
        {
            while (true)
            {
                var toDoJson = File.ReadAllText(@"ToDo.json");
                var toDo = JsonConvert.DeserializeObject<ToDo>(toDoJson);
                var toDoList = toDo.ToDoList;

                Console.WriteLine($"Количество задач: {toDo.Count}");

                ShowTasks(toDo);

                Console.WriteLine();

                ShowCommands();

                Console.WriteLine();

                var readLine = Console.ReadLine();
                Console.WriteLine();
                var readCommand = ReadCommand(readLine, toDo, toDoList);
                if (readCommand == false)
                {
                    Console.Clear();
                    continue;
                }

                Console.Clear();
            }
        }

        /// <summary>
        /// Метод для вывода уже существующих задач на экран
        /// </summary>
        /// <param name="toDo"></param>
        public static void ShowTasks(ToDo toDo)
        {
            Console.WriteLine("Список задач:");
            Console.WriteLine();

            foreach (var toDoItem in toDo)
                Console.WriteLine(toDoItem);
        }

        /// <summary>
        /// Метод для сериализации данных в JSON-формат и их записи в файл
        /// </summary>
        /// <param name="toDo"></param>
        public static void SerializeToJson(ToDo toDo)
        {
            using (var streamWriter = new StreamWriter(@"ToDo.json", false))
            {
                var serializedToDoList = JsonConvert.SerializeObject(toDo, serializeFormatting);
                streamWriter.WriteLine(serializedToDoList);
            }
        }

        /// <summary>
        /// Метод для вывода консольных комманд
        /// </summary>
        public static void ShowCommands()
        {
            Console.WriteLine
                (
                    "Добавить новую задачу: /post \n" +
                    "Удалить задачу: /delete \n" +
                    "Изменить содержимое задачи: /patch content \n" +
                    "Изменить дату окончания задачи: /patch data end \n" +
                    "Изменить дату начала задачи: /patch data start \n" +
                    "Выйти из программы: /close"
                );
        }

        /// <summary>
        /// Метод для ввода команды
        /// </summary>
        /// <param name="readLine"></param>
        /// <param name="toDo"></param>
        /// <param name="toDoList"></param>
        /// <returns></returns>
        public static bool ReadCommand(string readLine, ToDo toDo, List<ToDoItem> toDoList)
        {
            if (readLine == "/post")
            {
                var postToDoItem = new ToDoItem();

                postToDoItem.Id = 1 + toDoList.Count;

                Console.WriteLine("Введите дату начала выполнения задачи");
                try
                {
                    postToDoItem.Start = DateTime.ParseExact(Console.ReadLine(), parseFormat, cultureInfo);
                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка. Введите дату начала выполнения задачи");
                    postToDoItem.Start = DateTime.ParseExact(Console.ReadLine(), parseFormat, cultureInfo);
                }

                Console.WriteLine("Введите дату окончания выполнения задачи");
                try
                {
                    postToDoItem.End = DateTime.ParseExact(Console.ReadLine(), parseFormat, cultureInfo);
                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка. Введите дату начала выполнения задачи");
                    postToDoItem.End = DateTime.ParseExact(Console.ReadLine(), parseFormat, cultureInfo);
                }

                Console.WriteLine("Введите содержимое задачи");
                postToDoItem.Content = Console.ReadLine();

                toDo.Post(postToDoItem);
                SerializeToJson(toDo);

                return true;
            }
            else if (readLine == "/delete")
            {
                Console.WriteLine("Введите номер задачи, которую вы хотите удалить");

                var id = int.Parse(Console.ReadLine());
                toDo.Delete(id);

                SerializeToJson(toDo);

                return true;
            }
            else if (readLine == "/patch content")
            {
                Console.WriteLine("Введите номер задачи, которую вы хотите изменить");
                var id = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите изменённое содержимое");
                var content = Console.ReadLine();

                toDo.UpdateContent(id, content);

                SerializeToJson(toDo);

                return true;
            }
            else if (readLine == "/patch data start")
            {
                Console.WriteLine("Введите номер задачи, которую вы хотите изменить");
                var id = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите изменённую дату начала выполнения в формате dd.mm.yyyy. Например : 04.06.2005");
                var start = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", cultureInfo);

                toDo.UpdateStart(id, start);

                SerializeToJson(toDo);

                return true;
            }
            else if (readLine == "/patch data end")
            {
                Console.WriteLine("Введите номер задачи, которую вы хотите изменить");
                var id = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите изменённую дату конца выполнения в формате dd.mm.yyyy. Например : 04.06.2005");
                var end = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", cultureInfo);

                toDo.UpdateEnd(id, end);

                SerializeToJson(toDo);

                return true;
            }
            else if (readLine == "/close")
            {
                Environment.Exit(0);
            }

            return false;
        }
    }
}