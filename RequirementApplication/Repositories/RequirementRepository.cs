using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RequirementAPI.Data;
using RequirementAPI.Models;
using RequirementAPI.Repositories.Interfaces;

namespace RequirementAPI.Repositories
{
    public class RequirementRepository : IRequirementRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<RequirementRepository> _logger;

        public RequirementRepository(AppDbContext context, ILogger<RequirementRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Requirement>> GetAllAsync()
        {
            _logger.LogInformation("Executing database query for fetching all requirements from DB");

            return await _context.Requirements
               .AsNoTracking()
               .OrderBy(r => r.Id)
               .ToListAsync();
        }

        public async Task<Requirement?> GetByIdAsync(int id)
        {
            _logger.LogDebug("Executing database query for requirement {RequirementId}.", id);
            _logger.LogInformation("Executing database query for fetching requirement {RequirementId}.", id);

            return await _context.Requirements
               .AsNoTracking()
               .Include(r => r.Tasks)
               .Include(r => r.Tags)
               .AsSplitQuery()
               .FirstOrDefaultAsync(r => r.Id == id);
        }
        public async Task<Requirement> AddAsync(Requirement requirement)
        {
            _logger.LogInformation("Executing database query to create a new requirement");
            _context.Requirements.Add(requirement);

            await _context.SaveChangesAsync();

            return requirement;
        }

    }
}
