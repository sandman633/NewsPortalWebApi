using System.Text;

namespace Repositories.Interfaces.CRUD
{
    /// <summary>
    /// Interface for base operations(CRUD).
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    /// <typeparam name="TModel"></typeparam>
    public interface ICrudRepository<TDto, TModel> :
        ICreatable<TDto>,
        IDeletable,
        IUpdatable<TDto>,
        IUpdatableRange<TDto>,
        IGettable<TDto, TModel>,
        IGettableById<TDto>
    {

    }
}
