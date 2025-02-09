using System;
using AutoMapper;
using NzWalkApi.Models.Domain;
using NzWalkApi.Models.DTO;

namespace NzWalkApi.Mapping
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap <Region , RegionDto>().ReverseMap();
			CreateMap<AddRegionDto, Region>().ReverseMap();


			CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
			CreateMap<Walk, WalkDto>().ReverseMap();

			CreateMap<Difficulty, DifficultyDto>().ReverseMap();

			//CreateMap< WalkDto, Walk>().ReverseMap();
        }

	}
}

