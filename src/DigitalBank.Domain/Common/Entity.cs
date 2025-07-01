namespace DigitalBank.Domain.Common;

public abstract class Entity<TEntity> : IEntity<TEntity>
    where TEntity : class
{
    public int Id { get; protected set; }

    public DateTime CreatedAt { get; set; }
    public int CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int? UpdatedBy { get; set; }

    public abstract bool SameIdentityAs(TEntity other);
    public abstract int GetIdentityHashCode();
    public abstract override string ToString();

    public static bool operator ==(Entity<TEntity> left, Entity<TEntity> right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Entity<TEntity> left, Entity<TEntity> right)
    {
        return !Equals(left, right);
    }

    public override bool Equals(object obj)
    {
        if (IsTransient())
            return base.Equals(obj);

        return SameIdentityAs(obj as TEntity);
    }

    public override int GetHashCode()
    {
        return IsTransient() ? base.GetHashCode() : GetIdentityHashCode();
    }

    public virtual bool IsPersisted()
    {
        return !IsTransient();
    }

    protected virtual bool IsTransient()
    {
        return Id == 0;
    }    
}
