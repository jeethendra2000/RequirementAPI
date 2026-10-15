namespace RequirementAPI.DTOs
{
    public class RequirementHistoryDto
    {
        public int Id { get; set; }

        public required string Title { get; set; }

        public string Description { get; set; } = string.Empty;

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }
    }
}
