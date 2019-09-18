using System.Collections.Generic;

namespace Library.Tasks
{
    public static class TaskRepository
    {
        private static List<BaseTask> _tasks = new List<BaseTask>();

        /// <summary>
        /// Return all tasks
        /// </summary>
        public static List<BaseTask> Tasks
        {
            get
            {
                return _tasks;
            }
        }

        /// <summary>
        /// Add task to repository
        /// </summary>
        /// <param name="task">task</param>
        internal static void AddTask(BaseTask task)
        {
            if (task != null)
                _tasks.Add(task);
        }

        /// <summary>
        /// Remove task from repository
        /// </summary>
        /// <param name="task">task</param>
        internal static void RemoveTask(BaseTask task)
        {
            if (task != null)
                _tasks.Remove(task);
        }
    }
}
