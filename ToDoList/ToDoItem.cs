using System;

namespace ToDoList
{
    /// <summary>
    /// Класс, реализующий модель задачи
    /// </summary>
    public class ToDoItem
    {
        /// <summary>
        /// Порядковый номер задачи 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Содержимое задачи
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Дата начала выполнения задачи
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Дата конца выполнения задачи
        /// </summary>
        public DateTime End { get; set; }

        /// <summary>
        /// Переопределённый метод toString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Id}. {Content} \n" +
                $"   Дата начала выполнения: {Start} \n" +
                $"   Дата конца выполнения: {End}";
        }
    }
}
