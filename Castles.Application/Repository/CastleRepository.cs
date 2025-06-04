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
        entity.Id = Guid.NewGuid();
        var castlesDb = _mapper.Map<CastleDatabaseDto>(entity);
        await _databaseContext.Castles.AddAsync(castlesDb);
        await _databaseContext.SaveChangesAsync(CancellationToken.None);
        return entity.Id;
    }

    public Task<Castle> Update(Guid id, Castle entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}