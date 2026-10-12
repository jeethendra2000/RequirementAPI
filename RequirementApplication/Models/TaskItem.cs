namespace RequirementAPI.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int RequirementId { get; set; }
        public Requirement Requirement { get; set; } = null!;
    }
}
