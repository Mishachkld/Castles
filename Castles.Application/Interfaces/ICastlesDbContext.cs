using Castles.Application.DTO.DatabaseDto;
using Castles.Entities;
using Microsoft.EntityFrameworkCore;

namespace Castles.Application.Interfaces;

public interface ICastlesDbContext
{
    public DbSet<CastleDatabaseDto> Castles { get; set; }
    public DbSet<CastlePictureDatabaseDto> CastlePictures { get; set; }
    public DbSet<OwnerDatabaseDto> Owners { get; set; }
    public DbSet<ViewingStatusDatabaseDto> ViewingStatuses { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken); // todo: посмотреть возвращаемое значение 
}