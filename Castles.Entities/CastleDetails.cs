namespace Castles.Entities;

public class CastleDetails : Castle
{
    public Owner? Owner { get; set; }
    public ViewingStatus? ViewingStatus { get; set; }
    public List<string>? PicturePath { get; set; }
}