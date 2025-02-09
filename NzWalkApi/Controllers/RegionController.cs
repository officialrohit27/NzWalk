using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NzWalkApi.Models.Domain;
using NzWalkApi.Data;
using NzWalkApi.Models.DTO;
using Microsoft.EntityFrameworkCore;
using NzWalkApi.Repositories;
using AutoMapper;
using NzWalkApi.CustomActionFilter;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NzWalkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly NZWalksDBContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionController(NZWalksDBContext _dBContext, IRegionRepository _regionRepository, IMapper _mapper)
        {
            this.dbContext = _dBContext;
            this.regionRepository = _regionRepository;
            this.mapper = _mapper;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            //var regions = await dbContext.Regions.ToListAsync();

            var regions = await regionRepository.GetAllAsync();

            //var regions = new List<Region>
            //{
            //    new Region
            //    {
            //        Id = Guid.NewGuid(),
            //        Name =  "Auckland Region",
            //        Code = "AKL",
            //        RegionImageURL = ""

            //    },
            //}

            //var regionDto = new List<RegionDto>();

            //foreach (var items in regions)
            //{
            //    regionDto.Add(new RegionDto()
            //    {
            //        Id = items.Id,
            //        Name = items.Name,
            //        Code = items.Code,
            //        RegionImageURL = items.RegionImageURL
            //    });
            //}

            //return Ok(regionDto);

            return Ok(mapper.Map<List<RegionDto>>(regions));

        }


        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {

            //var regionDomain = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            var regionDomain =await regionRepository.GetById(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            //var regionDto = new RegionDto
            //{
            //    Id = regionDomain.Id,
            //    Name = regionDomain.Name,
            //    Code = regionDomain.Code,
            //    RegionImageURL = regionDomain.RegionImageURL
            //};

            //return Ok(regionDto);

            return Ok(mapper.Map<RegionDto>(regionDomain));

        }

        [HttpPost]
        [ValidateModelAttributes]
        public async Task<IActionResult> Create([FromBody] AddRegionDto addRegionDto)
        {
            //var regionDomainModel = new Region
            //{
            //    Name = addRegionDto.Name,
            //    Code = addRegionDto.Code,
            //    RegionImageURL = addRegionDto.RegionImageURL
            //};
            //if (ModelState.IsValid)
            //{
                var regionDomainModel = mapper.Map<Region>(addRegionDto);

                await regionRepository.Create(regionDomainModel);

                //var regionDto = new RegionDto
                //{
                //    Id = regionDomainModel.Id,
                //    Name = regionDomainModel.Name,
                //    Code = regionDomainModel.Code,
                //    RegionImageURL = regionDomainModel.RegionImageURL
                //};

                var regionDto = mapper.Map<RegionDto>(regionDomainModel);
                return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
            //}
            //else
            //{
            //    return BadRequest(ModelState);
            //}
            

            
        }


        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModelAttributes]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] AddRegionDto regionDto)
        {


            //var regionDomainModel = new Region
            //{
            //    Name = regionDto.Name,
            //    Code = regionDto.Code,
            //    RegionImageURL = regionDto.RegionImageURL
            //};
                var regionDomainModel = mapper.Map<Region>(regionDto);

                regionDomainModel = await regionRepository.Update(id, regionDomainModel);

                if (regionDomainModel == null)
                {
                    return NotFound();
                }

                //var updatedRegionDto = new RegionDto
                //{
                //    Id = regionDomainModel.Id,
                //    Name = regionDomainModel.Name,
                //    Code = regionDomainModel.Code,
                //    RegionImageURL = regionDomainModel.RegionImageURL
                //};

                var updatedRegionDto = mapper.Map<RegionDto>(regionDomainModel);
                return Ok(updatedRegionDto);
            
            
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {

            //var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            //dbContext.Regions.Remove(existingRegion);
            //dbContext.SaveChangesAsync();

            var regionDomainModel = await regionRepository.Delete(id);

            return Ok();
        }
    }


}

