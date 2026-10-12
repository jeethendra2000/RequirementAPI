using System.ComponentModel.DataAnnotations;

namespace RequirementAPI.DTOs
{
    public class CreateRequirementDto
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [StringLength(200)]
        public string Description { get; set; } = string.Empty;
    }
}
