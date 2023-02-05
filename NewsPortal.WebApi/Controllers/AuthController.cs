using NewsPortal.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsPortal.DAL.Request.Authentificate;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using NewsPortal.WebApi.Infrastructure.AuthOptions;
using NewsPortal.DAL.Dto;
using NewsPortal.DAL.Response;

namespace NewsPortal.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtAuthManager _jwtAuthManager;
        private readonly IGroupPolicyService _groupPolicyService;
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService, JwtAuthManager jwtAuthManager, IGroupPolicyService groupPolicyService, ILogger<AuthController> logger)
        {
            _groupPolicyService = groupPolicyService;
            _logger = logger;
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
        public async Task<ActionResult<Result<AuthResponse>>> AuthenticateAsync(AuthRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Authenticate was requested.");
            try
            {
                var authenticatedUser = await _authService.AuthenticateAsync(request.Email, request.Password);
                if (authenticatedUser == null)
                    return BadRequest("Wrong password!");
                var result = await SendToken(authenticatedUser);
                return Ok(new Result<AuthResponse>(result));
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
        private async Task<AuthResponse> SendToken(AuthenticatedUserDto user)
        {
            var now = DateTime.Now;
            var refreshTime = now.AddMonths(1);
            var policies = await _groupPolicyService.GetPoliciesForUser(user.Id);
            List<Claim> claims = new List<Claim>();
            foreach (var policy in policies)
            {
                claims.Add(new Claim(policy.Key, policy.Value.ToString()));
            }

            claims.Add(new Claim(ClaimTypes.Name, user.Email));

            var jwtResult = _jwtAuthManager.GenerateAccessToken(claims.ToArray(), now);
            var jwtRefreshToken = _jwtAuthManager.GenerateRefreshToken(refreshTime);

            _authService.AddToken(user.Id,jwtRefreshToken, refreshTime);

            var authResponse = new AuthResponse
            {
                Id = user.Id,
                Email = user.Email,
                Token = jwtResult.AccessToken,
                RefreshToken = jwtRefreshToken
            };
            return authResponse;
        }
    }
}
