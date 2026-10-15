using RequirementAPI.DTOs;
using RequirementAPI.Models;
using RequirementAPI.Repositories.Interfaces;

namespace RequirementAPI.Repositories
{
    public class InMemoryRequirementRepository : IRequirementRepository
    {
        private readonly List<Requirement> _requirements = [];
        private int _nextId = 1;

        public Task<List<Requirement>> GetAllAsync()
        {
            var requirements = _requirements
            .Select(r => new Requirement
            {
                Id = r.Id,
                Title = r.Title,
                Description = r.Description
            })
            .ToList();

            return Task.FromResult(requirements);
        }

        public Task<Requirement?> GetByIdAsync(int id)
        {
            var requirement = _requirements.FirstOrDefault(r => r.Id == id);

            if (requirement is null)
            {
                return Task.FromResult<Requirement?>(null);
            }

            var copy = new Requirement
            {
                Id = requirement.Id,
                Title = requirement.Title,
                Description = requirement.Description
            };

            return Task.FromResult<Requirement?>(copy);
        }
        public Task<Requirement> AddAsync(Requirement requirement)
        {
            var newRequirement = new Requirement
            {
                Id = _nextId++,
                Title = requirement.Title,
                Description = requirement.Description
            };

            _requirements.Add(newRequirement);

            return Task.FromResult(new Requirement
            {
                Id = newRequirement.Id,
                Title = newRequirement.Title,
                Description = newRequirement.Description
            });
        }

        public Task<List<RequirementHistoryDto>> GetRequirementHistoryAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
