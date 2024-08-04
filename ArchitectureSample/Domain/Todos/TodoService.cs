namespace ArchitectureSample.Domain.Todos
{
    /// <summary>
    /// ドメインサービス
    /// </summary>
    /// <remarks>リポジトリのインタフェースをそのまま使うでも別に良いとは思うけどお好みで。</remarks>
    public class TodoService
    {
        private readonly ITodoRepository todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        public async Task<Todo> CreateAsync(Todo todo)
        {
            return await this.todoRepository.CreateAsync(todo);
        }

        public async Task<Todo?> ReadAsync(TodoId todoId)
        {
            return await this.todoRepository.ReadAsync(todoId);
        }

        public async Task<bool> UpdateAsync(Todo todo)
        {
            return await this.todoRepository.UpdateAsync(todo);
        }

        public async Task<bool> DeleteAsync(TodoId todo)
        {
            return await this.todoRepository.DeleteAsync(todo);
        }
    }
}
