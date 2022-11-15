using System.Threading.Tasks;

namespace Repositories.Interfaces.CRUD
{
    /// <summary>
    /// Interface for deleting entity.
    /// </summary>
    public interface IDeletable
    {
        /// <summary>
        /// Interface method for deleting entity.
        /// </summary>
        Task DeleteAsync(params int[] ids);
    }
}