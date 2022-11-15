using AutoMapper;
using NewsPortal.BusinessLogic.Services.Interfaces;
using NewsPortal.DAL.Dto;
using NewsPortal.DAL.Request.User;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, IMapper mapper, ILogger<UserController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserResponse>))]
        public async Task<IActionResult> GetAsync()
        {
            _logger.LogInformation("Users/Get was requested.");
            var response = await _userService.GetAsync();
            return Ok(_mapper.Map<IEnumerable<UserResponse>>(response));
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Users/GetById was requested.");
            var response = await _userService.GetByIdAsync(id);
            return Ok(_mapper.Map<UserResponse>(response));
        }
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Users/Delete was requested.");
            await _userService.DeleteAsync(id);
            return NoContent();
        }
        [HttpPost("Update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
        public async Task<IActionResult> UpdateAsync(UpdateUserRequest user, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Users/Update was requested.");
            var userDto = _mapper.Map<UserDto>(user);
            var response = await _userService.UpdateAsync(userDto);
            return Ok(_mapper.Map<UserResponse>(response));
        }
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
        public async Task<IActionResult> CreateAsync(NewUserRequest  user, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Users/Create was requested.");
            var userDto = _mapper.Map<UserDto>(user);
            var response = await _userService.CreateAsync(userDto);
            return Ok(_mapper.Map<UserResponse>(response));
        }
    }
}
