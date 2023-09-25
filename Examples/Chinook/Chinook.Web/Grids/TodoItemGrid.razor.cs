
#region usings
using Chinook.Data;
#endregion

namespace Chinook.Web.Grids;


public partial class TodoItemGrid : EntityGrid<TodoItem>
{
    protected override TodoItem CreateEntity()
    {
        var todoItem = Dao.TodoItem.Create();
        // TODO : CreateEntity

        return todoItem;
    }

    protected override Task<List<TodoItem>> GetCoreAsync() => Dao.TodoItem.GetAsync();

    protected override void InsertEntity(TodoItem entity) => Dao.TodoItem.Insert(entity);

    protected override void UpdateEntity(TodoItem entity) => Dao.TodoItem.Update(entity);

    protected override void DeleteEntity(TodoItem entity) => Dao.TodoItem.Delete(entity);
}

