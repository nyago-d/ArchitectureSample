namespace ArchitectureSample.Application.List
{
    /// <summary>
    /// List機能の出力データ
    /// </summary>
    public record ListOutputData(IEnumerable<TodoListDTO> ListData);
}
