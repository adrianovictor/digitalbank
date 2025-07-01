namespace DigitalBank.Domain.Common;

public interface IEntity<in TEntity> : IAuditing
{
    int Id { get; }

    bool SameIdentityAs(TEntity other);
    int GetIdentityHashCode();
    bool IsPersisted();
}
