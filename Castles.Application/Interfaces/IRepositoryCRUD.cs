
namespace Castles.Application.Interfaces;

public interface IRepositoryCRUD<TEntity>
{
    public Task<List<TEntity>> GetAll();
    public Task<TEntity> Get(Guid id);
    public Task<Guid> Add(TEntity entity);
    public Task<TEntity> Update(Guid id, TEntity entity);
    public Task<bool> Delete(Guid id);
    
}