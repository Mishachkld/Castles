namespace Castles.Entities;

public class Castle : BaseEntity<Guid>
{
    public string Description { get; set; }
    public int YearOfCreation { get; set; }
    public string Owner { get; set; }
}