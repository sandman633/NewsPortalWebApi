using System.Threading.Tasks;

namespace NewsPortal.BusinessLogic.Services.Interfaces.CRUD
{
    /// <summary>
    /// Interface for updating entity.
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    public interface IUpdatable<TDto>
    {
        /// <summary>
        /// Interface method for updating entity.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<TDto> UpdateAsync(TDto dto);
    }
}