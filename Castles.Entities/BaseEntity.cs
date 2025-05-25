namespace Castles.Entities;

public class BaseEntity<TId>
{
    public TId Id { get; set; }
    public string Name { get; set; }
}