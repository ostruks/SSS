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

        internal static void AddTask(BaseTask task)
        {
            if (task != null)
                _tasks.Add(task);
        }

        internal static void RemoveTask(BaseTask task)
        {
            if (task != null)
                _tasks.Remove(task);
        }
    }
}
