using System;

namespace ToDoList
{
    public class Task
    {
        /* 
         * Порядковый номер задачи 
         */
        public int Id { get; set; }

        /*
         * Содержимое задачи
         */
        public string Content { get; set; }

        /*
         * Дата начала выполнения задачи
         */
        public DateTime Start { get; set; }

        /*
         * Дата конца выполнения задачи
         */
        public DateTime End { get; set; }
        public override string ToString()
        {
            return $"{Id}. {Content} \n" +
                $"   Дата начала выполнения: {Start} \n" +
                $"   Дата конца выполнения: {End}";
        }
    }    
}
