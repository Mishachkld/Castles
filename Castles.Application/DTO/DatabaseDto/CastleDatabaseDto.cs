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
    [ForeignKey("owner_Id")]
    public OwnerDatabaseDto? Owner { get; set; }
    public int? OwnerId { get; set; }
    
    // Связь со статусом просмотра
    [ForeignKey("viewing_status_id")]
    public ViewingStatusDatabaseDto? ViewingStatus { get; set; }
    public int? ViewingStatusId { get; set; }
    
    // Коллекция картинок
    public ICollection<CastlePictureDatabaseDto>? Pictures { get; set; } = new List<CastlePictureDatabaseDto>();
}