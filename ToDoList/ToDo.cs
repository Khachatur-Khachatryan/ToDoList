using System;
using System.Collections;
using System.Collections.Generic;

namespace ToDoList
{
    /// <summary>
    /// Класс, реализующий работу со списком из ToDoItem
    /// </summary>
    public class ToDo : ICollection<ToDoItem>
    {
        /// <summary>
        /// Список задач
        /// </summary>
        public List<ToDoItem> ToDoList { get; } = new List<ToDoItem>();

        /// <summary>
        /// Количество задач
        /// </summary>
        public int Count
        {
            get
            {
                return ToDoList.Count;
            }
        }

        public bool IsReadOnly { get { return false; } }

        /// <summary>
        /// Метод для создания новой задачи
        /// </summary>
        /// <param name="toDoItem"></param>
        public void Post(ToDoItem toDoItem)
        {
            ToDoList.Add(toDoItem);
        }

        /// <summary>
        /// Метод для удаления задачи по ID
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            try
            {
                ToDoList.Remove(ToDoList[--id]);
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка. Введите номер задачи, которую вы хотите удалить");
            }

            for (int i = 1; i < ToDoList.Count; i++)
            {
                ToDoList[i].Id = ++i;
            }
        }

        /// <summary>
        /// Метод для изменения содержимого задачи по индексу
        /// </summary>
        /// <param name="id"></param>
        /// <param name="content"></param>
        public void UpdateContent(int id, string content)
        {
            ToDoList[--id].Content = content;
        }

        /// <summary>
        /// Метод для изменения даты конца выполнения задачи по индексу
        /// </summary>
        /// <param name="id"></param>
        /// <param name="end"></param>
        public void UpdateEnd(int id, DateTime end)
        {
            ToDoList[--id].End = end;
        }

        /// <summary>
        /// Метод для изменения даты начала выполнения задачи по индексу
        /// </summary>
        /// <param name="id"></param>
        /// <param name="start"></param>
        public void UpdateStart(int id, DateTime start)
        {
            ToDoList[--id].Start = start;
        }

        /// <summary>
        /// Копирование данных массива в список
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        public void CopyTo(ToDoItem[] array, int index)
        {
            ToDoList.CopyTo(array, index);
        }

        /// <summary>
        /// Добавление нового элемента в список
        /// </summary>
        /// <param name="item"></param>
        public void Add(ToDoItem item)
        {
            ((ICollection<ToDoItem>)ToDoList).Add(item);
        }

        /// <summary>
        /// Очистка списка
        /// </summary>
        public void Clear()
        {
            ((ICollection<ToDoItem>)ToDoList).Clear();
        }

        /// <summary>
        /// Проверка на присутствие элемента в списке
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(ToDoItem item)
        {
            return ((ICollection<ToDoItem>)ToDoList).Contains(item);
        }

        /// <summary>
        /// Удаление элемента из списка
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(ToDoItem item)
        {
            return ToDoList.Remove(item);
        }

        IEnumerator<ToDoItem> IEnumerable<ToDoItem>.GetEnumerator()
        {
            return ToDoList.GetEnumerator();
        }

        /// <summary>
        /// Внедрение поддержки цикла foreach в класс
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return ToDoList.GetEnumerator();
        }
    }
}