using Chinook.Data;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.ControllerApi.Controllers.BaseControllers;

public abstract class TripleKeyEntityController<T, K1, K2, K3> : EntityController<T> where T : Entity<T>, new()
{
    protected abstract Task<T> GetByKeyAsync(K1 key1, K2 key2, K3 key3);
    protected abstract Task<bool> ExistsByKeyAsync(K1 key1, K2 key2, K3 key3);
    protected abstract Task<int> DeleteByKeyAsync(K1 key1, K2 key2, K3 key3);
    
    [HttpGet("{key1}/{key2}/{key3}")]
    public async Task<ActionResult<T>> GetByKey(K1 key1, K2 key2, K3 key3)
    {
        var entity = await GetByKeyAsync(key1, key2, key3);

        if (entity == EmptyEntity) 
            return NotFound();

        return Ok(entity);
    }

    [HttpGet("exists/{key1}/{key2}/{key3}")]
    public async Task<IActionResult> ExistsByKey(K1 key1, K2 key2, K3 key3)
    {
        return await ExistsByKeyAsync(key1, key2, key3) switch
        {
            true => Ok(),
            false => NotFound()
        };
    }

    [HttpDelete("{key1}/{key2}/{key3}")]
    public async Task<IActionResult> Delete(K1 key1, K2 key2, K3 key3)
    {
        int count = await DeleteByKeyAsync(key1, key2, key3);

        return count switch
        {
            0 => NotFound(),
            _ => NoContent()
        };
    }
}