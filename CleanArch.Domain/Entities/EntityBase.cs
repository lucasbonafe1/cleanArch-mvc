namespace CleanArch.Domain.Entities;

public abstract class EntityBase
{
    public int Id { get; protected set; }
    public string Name { get; protected set; } = string.Empty;
}
