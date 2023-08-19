using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext _dbContext;

        public SQLWalkRepository(NZWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
           return await _dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await _dbContext.Walks.AddAsync(walk);
            await _dbContext.SaveChangesAsync();

            return walk;
        }

        public Task<Walk?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Walk?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            throw new NotImplementedException();
        }
    }
}
