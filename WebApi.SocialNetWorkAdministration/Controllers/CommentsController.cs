using AutoMapper;
using NewsPortal.BusinessLogic.Services.Interfaces;
using NewsPortal.DAL.Dto;
using NewsPortal.DAL.Request.Comments;
using NewsPortal.DAL.Response.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApi.SocialNetWorkAdministration.Swagger;

namespace NewsPortal.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService _commentsService;
        private readonly IMapper _mapper;
        private readonly ILogger<CommentsController> _logger;

        public CommentsController(ICommentsService commentsService, IMapper mapper, ILogger<CommentsController> logger)
        {
            _commentsService = commentsService;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CommentsResponse>))]
        public async Task<IActionResult> GetAsync()
        {
            _logger.LogInformation("Comments/Get was requested.");
            var response = await _commentsService.GetAsync();
            return Ok(_mapper.Map<IEnumerable<CommentsResponse>>(response));
        }
        [HttpGet("News/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CommentsResponse>))]
        public async Task<IActionResult> GetCommentsFromNewsAsync(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Comments/Get was requested.");
            var response = await _commentsService.GetCommentsFromNews(id);
            return Ok(_mapper.Map<IEnumerable<CommentsResponse>>(response));
        }
        [HttpGet("User/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CommentsResponse>))]
        public async Task<IActionResult> GetCommentsFromUserAsync(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Comments/Get was requested.");
            var response = await _commentsService.GetCommentsFromUser(id);
            return Ok(_mapper.Map<IEnumerable<CommentsResponse>>(response));
        }
        [Authorize(Policy = "ReadComments")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommentsResponse))]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Comments/GetById was requested.");
            var response = await _commentsService.GetByIdAsync(id);
            return Ok(_mapper.Map<CommentsResponse>(response));
        }
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Comments/Delete was requested.");
            await _commentsService.DeleteAsync(id);
            return NoContent();
        }
        [HttpDelete("Hide/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> HideAsync(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Comments/Hide was requested.");
            await _commentsService.HideComments(id);
            return NoContent();
        }
        [HttpPost("Update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommentsResponse))]
        public async Task<IActionResult> UpdateAsync(UpdateCommentRequest comment, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Comments/Update was requested.");
            var commentDto = _mapper.Map<CommentsDto>(comment);
            var response = await _commentsService.UpdateAsync(commentDto);
            return Ok(_mapper.Map<CommentsResponse>(response));
        }
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommentsResponse))]
        public async Task<IActionResult> CreateAsync(NewCommentRequest comment, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Comments/Create was requested.");
            var commentDto = _mapper.Map<CommentsDto>(comment);
            var response = await _commentsService.CreateAsync(commentDto);
            return Ok(_mapper.Map<CommentsResponse>(response));
        }
        [HttpPost("Reply")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommentsResponse))]
        public async Task<IActionResult> ReplyAsync(NewCommentRequest comment, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Comments/Create was requested.");
            var commentDto = _mapper.Map<CommentsDto>(comment);
            var response = await _commentsService.ReplyComment(commentDto);
            return Ok(_mapper.Map<CommentsResponse>(response));
        }
    }
}
