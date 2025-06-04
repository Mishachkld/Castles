using AutoMapper;
using Castles.Application.DTO.DatabaseDto;
using Castles.Application.Interfaces;
using Castles.Entities;
using Microsoft.EntityFrameworkCore;

namespace Castles.Application.Repository;

public class CastleRepository : IRepositoryCRUD<Castle>
{
    private readonly ICastlesDbContext _databaseContext;
    private readonly IMapper _mapper;

    public CastleRepository(IMapper mapper, ICastlesDbContext databaseContext)
    {
        _mapper = mapper;
        _databaseContext = databaseContext;
    }

    public async Task<List<Castle>> GetAll()
    {
        var castlesDb = await _databaseContext.Castles.ToListAsync();
        return _mapper.Map<List<Castle>>(castlesDb);
    }

    public async Task<Castle> Get(Guid id)
    {
        var castlesDb = await _databaseContext.Castles.FindAsync(id);
        if (castlesDb == null)
        {
            throw new KeyNotFoundException($"The castle (замок) with id '{id}' was not found.");
        }

        return _mapper.Map<Castle>(castlesDb);
    }

    public async Task<Guid> Add(Castle entity)
    {
        if (string.IsNullOrWhiteSpace(entity?.Name))
        {
            throw new Exception("Name is required");
        }
        var id = Guid.NewGuid();
        var castlesDb = _mapper.Map<CastleDatabaseDto>(entity);
        castlesDb.Id = id;
        castlesDb.CreationDate = DateTime.Now;
        await _databaseContext.Castles.AddAsync(castlesDb);
        await _databaseContext.SaveChangesAsync(CancellationToken.None);
        return id;
    }

    public async Task<Castle> Update(Guid id, Castle entity)
    {   // todo: Добавить проеврку
        var currentCastle = await _databaseContext.Castles.FindAsync(id);
        if (currentCastle == null)
        {
            // todo: добавить свою ошибку
            throw new Exception($"Object with Id '{id}' not found.");
        }
        currentCastle.UpdateDate = DateTime.Now;
        currentCastle.Name = entity.Name;
        currentCastle.Description = entity.Description;
        currentCastle.BuildDate = entity.BuildDate;
        _databaseContext.Castles.Update(currentCastle);
        await _databaseContext.SaveChangesAsync(CancellationToken.None);
        return _mapper.Map<Castle>(currentCastle);    
    }

    public async Task<bool> Delete(Guid id)
    {
        var currentCastle = await _databaseContext.Castles.FindAsync(id);
        if (currentCastle == null)
        {
            // todo: добавить свою ошибку
            throw new Exception($"Object with Id '{id}' not found.");
        }
        _databaseContext.Castles.Remove(currentCastle);
        await _databaseContext.SaveChangesAsync(CancellationToken.None);
        return true;
    }
}