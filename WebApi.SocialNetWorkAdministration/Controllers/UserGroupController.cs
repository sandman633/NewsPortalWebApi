using AutoMapper;
using BL.Services.Interfaces;
using DAL.Dto;
using DAL.Request.UserGroup;
using DAL.Response.UserGroup;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NewsPortal.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class UserGroupController : ControllerBase
    {
        private readonly IUserGroupService _userGroupService;
        private readonly IMapper _mapper;
        private readonly ILogger<UserGroupController> _logger;
        public UserGroupController(IUserGroupService userGroupService, IMapper mapper, ILogger<UserGroupController> logger)
        {
            _userGroupService = userGroupService;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserGroupResponse>))]
        public async Task<IActionResult> GetAsync()
        {
            _logger.LogInformation("Users/Get was requested.");
            var response = await _userGroupService.GetAsync();
            return Ok(_mapper.Map<IEnumerable<UserGroupResponse>>(response));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserGroupResponse))]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Users/GetById was requested.");
            var response = await _userGroupService.GetByIdAsync(id);
            return Ok(_mapper.Map<UserGroupResponse>(response));
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Users/Delete was requested.");
            await _userGroupService.DeleteAsync(id);
            return NoContent();
        }
        [HttpPost("Update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserGroupResponse))]
        public async Task<IActionResult> UpdateAsync(UpdateUserGroupRequest userGroup, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Users/Update was requested.");
            var userGroupDto = _mapper.Map<UserGroupDto>(userGroup);
            var response = await _userGroupService.UpdateAsync(userGroupDto);
            return Ok(_mapper.Map<UserGroupResponse>(response));
        }
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserGroupResponse))]
        public async Task<IActionResult> CreateAsync(NewUserGroupRequest userGroup, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Users/Create was requested.");
            var userGroupDto = _mapper.Map<UserGroupDto>(userGroup);
            var response = await _userGroupService.CreateAsync(userGroupDto);
            return Ok(_mapper.Map<UserGroupResponse>(response));
        }
    }
}
