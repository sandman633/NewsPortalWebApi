using AutoMapper;
using BL.Services.Interfaces;
using DAL.Dto;
using DAL.Request.GroupPolicy;
using DAL.Response.GroupPolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.SocialNetWorkAdministration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupPolicyController : ControllerBase
    {
        private readonly IGroupPolicyService _groupPolicyService;
        private readonly IMapper _mapper;
        private readonly ILogger<GroupPolicyController> _logger;

        public GroupPolicyController(IGroupPolicyService groupPolicyService, IMapper mapper, ILogger<GroupPolicyController> logger)
        {
            _groupPolicyService = groupPolicyService;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GroupPolicyResponse>))]
        public async Task<IActionResult> GetAsync()
        {
            _logger.LogInformation("GroupPolicy/Get was requested.");
            var response = await _groupPolicyService.GetAsync();
            return Ok(_mapper.Map<IEnumerable<GroupPolicyResponse>>(response));
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GroupPolicyResponse))]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GroupPolicy/GetById was requested.");
            var response = await _groupPolicyService.GetByIdAsync(id);
            return Ok(_mapper.Map<GroupPolicyResponse>(response));
        }
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GroupPolicyResponse))]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GroupPolicy/Delete was requested.");
            await _groupPolicyService.DeleteAsync(id);
            return NoContent();
        }
        [HttpPost("Update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GroupPolicyResponse))]
        public async Task<IActionResult> UpdateAsync(UpdateGroupPolicyRequest groupPolicy, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GroupPolicy/Update was requested.");
            var groupPolicyDto = _mapper.Map<GroupPolicyDto>(groupPolicy);
            var response = await _groupPolicyService.UpdateAsync(groupPolicyDto);
            return Ok(_mapper.Map<GroupPolicyResponse>(response));
        }
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GroupPolicyResponse))]
        public async Task<IActionResult> CreateAsync(NewGroupPolicyRequest groupPolicy, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GroupPolicy/Create was requested.");
            var groupPolicyDto = _mapper.Map<GroupPolicyDto>(groupPolicy);
            var response = await _groupPolicyService.CreateAsync(groupPolicyDto);
            return Ok(_mapper.Map<GroupPolicyResponse>(response));
        }
    }
}
