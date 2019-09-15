﻿using System;

namespace Library.Tasks
{
    public abstract class BaseTask
    {
        private int _duration;
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public int Complexity { get; set; }
        public string Status { get; set; }
        public double Duration {
            get {
                return _duration * Priority * (Complexity == 1 ? 1 : Complexity * 0.1 + 1);
            }
            private set{}
        }

        public BaseTask(string Name, int Priority, int Complexity, string Status)
        {
            _duration = 2;
            this.Name = Name;
            this.Priority = Priority;
            this.Complexity = Complexity;
            this.Status = Status;
        }

        public override string ToString()
        {
            return $"Task: {Name}, {Priority}, {Complexity}, {_duration}, {Status}";
        }
    }
}
