using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Castles.Application.DTO.DatabaseDto;

[Table("owners")]
public class OwnerDatabaseDto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; } 
    
    public ICollection<CastleDatabaseDto> Castles { get; set; } = new List<CastleDatabaseDto>();
}