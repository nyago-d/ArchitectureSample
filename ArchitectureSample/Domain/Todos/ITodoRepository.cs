namespace ArchitectureSample.Domain.Todos
{
    /// <summary>
    /// TODOのリポジトリ
    /// </summary>
    /// <remarks>CQRSっぽく作っているのでCommand相当に近いけれど、ドメインモデルとしてReadするときは使いたいのでCRUD揃えてみた。</remarks>
    public interface ITodoRepository
    {
        Task<Todo> CreateAsync(Todo todo);

        Task<Todo?> ReadAsync(TodoId todoId);

        Task<bool> UpdateAsync(Todo todo);

        Task<bool> DeleteAsync(TodoId todo);
    }
}
