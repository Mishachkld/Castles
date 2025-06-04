using Castles.Application.DTO.DatabaseDto;
using Castles.Entities;
using Microsoft.EntityFrameworkCore;

namespace Castles.Application.Interfaces;

public interface ICastlesDbContext
{
    public DbSet<CastleDatabaseDto> Castles { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken); // todo: посмотреть возвращаемое значение 
}