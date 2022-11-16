using System.Text;

namespace Repositories.Interfaces.CRUD
{
    /// <summary>
    /// Interface for base operations(CRUD).
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface ICrudRepository<TModel> :
        ICreatable<TModel>,
        IDeletable,
        IUpdatable<TModel>,
        IUpdatableRange<TModel>,
        IGettable<TModel>,
        IGettableById<TModel>
    {

    }
}
