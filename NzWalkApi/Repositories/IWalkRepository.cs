using System;
using NzWalkApi.Models.Domain;

namespace NzWalkApi.Repositories
{
	public interface IWalkRepository
	{
		Task<Walk> CreateAsync(Walk walk);

		Task<List<Walk>> GetAllWalkAsync();

		Task<Walk> GetWalkById(Guid id);

		Task<Walk> UpdateWalk(Guid id, Walk walk);

		Task<Walk> DeleteWalk(Guid id);
	}
}

