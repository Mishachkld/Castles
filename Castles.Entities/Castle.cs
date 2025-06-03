namespace Castles.Entities;

public class Castle : BaseEntity<Guid>
{
    public string Description { get; set; }
    public DateTime? BuildDate { get; set; }
}