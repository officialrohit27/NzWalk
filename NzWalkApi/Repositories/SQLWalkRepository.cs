using System;
using Microsoft.EntityFrameworkCore;
using NzWalkApi.Data;
using NzWalkApi.Models.Domain;
using NzWalkApi.Models.DTO;

namespace NzWalkApi.Repositories
{
	public class SQLWalkRepository : IWalkRepository
	{
        private readonly NZWalksDBContext dBContext;

        public SQLWalkRepository(NZWalksDBContext _dBContext)
		{
            this.dBContext = _dBContext;
		}

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dBContext.Walks.AddAsync(walk);
            await dBContext.SaveChangesAsync();

            return walk;
        }

        public async Task<Walk> DeleteWalk(Guid id)
        {
            var existingWalks =await dBContext.Walks.FirstOrDefaultAsync(x=> x.Id == id);

            dBContext.Walks.Remove(existingWalks);

            dBContext.SaveChangesAsync();

            return existingWalks;
        }

        public async Task<List<Walk>> GetAllWalkAsync()
        {
            return await dBContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walk> GetWalkById(Guid id)
        {
            var existingWalks = await dBContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);
            return existingWalks;
        }

        public async Task<Walk> UpdateWalk(Guid id, Walk walk)
        {
            var existingWalks = await dBContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if(existingWalks == null)
            {
                return null;
            }

            existingWalks.Name = walk.Name;
            existingWalks.Description = walk.Description;
            existingWalks.WalkImageUrl = walk.WalkImageUrl;
            existingWalks.LengthInKm = walk.LengthInKm;
            existingWalks.regionId = walk.regionId;
            existingWalks.DifficultyId = walk.DifficultyId;

            await dBContext.SaveChangesAsync();

            return existingWalks;
        }
    }
}

