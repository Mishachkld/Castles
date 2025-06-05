using AutoMapper;
using Castles.Application.DTO.DatabaseDto;
using Castles.Application.DTO.WebDto;
using Castles.Application.Interfaces;
using Castles.Entities;
using Microsoft.EntityFrameworkCore;

namespace Castles.Application.Service;

public class CastleService
{
    private readonly ICastlesDbContext _context;
    private readonly IMapper _mapper;

    public CastleService(ICastlesDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<CastleDetails> GetCastleWithDetailsAsync(Guid castleId)
    {
        var castle = await _context.Castles
            .Include(c => c.Owner)
            .Include(c => c.ViewingStatus)
            .Include(c => c.Pictures)
            .FirstOrDefaultAsync(c => c.Id == castleId);

        if (castle == null)
        {
            throw new KeyNotFoundException($"The castle was not found. Id: '{castleId}'");
        }

        return _mapper.Map<CastleDetails>(castle);
    } 
    public async Task<List<CastleDetails>> GetCastles()
    {
        var castles = _context.Castles
            .Include(c => c.Owner)
            .Include(c => c.ViewingStatus)
            .Include(c => c.Pictures);

        return _mapper.Map<List<CastleDetails>>(castles);
    }

    public async Task<CastleDetails> CreateCastleAsync(CreateCastleDto createDto)
    {
        // Проверяем существование владельца и статуса просмотра
        var ownerExists = await _context.Owners.AnyAsync(o => o.Id == createDto.OwnerId);
        var statusExists = await _context.ViewingStatuses.AnyAsync(v => v.Id == createDto.ViewingStatusId);

        if (!ownerExists || !statusExists)
        {
            throw new ArgumentException("Owner or ViewingStatus not found");
        }

        // Создаем новый замок
        var castle = new CastleDatabaseDto
        {
            Name = createDto.Name,
            Description = createDto.Description,
            BuildDate = createDto.BuildDate,
            OwnerId = createDto.OwnerId,
            ViewingStatusId = createDto.ViewingStatusId,
            CreationDate = DateTime.UtcNow,
            Pictures = createDto.PicturePaths.Select(path => new CastlePictureDatabaseDto
            {
                Path = path
            }).ToList()
        };

        // Добавляем в контекст
        _context.Castles.Add(castle);
        await _context.SaveChangesAsync(CancellationToken.None);

        // Возвращаем созданный замок с деталями
        return _mapper.Map<CastleDetails>(castle);
    }
    
    public async Task<CastleDetails> UpdateCastleAsync(Guid castleId, CastleUpdateDto updateDto)
    {
        var castle = await _context.Castles
            .Include(c => c.Pictures)
            .FirstOrDefaultAsync(c => c.Id == castleId);

        if (castle == null)
            throw new KeyNotFoundException("Castle not found");

        // Проверяем существование владельца и статуса
        var ownerExists = await _context.Owners.AnyAsync(o => o.Id == updateDto.OwnerId);
        var statusExists = await _context.ViewingStatuses.AnyAsync(v => v.Id == updateDto.ViewingStatusId);

        if (!ownerExists || !statusExists)
            throw new ArgumentException("Owner or ViewingStatus not found");

        // Обновляем основные поля
        castle.Name = updateDto.Name;
        castle.Description = updateDto.Description;
        castle.BuildDate = updateDto.BuildDate;
        castle.OwnerId = updateDto.OwnerId;
        castle.ViewingStatusId = updateDto.ViewingStatusId;
        castle.UpdateDate = DateTime.UtcNow;

        await _context.SaveChangesAsync(CancellationToken.None);

        return _mapper.Map<CastleDetails>(castle);
    }

    
}