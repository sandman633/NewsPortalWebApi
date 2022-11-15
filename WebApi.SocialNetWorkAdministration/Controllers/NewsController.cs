using AutoMapper;
using BL.Services.Interfaces;
using DAL.Dto;
using DAL.Request.News;
using DAL.Response;
using DAL.Response.News;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NewsPortal.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Result))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Result))]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        private readonly IMapper _mapper;
        private readonly ILogger<NewsController> _logger;

        public NewsController(INewsService newsService, IMapper mapper, ILogger<NewsController> logger)
        {
            _newsService = newsService;
            _mapper = mapper;
            _logger = logger;
        }
        
        [Authorize(Policy = "ReadNews")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<NewsResponse>))]
        public async Task<IActionResult> GetAsync()
        {
            _logger.LogInformation("Users/Get was requested.");
            var response = await _newsService.GetAsync();
            return Ok(_mapper.Map<IEnumerable<NewsResponse>>(response));
        }
        [Authorize(Policy = "ReadNews")]
        [HttpGet("User/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<NewsResponse>))]
        public async Task<IActionResult> GetNewsByUserAsync(int id)
        {
            _logger.LogInformation("Users/Get was requested.");
            var response = await _newsService.GetNewsByUser(id);
            return Ok(_mapper.Map<IEnumerable<NewsResponse>>(response));
        }
        [Authorize(Policy = "ReadNews")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewsResponse))]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Users/GetById was requested.");
            var response = await _newsService.GetByIdAsync(id);
            return Ok(_mapper.Map<NewsResponse>(response));
        }
        [Authorize(Policy = "DeleteNews")]
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewsResponse))]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Users/Delete was requested.");
            await _newsService.DeleteAsync(id);
            return NoContent();
        }
        [Authorize(Policy = "UpdateNews")]
        [HttpPost("Update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewsResponse))]
        public async Task<IActionResult> UpdateAsync(UpdateNewsRequest news, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Users/Update was requested.");
            var newsDto = _mapper.Map<NewsDto>(news);
            //TODO: подумать должно ли это быть здесь ??
            newsDto.UpdatedTime = DateTime.Now;
            //
            var response = await _newsService.UpdateAsync(newsDto);
            return Ok(_mapper.Map<NewsResponse>(response));
        }
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewsResponse))]
        public async Task<IActionResult> CreateAsync(NewNewsRequest news, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Users/Create was requested.");
            var newsDto = _mapper.Map<NewsDto>(news);
            var response = await _newsService.CreateAsync(newsDto);
            return Ok(_mapper.Map<NewsResponse>(response));
        }
    }
}
