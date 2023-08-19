using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IWalkRepository _walkRespository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            _mapper = mapper;
            _walkRespository = walkRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walks = await _walkRespository.GetAllAsync();

            return Ok(_mapper.Map<List<WalkDto>>(walks));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walk = await _walkRespository.GetByIdAsync(id);

            if (walk == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WalkDto>(walk));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto walkRequestDto)
        {
            var walk = _mapper.Map<Walk>(walkRequestDto);

            await _walkRespository.CreateAsync(walk);

            return Ok(_mapper.Map<WalkDto>(walk));
                        
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            
            var walk = _mapper.Map<Walk>(updateWalkRequestDto);

            walk = await _walkRespository.UpdateAsync(id, walk);

            if (walk == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WalkDto>(walk));
           
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walk = await _walkRespository.DeleteAsync(id);

            if (walk == null)
            {
                return NotFound();
            }

            //Return the deleted region back
            return Ok(_mapper.Map<WalkDto>(walk));
        }
    }
}
