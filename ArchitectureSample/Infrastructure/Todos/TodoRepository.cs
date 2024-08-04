using ArchitectureSample.Domain.Todos;

namespace ArchitectureSample.Infrastructure.Todos
{
    /// <summary>
    /// TODOのリポジトリ
    /// </summary>
    public class TodoRepository : ITodoRepository
    {
        private readonly ITodoDao todoDao;

        public TodoRepository(ITodoDao todoDao)
        {
            this.todoDao = todoDao;
        }

        public async Task<Todo> CreateAsync(Todo todo)
        {
            var dto = new TodoDTO(todo.Id.Value, todo.Title, todo.Description);
            var result = await todoDao.CreateAsync(dto);
            return new(new(result.Id), result.Title, result.Description);
        }

        public async Task<Todo?> ReadAsync(TodoId todoId)
        {
            var dto = await todoDao.ReadAsync(todoId.Value);
            return dto is null ? null : new(new(dto.Id), dto.Title, dto.Description);
        }

        public async Task<bool> UpdateAsync(Todo todo)
        {
            var dto = new TodoDTO(todo.Id.Value, todo.Title, todo.Description);
            return await todoDao.UpdateAsync(dto);
        }

        public async Task<bool> DeleteAsync(TodoId todoId)
        {
            return await todoDao.DeleteAsync(todoId.Value);
        }
    }
}
