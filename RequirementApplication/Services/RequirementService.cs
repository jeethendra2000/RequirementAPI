using RequirementAPI.DTOs;
using RequirementAPI.Models;
using RequirementAPI.Repositories.Interfaces;
using RequirementAPI.Services.Interfaces;

namespace RequirementAPI.Services
{
    public class RequirementService : IRequirementService
    {
        private readonly IRequirementRepository _repository;

        public RequirementService(IRequirementRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<RequirementResponseDto>> GetAllAsync()
        {
            var requirements = await _repository.GetAllAsync();

            return requirements.Select(r => new RequirementResponseDto
            {
                Id = r.Id,
                Title = r.Title,
                Description = r.Description,
            }).ToList();
        }

        public async Task<RequirementResponseDto?> GetByIdAsync(int id)
        {
            var requirement = await _repository.GetByIdAsync(id);

            if (requirement is null)
                return null;

            return new RequirementResponseDto
            {
                Id = requirement.Id,
                Title = requirement.Title,
                Description = requirement.Description,
            };
        }

        public async Task<RequirementResponseDto> CreateAsync(CreateRequirementDto dto)
        {
            var requirement = new Requirement
            {
                Title = dto.Title.Trim(),
                Description = dto.Description?.Trim(),
            };

            var created = await _repository.AddAsync(requirement);

            return new RequirementResponseDto
            {
                Id = created.Id,
                Title = created.Title,
                Description = created.Description,
            };
        }
    }
}