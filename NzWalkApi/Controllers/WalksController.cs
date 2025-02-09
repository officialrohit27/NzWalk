using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NzWalkApi.CustomActionFilter;
using NzWalkApi.Data;
using NzWalkApi.Models.Domain;
using NzWalkApi.Models.DTO;
using NzWalkApi.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NzWalkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly NZWalksDBContext dBContext;
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(NZWalksDBContext _dBContext, IMapper _mapper, IWalkRepository _walkRepository)
        {
            this.dBContext = _dBContext;
            this.mapper = _mapper;
            this.walkRepository = _walkRepository;


        }
        //Create Walk
        // Post: /api/walks
        [HttpPost]
        //Route[""]
        public async Task<IActionResult> CreateAsync([FromBody] AddWalkRequestDto addWalkRequestDto)
        {

            //walkRepository.CreateAsync()
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

            await walkRepository.CreateAsync(walkDomainModel);

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalkAsync()
        {
            var walkDomainModel = await walkRepository.GetAllWalkAsync();

            return Ok(mapper.Map<List<WalkDto>>(walkDomainModel));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetWalkById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetWalkById(id);

            if (walkDomainModel == null)
            {
                return Ok(null);
            }

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModelAttributes]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid id, AddWalkRequestDto addWalkRequestDto)
        {

                var updatedWalkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

                updatedWalkDomainModel = await walkRepository.UpdateWalk(id, updatedWalkDomainModel);

                if (updatedWalkDomainModel == null)
                {
                    return null;
                }

                var walkDto = mapper.Map<WalkDto>(updatedWalkDomainModel);

                return Ok(walkDto);
            
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteWalk([FromRoute] Guid id)
        {

            //var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            //dbContext.Regions.Remove(existingRegion);
            //dbContext.SaveChangesAsync();

            var walkDomainModel = await walkRepository.DeleteWalk(id);

            return Ok();
        }

    }
}

