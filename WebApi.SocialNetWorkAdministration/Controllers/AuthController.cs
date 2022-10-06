using AutoMapper;
using BL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DAL.Dto;
using DAL.Request.Authentificate;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using WebApi.SocialNetWorkAdministration.Infrastructure.AuthOptions;
using WebApi.SocialNetWorkAdministration.Swagger;

namespace WebApi.SocialNetWorkAdministration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtAuthManager _jwtAuthManager;
        private readonly IUserRoleService _userRoleService;
        private readonly IUserPolicyService _userPolicyService;
        private readonly ILogger<AuthController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;


        public AuthController(IAuthService authService, JwtAuthManager jwtAuthManager,IUserPolicyService userPolicyService, ILogger<AuthController> logger, IMapper mapper) 
        {
            _userPolicyService = userPolicyService;
            _logger = logger;
            _mapper = mapper;
            _authService = authService;
            _jwtAuthManager = jwtAuthManager;
        }

        /// <summary>
        /// Authenticates employee by request parameters.
        /// </summary>
        /// <param name="request">Authentication request model.</param>
        [HttpPost("authenticate")]
        [ProducesResponseType(typeof(AuthResponse), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public async Task<IActionResult> AuthenticateAsync(AuthRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Authenticate was requested.");
            try
            {
                var authenticatedUser = await _authService.AuthenticateAsync(request.Email, request.Password);
                if (authenticatedUser == null)
                    return BadRequest("Wrong password!");
                return await SendToken(authenticatedUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        /// <summary>
        /// Returns auth info for given user.
        /// </summary>
        /// <param name="user">Authenticated user.</param>
        private async Task<IActionResult> SendToken(AuthenticatedUserDto user)
        {
            var policies = await _userPolicyService.GetPolicy(user.Id);
            List<Claim> claims = new List<Claim>();
            foreach (var policy in policies)
            {
                claims.Add(new Claim(policy.Key,policy.Value.ToString()));
            }

            claims.Add(new Claim(ClaimTypes.Name, user.Email));

            var jwtResult = _jwtAuthManager.GenerateAccessToken(claims.ToArray(), DateTime.Now);

            var authResponse = new AuthResponse
            {
                Id = user.Id,
                Email = user.Email,
                Token = jwtResult.AccessToken
            };
            return Ok(authResponse);
        }
    }
}
