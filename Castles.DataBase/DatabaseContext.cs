using Castles.Application.DTO.DatabaseDto;
using Castles.Application.Interfaces;
using Castles.Entities;
using Microsoft.EntityFrameworkCore;

namespace Castles.Database;

public class DatabaseContext : DbContext, ICastlesDbContext
{
    public DbSet<CastleDatabaseDto> Castles { get; set; }
    public DbSet<CastlePictureDatabaseDto> CastlePictures { get; set; }
    public DbSet<OwnerDatabaseDto> Owners { get; set; }
    public DbSet<ViewingStatusDatabaseDto> ViewingStatuses { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> configuration) : base(configuration)
    {
        Database.EnsureCreated(); 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Настройка связей
        modelBuilder.Entity<CastleDatabaseDto>()
            .HasMany(c => c.Pictures)
            .WithOne(p => p.Castle)
            .HasForeignKey(p => p.CastleId)
            .OnDelete(DeleteBehavior.Cascade);

        // Настройка связи со статусом
        modelBuilder.Entity<CastleDatabaseDto>()
            .HasOne(c => c.ViewingStatus)
            .WithMany(v => v.Castles)
            .HasForeignKey(c => c.ViewingStatusId)
            .OnDelete(DeleteBehavior.Restrict); 
        
        // Настройка связи с Owner
        modelBuilder.Entity<CastleDatabaseDto>()
            .HasOne(c => c.Owner)
            .WithMany(v => v.Castles)
            .HasForeignKey(c => c.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);



        modelBuilder.Entity<ViewingStatusDatabaseDto>().HasData(
            new ViewingStatusDatabaseDto { Id = 1, Name = "Доступен для просмотра" },
            new ViewingStatusDatabaseDto { Id = 2, Name = "Закрыт для посещения" },
            new ViewingStatusDatabaseDto { Id = 3, Name = "Частично доступен" }
        ); 
        modelBuilder.Entity<OwnerDatabaseDto>().HasData(
           new OwnerDatabaseDto(){Id = 1, Name = "Лютый владелец"},
           new OwnerDatabaseDto(){Id = 2, Name = "Необычный владелец"},
           new OwnerDatabaseDto(){Id = 3, Name = "Хороший король"}
        );
    }

}