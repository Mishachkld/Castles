using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Castles.Application.DTO.DatabaseDto;

[Table("castles_picture")]
public class CastlePictureDatabaseDto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column("path")]
    public string Path { get; set; }

    [ForeignKey("castle_id")]
    public CastleDatabaseDto Castle { get; set; }
    public Guid CastleId { get; set; }
}