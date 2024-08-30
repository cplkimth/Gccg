using Chinook.Data;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.ControllerApi.Controllers.BaseControllers;

[Route("api/[controller]")]
[ApiController]
public abstract class EntityController<T> : ControllerBase where T : Entity<T>, new()
{
    protected abstract object GetRouteValue(T entity);
    protected abstract T EmptyEntity { get; }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<T>>> Get()
    {
        return await Dao.Get<T>().GetAsync();
    }

    [HttpGet("count")]
    public async Task<ActionResult<int>> GetCount() => await Dao.Get<T>().GetCountAsync();

    [HttpPost]
    public async Task<ActionResult<Customer>> Insert(T entity)
    {
        entity = await Dao.Get<T>().InsertAsync(entity);

        return CreatedAtAction("GetByKey", GetRouteValue(entity), entity);
    }

    [HttpPut]
    public async Task<IActionResult> Update(T entity)
    {
        int count = await Dao.Get<T>().UpdateAsync(entity);
        
        return count switch
        {
            0 => NotFound(),
            _ => NoContent()
        };
    }
}