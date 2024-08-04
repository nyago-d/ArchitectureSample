using ArchitectureSample.Application.List;

namespace ArchitectureSample.Presentation.List
{
    /// <summary>
    /// List機能のビューモデル
    /// </summary>
    public record ListViewModel(IEnumerable<TodoListDTO> ListData);
}
