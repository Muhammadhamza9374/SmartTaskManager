namespace SmartTaskManager
{
    public class PriorityTask : TaskItem
    {
        public string PriorityLevel { get; set; }

        public override string GetTaskDetails()
        {
            return base.GetTaskDetails() + $" | Priority: {PriorityLevel}";
        }
    }
}
