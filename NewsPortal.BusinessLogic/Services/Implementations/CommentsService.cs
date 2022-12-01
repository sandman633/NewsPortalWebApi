using NewsPortal.BusinessLogic.Services.Interfaces;
using NewsPortal.Model.Domain;
using NewsPortal.DAL.Dto;
using Repositories.Interfaces;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System;
using NewsPortal.BusinessLogic.Services.Infrastructure;
using NewsPortal.Model;
using AutoMapper;

namespace NewsPortal.BusinessLogic.Services.Implementations
{
    public class CommentsService : BaseService<CommentsDto,Comments, ICommentsRepository>, ICommentsService
    {
        public CommentsService(IUnitOfWork<WebApiContext> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        public override async Task<CommentsDto> UpdateAsync(CommentsDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            var originalEntity = await GetByIdAsync(dto.Id);
            if (originalEntity == null) throw new NullReferenceException(nameof(originalEntity));
            originalEntity = MapForUpdateHelper.CommentUpdateMap(dto, originalEntity);
            return await base.UpdateAsync(originalEntity);
        }
        public async Task<IEnumerable<CommentsDto>> GetCommentsFromNews(int newsId)
        {
            return _mapper.Map<IEnumerable<CommentsDto>>(await _crudRepository.GetByCriteriaAsync(c => c.NewsId == newsId));
        }
        public async Task<IEnumerable<CommentsDto>> GetCommentsFromUser(int userId)
        {
            return  _mapper.Map<IEnumerable<CommentsDto>>(await _crudRepository.GetByCriteriaAsync(c => c.UserId == userId));
        }
        public async Task HideComments(params int[] ids)
        {
            try
            {
                var entites = (await _crudRepository.GetByCriteriaAsync(src => ids.Contains(src.Id))).ToList();
                foreach (var entite in entites)
                {
                    entite.CommentState = CommentState.DELETED;
                }
                await _crudRepository.UpdateRangeAsync(entites);
                _unitOfWork.SaveChanges();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public async Task<CommentsDto> ReplyComment(CommentsDto comment)
        {
            if (comment.LinkedCommentId != null)
            {
                var linkedComment = await GetByIdAsync(comment.LinkedCommentId.Value);
                if (linkedComment.Root == 5)
                {
                    //TODO: добавить эксепшп для коммента 
                    return null;
                }
                comment.Root = linkedComment.Root++;
                return await CreateAsync(comment);
            }
            comment.Root = 1;
            return await CreateAsync(comment);
        }

    }
}
