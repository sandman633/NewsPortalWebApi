using Bl.Services.Interfaces.CRUD;
using DAL.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Interfaces
{
    public interface ICommentsService : ICrudService<CommentsDto>
    {
        Task<CommentsDto> ReplyComment(CommentsDto comment);
        Task HideComments(params int[] ids);
        Task<IEnumerable<CommentsDto>> GetCommentsFromNews(int newsId);
        Task<IEnumerable<CommentsDto>> GetCommentsFromUser(int userId);
    }
}
