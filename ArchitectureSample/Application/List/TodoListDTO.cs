namespace ArchitectureSample.Application.List
{
    /// <summary>
    /// List機能用のDTO
    /// </summary>
    public record TodoListDTO(int Id, string Title, IEnumerable<string> Tags);
}
