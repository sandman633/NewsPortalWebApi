namespace NewsPortal.BusinessLogic.Services.Interfaces.CRUD
{
    /// <summary>
    /// Interface for base operations(CRUD).
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    public interface ICrudService<TDto>:
        ICreatable<TDto>,
        IDeletable,
        IGettable<TDto>,
        IGettableById<TDto>,
        IUpdatable<TDto>
    {
        
    }
}