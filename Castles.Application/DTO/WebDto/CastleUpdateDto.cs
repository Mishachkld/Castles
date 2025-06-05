namespace Castles.Application.DTO.WebDto;

public class CastleUpdateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? BuildDate { get; set; }
    public int OwnerId { get; set; }
    public int ViewingStatusId { get; set; }
}