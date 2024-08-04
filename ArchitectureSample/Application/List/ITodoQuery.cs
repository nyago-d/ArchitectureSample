namespace ArchitectureSample.Application.List
{
    /// <summary>
    /// TODOのクエリ
    /// </summary>
    /// <remarks>CQRSのQuery相当。ドメインモデルではなくUseCaseとして欲しいものをそのまま取って良い。</remarks>
    public interface ITodoQuery
    {
        Task<IEnumerable<TodoListDTO>> ListAsync();
    }
}
