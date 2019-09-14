using System.Collections.Generic;

namespace Library.Tasks
{
    public static class TaskRepository
    {
        private static List<BaseTask> _tasks = new List<BaseTask>();
        public static List<BaseTask> Tasks
        {
            get
            {
                return _tasks;
            }
        }

        public static void AddTask(BaseTask task)
        {
            _tasks.Add(task);
        }

        public static void RemoveTask(BaseTask task)
        {
            _tasks.Remove(task);
        }
    }
}
