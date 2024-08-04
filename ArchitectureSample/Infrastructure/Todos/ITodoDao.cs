using ArchitectureSample.Application.List;

namespace ArchitectureSample.Infrastructure.Todos
{
    /// <summary>
    /// Todoリストのデータアクセス
    /// </summary>
    /// <remarks>QueryとRepository両方のデータアクセスを受け持っているけれど、別に分けてもいい。</remarks>
    public interface ITodoDao
    {
        Task<IEnumerable<TodoListDTO>> ListAsync();

        Task<TodoDTO?> ReadAsync(int todoId);

        Task<TodoDTO> CreateAsync(TodoDTO todo);

        Task<bool> UpdateAsync(TodoDTO todo);

        Task<bool> DeleteAsync(int todoId);
    }
}
