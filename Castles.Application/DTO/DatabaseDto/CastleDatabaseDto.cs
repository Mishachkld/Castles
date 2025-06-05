using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Castles.Application.DTO.DatabaseDto;

[Table("castles")]
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
    
    // Связь с владельцем
    [ForeignKey("OwnerId")] 
    public OwnerDatabaseDto Owner { get; set; }
    
    [Column("owner_id")] 
    public int? OwnerId { get; set; }
    
    [ForeignKey("ViewingStatusId")]
    public ViewingStatusDatabaseDto ViewingStatus { get; set; }
    
    [Column("viewing_status_id")]
    public int? ViewingStatusId { get; set; }
    
    // Коллекция картинок
    public ICollection<CastlePictureDatabaseDto> Pictures { get; set; } = new List<CastlePictureDatabaseDto>();
}