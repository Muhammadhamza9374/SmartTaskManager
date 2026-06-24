using System.Collections.Generic;

namespace SmartTaskManager
{
    public interface IDataHandler
    {
        void Save(List<TaskItem> tasks);
        List<TaskItem> Load();
    }
}
