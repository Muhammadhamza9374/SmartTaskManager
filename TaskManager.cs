using System.Collections.Generic;
using System.Linq;

namespace SmartTaskManager
{
    public class TaskManager
    {
        private List<TaskItem> tasks = new List<TaskItem>();

        public void AddTask(TaskItem task)
        {
            tasks.Add(task);
        }

        public List<TaskItem> GetAllTasks()
        {
            return tasks;
        }

        public void DeleteTask(int id)
        {
            tasks.RemoveAll(t => t.TaskID == id);
        }

        public void MarkComplete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.TaskID == id);

            if (task != null)
                task.IsCompleted = true;
        }
    }
}
