using System;

namespace Library.Tasks
{
    public abstract class BaseTask
    {
        private int _duration;
        public Guid Id { get; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public int Complexity { get; set; }
        public string Status { get; set; }
        public int Sprint { get; set; }
        public abstract string Type { get; }
        public double Duration
        {
            get
            {
                return _duration * Priority * (Complexity == 1 ? 1 : Complexity * 0.1 + 1);
            }
        }

        public BaseTask(string Name, int Priority, int Complexity, string Status)
        {
            _duration = 2;
            Id = Guid.NewGuid();
            this.Name = Name;
            this.Priority = Priority;
            this.Complexity = Complexity;
            this.Status = Status;
        }

        /// <summary>
        /// Display method for overriding in heirs
        /// </summary>
        /// <returns></returns>
        public virtual string Display()
        {
            return $"BaseTask: {Name}, {Priority}, {Complexity}, {_duration}, {Status}";
        }
    }
}
