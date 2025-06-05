namespace Castles.Application.DTO.WebDto;

public class CreateCastleDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? BuildDate { get; set; }
    public int? OwnerId { get; set; }
    public int? ViewingStatusId { get; set; }
    public List<string>? PicturePaths { get; set; } = new List<string>();
}