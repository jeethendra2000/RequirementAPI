using RequirementAPI.Models.Enums;

namespace RequirementAPI.DTOs
{
    public class RequirementResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Status Status { get; set; }
    }
}
