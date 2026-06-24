using System;

namespace SmartTaskManager
{
    public class TaskItem
    {
        public int TaskID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }

        public virtual string GetTaskDetails()
        {
            return $"{Title} - Due: {DueDate.ToShortDateString()}";
        }
    }
}
