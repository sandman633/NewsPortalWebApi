using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Interfaces.CRUD
{
    public interface IUpdatableRange<TDto>
    {
        Task UpdateRangeAsync(IEnumerable<TDto> dtoes);
    }
}
