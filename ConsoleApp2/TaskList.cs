using System;
using System.Globalization;
using System.Collections.Generic;

namespace ToDoList
{
    class TaskList
    {
        private readonly CultureInfo cultureInfo = new CultureInfo("ru-RU");

        /*
         * Формат преобразования строки в дату (DateTime)
         */
        private const string parseFormat = "dd.MM.yyyy";

        /* 
         * Спиок задач
         */
        public readonly List<Task> Tasks = new List<Task>();
        
        /*
         * Метод для создания новой задачи
         */
        public void Post(Task task)
        {
            Tasks.Add(task);
        }

        /*
         * Метод для удаления задачи по ID
         */
        public void Delete(int id)
        {
            try
            {
                Tasks.Remove(Tasks[--id]);
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка. Введите номер задачи, которую вы хотите удалить");
            }

            for(int i = 1; i < Tasks.Count; i++)
            {
                Tasks[i].Id = ++i;
            }
        }

        /*
         * Метод для изменения содержимого задачи по индексу
         */
        public void UpdateContent(int id, string content)
        {
            Tasks[--id].Content = content;
        }

        /*
         * Метод для изменения даты конца выполнения задачи по индексу
         */
        public void UpdateEnd(int id, DateTime end)
        {
            Tasks[--id].End = end;
        }

        /*
         * Метод для изменения даты начала выполнения задачи по индексу
         */
        public void UpdateStart(int id, DateTime start)
        {
            Tasks[--id].Start = start;
        }
        
    }
}
