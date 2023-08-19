using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

        public WalksController(IMapper mapper , IWalkRepository walkRepository)
        {
            _mapper = mapper;
            _walkRespository = walkRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto walkRequestDto)
        {
           var walk = _mapper.Map<Walk>(walkRequestDto);

            await _walkRespository.CreateAsync(walk);

            return Ok(_mapper.Map<WalkDto>(walk));
        }
    }
}
