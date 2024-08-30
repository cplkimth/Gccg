using Chinook.Data;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.ControllerApi.Controllers.BaseControllers;

public abstract class DoubleKeyEntityController<T, K1, K2> : EntityController<T> where T : Entity<T>, new()
{
    protected abstract Task<T> GetByKeyAsync(K1 key1, K2 key2);
    protected abstract Task<bool> ExistsByKeyAsync(K1 key1, K2 key2);
    protected abstract Task<int> DeleteByKeyAsync(K1 key1, K2 key2);
    
    [HttpGet("{key1}/{key2}")]
    public async Task<ActionResult<T>> GetByKey(K1 key1, K2 key2)
    {
        var entity = await GetByKeyAsync(key1, key2);

        if (entity == EmptyEntity) 
            return NotFound();

        return Ok(entity);
    }

    [HttpGet("exists/{key1}/{key2}")]
    public async Task<IActionResult> ExistsByKey(K1 key1, K2 key2)
    {
        return await ExistsByKeyAsync(key1, key2) switch
        {
            true => Ok(),
            false => NotFound()
        };
    }

    [HttpDelete("{key1}/{key2}")]
    public async Task<IActionResult> Delete(K1 key1, K2 key2)
    {
        int count = await DeleteByKeyAsync(key1, key2);

        return count switch
        {
            0 => NotFound(),
            _ => NoContent()
        };
    }
}