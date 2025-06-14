namespace Castles.Application.DTO.WebDto;

public class CastleDetailsDto
{
    public string Name { get; set; }
    public int Id { get; set; }
    public OwnerDto? Owner { get; set; }
    public ViewingStatusDto? ViewingStatus { get; set; }
    public List<string>? PicturePath { get; set; }
    public string Description { get; set; }
    public DateTime? BuildDate { get; set; }
}