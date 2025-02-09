using System;
using NzWalkApi.Models.Domain;
using NzWalkApi.Data;
using Microsoft.EntityFrameworkCore;

namespace NzWalkApi.Repositories
{
	public class SQLRegionRepository : IRegionRepository
	{
		private readonly NZWalksDBContext dbContext;

		public SQLRegionRepository(NZWalksDBContext _dbContext)
		{
			this.dbContext = _dbContext;
		}

        public async Task<Region> Create(Region region)
        {
			await dbContext.Regions.AddAsync(region);
			await dbContext.SaveChangesAsync();
			return region;
            
        }

        public async Task<Region> Delete(Guid id)
        {
			var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

			dbContext.Regions.Remove(existingRegion);
			dbContext.SaveChangesAsync();

			return existingRegion;


        }

        public async Task<List<Region>> GetAllAsync()
		{

			return await dbContext.Regions.ToListAsync();
			//throw new NotImplementedException();
		}

        public async Task<Region?> GetById(Guid id)
        {
			return await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> Update(Guid id, Region region)
        {
			var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

			if (existingRegion == null)
			{
				return null;
			}

			existingRegion.Name = region.Name;
			existingRegion.Code = region.Code;
			existingRegion.RegionImageURL = region.RegionImageURL;

			await dbContext.SaveChangesAsync();

			return existingRegion;
            
        }


    }
}

