namespace TodoCLI
{
    public class TodoItem
    {
        public string Description { get; set; }
        public bool IsDone { get; set; }

        public TodoItem(string description)
        {
            Description = description;
            IsDone = false;
        }

        public override string ToString()
        {
            return IsDone ? $"[x] {Description}" : $"[ ] {Description}";
        }
    }
}
