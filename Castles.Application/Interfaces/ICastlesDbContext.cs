using Castles.Entities;
using Microsoft.EntityFrameworkCore;

namespace Castles.Application.Interfaces;

public interface ICastlesDbContext
{
    public DbSet<Castle> Castles { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken); // todo: посмотреть возвращаемое значение 
}