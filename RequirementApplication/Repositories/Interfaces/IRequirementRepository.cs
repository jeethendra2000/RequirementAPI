using RequirementAPI.DTOs;
using RequirementAPI.Models;

namespace RequirementAPI.Repositories.Interfaces
{
    public interface IRequirementRepository
    {
        Task<List<Requirement>> GetAllAsync();
        Task<Requirement?> GetByIdAsync(int id);
        Task<Requirement> AddAsync(Requirement requirement);
        Task<List<RequirementHistoryDto>> GetRequirementHistoryAsync(int id);
    }
}
