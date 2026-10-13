using RequirementAPI.DTOs;

namespace RequirementAPI.Services.Interfaces
{
    public interface IRequirementService
    {
        Task<List<RequirementResponseDto>> GetAllAsync();

        Task<RequirementResponseDto?> GetByIdAsync(int id);

        Task<RequirementResponseDto> CreateAsync(CreateRequirementDto dto);

    }
}
