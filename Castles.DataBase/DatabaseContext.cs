using Castles.Application.DTO.DatabaseDto;
using Castles.Application.Interfaces;
using Castles.Entities;
using Microsoft.EntityFrameworkCore;

namespace Castles.Database;

public class DatabaseContext : DbContext, ICastlesDbContext
{
    public DbSet<CastleDatabaseDto> Castles { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> configuration) : base(
        configuration)
    {
        Database.EnsureCreated(); 
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }

}