using System.Threading.Tasks;

namespace Repositories.Interfaces.CRUD
{
    /// <summary>
    /// Interface for creating new entity.
    /// </summary>
    /// <typeparam name="TDto">DTO.</typeparam>
    public interface ICreatable<TDto>
    {
        /// <summary>
        /// Interface method for creating new entity.
        /// </summary>
        Task<TDto> CreateAsync(TDto dto);
    }
}