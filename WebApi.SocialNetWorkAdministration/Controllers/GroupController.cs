using AutoMapper;
using BL.Services.Interfaces;
using DAL.Dto;
using DAL.Request.Group;
using DAL.Response.Group;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.SocialNetWorkAdministration.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;
        private readonly ILogger<GroupPolicyController> _logger;

        public GroupController(IGroupService groupService, IMapper mapper, ILogger<GroupPolicyController> logger)
        {
            _groupService = groupService;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GroupResponse>))]
        public async Task<IActionResult> GetAsync()
        {
            _logger.LogInformation("Group/Get was requested.");
            var response = await _groupService.GetAsync();
            return Ok(_mapper.Map<IEnumerable<GroupResponse>>(response));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GroupResponse))]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Group/GetById was requested.");
            var response = await _groupService.GetByIdAsync(id);
            return Ok(_mapper.Map<GroupResponse>(response));
        }
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GroupResponse))]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Group/Delete was requested.");
            await _groupService.DeleteAsync(id);
            return NoContent();
        }
        [HttpPost("Update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GroupResponse))]
        public async Task<IActionResult> UpdateAsync(UpdateGroupRequest user, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Group/Update was requested.");
            var userDto = _mapper.Map<GroupDto>(user);
            var response = await _groupService.UpdateAsync(userDto);
            return Ok(_mapper.Map<GroupResponse>(response));
        }
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GroupResponse))]
        public async Task<IActionResult> CreateAsync(NewGroupRequest group, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Group/Create was requested.");
            var groupDto = _mapper.Map<GroupDto>(group);
            var response = await _groupService.CreateAsync(groupDto);
            return Ok(_mapper.Map<GroupResponse>(response));
        }
    }
}
