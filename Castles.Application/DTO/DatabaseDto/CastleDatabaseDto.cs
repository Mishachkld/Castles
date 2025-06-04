using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Castles.Application.DTO.DatabaseDto;

[Table("castles_entityframework")]
public class CastleDatabaseDto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("description")]
    public string Description { get; set; }
    [Column("build_date")]
    public DateTime? BuildDate { get; set; }
    [Column("creation_date")]
    public DateTime CreationDate { get; set; }
    [Column("update_date")]
    public DateTime? UpdateDate { get; set; }
}