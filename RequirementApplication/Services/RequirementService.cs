using RequirementAPI.DTOs;
using RequirementAPI.Models;
using RequirementAPI.Repositories.Interfaces;
using RequirementAPI.Services.Interfaces;

namespace RequirementAPI.Services
{
    public class RequirementService : IRequirementService
    {
        private readonly IRequirementRepository _repository;
        private readonly ILogger<RequirementService> _logger;

        public RequirementService(IRequirementRepository repository, ILogger<RequirementService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<List<RequirementResponseDto>> GetAllAsync()
        {
            _logger.LogDebug("Fetching all requirements from repository.");
            var requirements = await _repository.GetAllAsync();

            _logger.LogInformation("Mapped {Count} requirements to response DTOs.", requirements.Count);
            return requirements.Select(MapToDto).ToList();
        }

        public async Task<RequirementResponseDto?> GetByIdAsync(int id)
        {
            _logger.LogDebug("Fetching requirement {RequirementId} from repository.", id);
            var requirement = await _repository.GetByIdAsync(id);

            return requirement is null ? null : MapToDto(requirement);
        }

        public async Task<RequirementResponseDto> CreateAsync(CreateRequirementDto dto)
        {
            _logger.LogInformation("Creating a new requirement.");
            var requirement = new Requirement
            {
                Title = dto.Title.Trim(),
                Description = dto.Description.Trim(),
            };

            var created = await _repository.AddAsync(requirement);

            _logger.LogInformation("Requirement {RequirementId} created successfully.", created.Id);

            return MapToDto(created);
        }

        private static RequirementResponseDto MapToDto(Requirement requirement)
        {
            return new RequirementResponseDto
            {
                Id = requirement.Id,
                Title = requirement.Title,
                Description = requirement.Description,
                Status = requirement.Status,

                Tasks = requirement.Tasks.Select(t => new TaskResponseDto
                {
                    Id = t.Id,
                    Title = t.Title
                }).ToList(),

                Tags = requirement.Tags.Select(t => new TagResponseDto
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToList()
            };
        }
    }
}