using ArchitectureSample.Application.List;

namespace ArchitectureSample.Infrastructure.Todos
{
    /// <summary>
    /// Todoリストのデータアクセス
    /// </summary>
    /// <remarks>
    /// サンプルなのでインメモリ。永続化しないのでアプリケーション止めたら消えます。
    /// 簡易のために排他制御なども考慮していません。
    /// </remarks>
    public class TodoDao : ITodoDao
    {
        private static readonly IDictionary<int, TodoDTO> todos = new Dictionary<int, TodoDTO>()
        {
            { 1, new (1, "タスク1", "詳細1") },
            { 2, new (2, "タスク2", "詳細2") },
            { 3, new (3, "タスク3", "詳細3") }
        };

        private static readonly IReadOnlyDictionary<int, TagDTO> tags = new Dictionary<int, TagDTO>()
        {
            { 1, new (["tag1-1"]) },
            { 2, new (["tag2-1", "tag2-2"]) },
            { 3, new (["tag3-1", "tag3-2", "tag3-3"]) },
            { 4, new (["tag4-1", "tag4-2", "tag4-3", "tag4-4"]) },
            { 5, new (["tag5-1", "tag5-2", "tag5-3", "tag5-4", "tag5-5"]) },
        };

        public async Task<IEnumerable<TodoListDTO>> ListAsync()
        {
            var list = todos.Select(x => new TodoListDTO(x.Value.Id, x.Value.Title, tags.GetValueOrDefault(x.Value.Id, new([])).Tags));
            return await Task.FromResult(list);
        }

        public async Task<TodoDTO?> ReadAsync(int todoId)
        {
            var result = todos.TryGetValue(todoId, out TodoDTO? value) ? value : null;
            return await Task.FromResult(result);
        }

        public async Task<TodoDTO> CreateAsync(TodoDTO todo)
        {
            var nextId = todos.Keys.Max() + 1;
            var newTodo = todo with { Id = nextId };
            todos.Add(nextId, newTodo);
            return await Task.FromResult(newTodo with { });
        }

        public async Task<bool> UpdateAsync(TodoDTO todo)
        {
            if (todos.ContainsKey(todo.Id))
            {
                todos[todo.Id] = todo with { };
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> DeleteAsync(int todoId)
        {
            if (todos.ContainsKey(todoId))
            {
                todos.Remove(todoId);
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }
    }
}
