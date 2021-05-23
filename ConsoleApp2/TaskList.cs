using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;

namespace ToDoList
{
    class TaskList : ICollection<Task>
    {
        /* 
         * Спиок задач
         */
        public readonly List<Task> Tasks = new List<Task>();

        public int Count
        {
            get { return Tasks.Count; }
        }


        public bool IsReadOnly
        { 
            get { return true; }
        }

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

        public IEnumerator GetEnumerator()
        {
            foreach (var task in Tasks)
                yield return task;
        }

        public void Add(Task task)
        {
            Tasks.Add(task);
        }

        public void Clear()
        {
            Tasks.Clear();
        }

        public bool Contains(Task task)
        {
            return Tasks.Contains(task);
        }

        public void CopyTo(Task[] array, int arrayIndex)
        {
            Tasks.CopyTo(array, arrayIndex);
        }

        public bool Remove(Task task)
        {
            return Tasks.Remove(task);
        }

        IEnumerator<Task> IEnumerable<Task>.GetEnumerator()
        {
            return Tasks.GetEnumerator();
        }
    }
}
