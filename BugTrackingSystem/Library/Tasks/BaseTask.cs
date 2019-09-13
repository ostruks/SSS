namespace Library.Tasks
{
    public abstract class BaseTask
    {
        private int _duration;
        protected string _name;
        public int Priority { get; set; }
        public int Complexity { get; set; }
        public double Duration { get {
                switch (Complexity)
                {
                    case 1:
                        return _duration * Priority;
                    case 2:
                        return _duration * 1.2 * Priority;
                    case 3:
                        return _duration * 1.3 * Priority;
                    case 4:
                        return _duration * 1.4 * Priority;
                    case 5:
                        return _duration * 1.5 * Priority;
                    default:
                        return _duration;
                }
            }
            private set{}
        }

        public BaseTask(string Name, int Priority, int Complexity)
        {
            _duration = 6;
            _name = Name;
            this.Priority = Priority;
            this.Complexity = Complexity;
        }
    }
}
