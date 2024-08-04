using ArchitectureSample.Application.List;

namespace ArchitectureSample.Infrastructure.Todos
{
    /// <summary>
    /// TODOのクエリ
    /// </summary>
    public class TodoQuery : ITodoQuery
    {
        private readonly ITodoDao todoDao;

        public TodoQuery(ITodoDao todoDao)
        {
            this.todoDao = todoDao;
        }

        public async Task<IEnumerable<TodoListDTO>> ListAsync()
        {
            return await todoDao.ListAsync();
        }
    }
}
