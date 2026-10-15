using Azure;
using RequirementAPI.Models.Enums;

namespace RequirementAPI.Models
{
    public class Requirement
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Status Status { get; set; } = Status.New;
        public ICollection<TaskItem> Tasks { get; set; } = [];
        public ICollection<Tag> Tags { get; set; } = [];
    }
}
