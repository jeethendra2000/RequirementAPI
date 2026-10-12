namespace RequirementAPI.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Requirement> Requirements { get; set; } = [];
    }
}
