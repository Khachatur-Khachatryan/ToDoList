using System;
using Newtonsoft.Json;
using System.IO;
using System.Globalization;
using System.Collections.Generic;

namespace ToDoList
{
    class Program
    {
        private static readonly string parseFormat = "dd.MM.yyyy";
        private static readonly Formatting serializeFormatting = Formatting.Indented;
        private static readonly CultureInfo cultureInfo = new CultureInfo("ru-RU");
        static void Main(string[] args)
        {
 
            if (File.Exists(@"TaskList.json"))
            {
                while (true)
                {
                    var taskListJson = File.ReadAllText(@"TaskList.json");
                    var taskList = JsonConvert.DeserializeObject<TaskList>(taskListJson);
                    var tasks = taskList.Tasks;

                    ShowTasks(tasks);

                    Console.WriteLine();

                    ShowCommands();

                    Console.WriteLine();

                    var readLine = Console.ReadLine();
                    Console.WriteLine();
                    if (readLine == "/post")
                    {
                        var task = new Task();

                        task.Id = 1 + tasks.Count;

                        Console.WriteLine("Введите дату начала выполнения задачи");
                        try
                        {
                            task.Start = DateTime.ParseExact(Console.ReadLine(), parseFormat, cultureInfo);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Ошибка. Введите дату начала выполнения задачи");
                            task.Start = DateTime.ParseExact(Console.ReadLine(), parseFormat, cultureInfo);
                        }


                        Console.WriteLine("Введите дату окончания выполнения задачи");
                        try
                        {
                            task.End = DateTime.ParseExact(Console.ReadLine(), parseFormat, cultureInfo);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Ошибка. Введите дату начала выполнения задачи");
                            task.Start = DateTime.ParseExact(Console.ReadLine(), parseFormat, cultureInfo);
                        }

                        Console.WriteLine("Введите содержимое задачи");
                        task.Content = Console.ReadLine();

                        taskList.Post(task);
                        SerializeToJson(taskList);
                    }
                    else if (readLine == "/delete")
                    {
                        Console.WriteLine("Введите номер задачи, которую вы хотите удалить");
                        var id = int.Parse(Console.ReadLine());
                        taskList.Delete(id);
                        SerializeToJson(taskList);
                        break;
                    }
                    else if (readLine == "/patch content")
                    {
                        Console.WriteLine("Введите номер задачи, которую вы хотите изменить");
                        var id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите изменённое содержимое");
                        var content = Console.ReadLine();
                        taskList.UpdateContent(id, content);
                        SerializeToJson(taskList);
                    }
                    else if (readLine == "/patch data start")
                    {
                        Console.WriteLine("Введите номер задачи, которую вы хотите изменить");
                        var id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите изменённую дату начала выполнения в формате dd.mm.yyyy. Например : 04.06.2005");
                        var start = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", cultureInfo);
                        taskList.UpdateStart(id, start);
                        SerializeToJson(taskList);
                    }
                    else if (readLine == "/patch data end")
                    {
                        Console.WriteLine("Введите номер задачи, которую вы хотите изменить");
                        var id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите изменённую дату конца выполнения в формате dd.mm.yyyy. Например : 04.06.2005");
                        var end = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", cultureInfo);
                        taskList.UpdateEnd(id, end);
                        SerializeToJson(taskList);
                    }
                    else if (readLine == "/close")
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        continue;
                    }


                    Console.Clear();
                }
            }
            else
            {
                var taskList = new TaskList();
                var tasks = taskList.Tasks;
                Console.WriteLine("Список задач пуст. Добавьте задачу");
                Console.WriteLine();

                var task = new Task();

                task.Id = tasks.Count + 1;

                Console.WriteLine("Введите дату начала выполнения задачи");
                try
                {
                    task.Start = DateTime.ParseExact(Console.ReadLine(), parseFormat, cultureInfo);
                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка. Введите дату начала выполнения задачи");
                    task.Start = DateTime.ParseExact(Console.ReadLine(), parseFormat, cultureInfo);
                }


                Console.WriteLine("Введите дату окончания выполнения задачи");
                try
                {
                    task.End = DateTime.ParseExact(Console.ReadLine(), parseFormat, cultureInfo);
                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка. Введите дату начала выполнения задачи");
                    task.Start = DateTime.ParseExact(Console.ReadLine(), parseFormat, cultureInfo);
                }

                Console.WriteLine("Введите содержимое задачи");
                task.Content = Console.ReadLine();

                taskList.Post(task);
                SerializeToJson(taskList);

                Console.Clear();

                while (true)
                {
                    var taskListJson = File.ReadAllText(@"TaskList.json");
                    taskList = JsonConvert.DeserializeObject<TaskList>(taskListJson);
                    tasks = taskList.Tasks;

                    ShowTasks(tasks);

                    Console.WriteLine();

                    ShowCommands();

                    var readLine = Console.ReadLine();
                    if (readLine == "/post")
                    {
                        var postTask = new Task();

                        postTask.Id = 1 + tasks.Count;

                        Console.WriteLine("Введите дату начала выполнения задачи");
                        try
                        {
                            postTask.Start = DateTime.ParseExact(Console.ReadLine(), parseFormat, cultureInfo);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Ошибка. Введите дату начала выполнения задачи");
                            postTask.Start = DateTime.ParseExact(Console.ReadLine(), parseFormat, cultureInfo);
                        }


                        Console.WriteLine("Введите дату окончания выполнения задачи");
                        try
                        {
                            postTask.End = DateTime.ParseExact(Console.ReadLine(), parseFormat, cultureInfo);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Ошибка. Введите дату начала выполнения задачи");
                            postTask.Start = DateTime.ParseExact(Console.ReadLine(), parseFormat, cultureInfo);
                        }

                        Console.WriteLine("Введите содержимое задачи");
                        postTask.Content = Console.ReadLine();

                        taskList.Post(postTask);
                        SerializeToJson(taskList);
                    }
                    else if (readLine == "/delete")
                    {
                        Console.WriteLine("Введите номер задачи, которую вы хотите удалить");
                        var id = int.Parse(Console.ReadLine());
                        taskList.Delete(id);
                        SerializeToJson(taskList);
                    }
                    else if (readLine == "/patch content")
                    {
                        Console.WriteLine("Введите номер задачи, которую вы хотите изменить");
                        var id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите изменённое содержимое");
                        var content = Console.ReadLine();
                        taskList.UpdateContent(id, content);
                        SerializeToJson(taskList);
                    }
                    else if (readLine == "/patch data start")
                    {
                        Console.WriteLine("Введите номер задачи, которую вы хотите изменить");
                        var id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите изменённую дату начала выполнения в формате dd.mm.yyyy. Например : 04.06.2005");
                        var start = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", cultureInfo);
                        taskList.UpdateStart(id, start);
                        SerializeToJson(taskList);
                    }
                    else if (readLine == "/patch data end")
                    {
                        Console.WriteLine("Введите номер задачи, которую вы хотите изменить");
                        var id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите изменённую дату конца выполнения в формате dd.mm.yyyy. Например : 04.06.2005");
                        var end = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", cultureInfo);
                        taskList.UpdateEnd(id, end);
                        SerializeToJson(taskList);
                    }
                    else if (readLine == "/close")
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        continue;
                    }

                    Console.Clear();
                }
            }
        }
        public static void SerializeToJson(TaskList taskList)
        {
            using (var streamWriter = new StreamWriter(@"TaskList.json", false))
            {
                var serializedTaskList = JsonConvert.SerializeObject(taskList, serializeFormatting);
                streamWriter.WriteLine(serializedTaskList);
            }
        }
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
        public static void ShowTasks(List<Task> tasks)
        {
            Console.WriteLine("Список задач:");
            Console.WriteLine();

            foreach (var task in tasks) Console.WriteLine(task.ToString());
        }
    }
}
