using System;
using System.Collections;
using System.Collections.Generic;

namespace ToDoList
{
    class TaskList : ICollection<Task>
    {
        /* 
         * Список задач
         */
        public List<Task> Tasks { get; } = new List<Task>();

        /*
         * Количество задач
         */
        public int Count
        {
            get
            {
                return Tasks.Count;
            }
        }

        public bool IsReadOnly { get { return false; } }

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

            for (int i = 1; i < Tasks.Count; i++)
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

        public void CopyTo(Task[] array, int index)
        {
            Tasks.CopyTo(array, index);
        }

        public void Add(Task item)
        {
            ((ICollection<Task>)Tasks).Add(item);
        }

        public void Clear()
        {
            ((ICollection<Task>)Tasks).Clear();
        }

        public bool Contains(Task item)
        {
            return ((ICollection<Task>)Tasks).Contains(item);
        }

        public bool Remove(Task item)
        {
            return Tasks.Remove(item);
        }

        IEnumerator<Task> IEnumerable<Task>.GetEnumerator()
        {
            return Tasks.GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return Tasks.GetEnumerator();
        }
    }
}