using Chinook.Data;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;

namespace Chinook.Web.Grids;

public abstract class EntityGrid<T> : ComponentBase where T : Entity<T>, new()
{
    [Inject]
    public DialogService DialogService { get; set; }

    protected Task<bool?> Confirm() => DialogService.Confirm("Are you sure?", "Confirm", new ConfirmOptions { OkButtonText = "Yes", CancelButtonText = "No" });

    protected RadzenDataGrid<T> _grid;

    protected IEnumerable<T> list;

    protected void Reset()
    {
    }

    protected abstract Task<List<T>> GetCoreAsync();

    protected abstract T CreateEntity();

    protected abstract void InsertEntity(T entity);

    protected abstract void UpdateEntity(T entity);

    protected abstract void DeleteEntity(T entity);

    protected override async Task OnInitializedAsync()
    {
        list = await GetCoreAsync();
    }

    protected virtual async Task InsertRow()
    {
        var entity = CreateEntity();

        await _grid.InsertRow(entity);
    }

    protected virtual async Task DeleteRow(T entity)
    {
        DeleteEntity(entity);
        _grid.CancelEditRow(entity);

        await _grid.Reload();

        // if (Confirm().Result == true)
        //     DeleteEntity(entity);
        // else
        //     _grid.CancelEditRow(entity);
        //
        // await _grid.Reload();
    }
}