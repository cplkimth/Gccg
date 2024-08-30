using Chinook.Data;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.ControllerApi.Controllers.BaseControllers;

public abstract class SingleKeyEntityController<T, K> : EntityController<T> where T : Entity<T>, new()
{
    protected abstract Task<T> GetByKeyAsync(K key);
    protected abstract Task<bool> ExistsByKeyAsync(K key);
    protected abstract Task<int> DeleteByKeyAsync(K key);

    [HttpGet("{key}")]
    public async Task<ActionResult<T>> GetByKey(K key)
    {
        var entity = await GetByKeyAsync(key);

        if (entity == EmptyEntity) 
            return NotFound();

        return Ok(entity);
    }

    [HttpGet("exists/{key}")]
    public async Task<IActionResult> ExistsByKey(K key)
    {
        return await ExistsByKeyAsync(key) switch
        {
            true => Ok(),
            false => NotFound()
        };
    }

    [HttpDelete("{key}")]
    public async Task<IActionResult> Delete(K key)
    {
        int count = await DeleteByKeyAsync(key);

        return count switch
        {
            0 => NotFound(),
            _ => NoContent()
        };
    }
}