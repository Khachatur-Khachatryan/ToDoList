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

        //public string Status
        //{
        //    get
        //    {
        //        if (DateTime.Now > End)
        //        {
        //            return "Выполнено";
        //        }
        //        else if (DateTime.Now > Start && DateTime.Now < End)
        //        {
        //            return "Выполняется";
        //        }

        //        return "Не выполнено";
        //    }
        //}
        public override string ToString()
        {
            return $"{Id}. {Content} \n" +
                $"   Дата начала выполнения: {Start} \n" +
                $"   Дата конца выполнения: {End}";
        }
    }    
}
