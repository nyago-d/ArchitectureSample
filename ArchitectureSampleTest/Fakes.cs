using ArchitectureSample.Application.List;
using ArchitectureSample.Domain.Todos;
using ArchitectureSample.Infrastructure.Todos;
using Microsoft.Extensions.Logging;

namespace ArchitectureSampleTest
{
    public class TodoQueryFake : ITodoQuery
    {
        public async Task<IEnumerable<TodoListDTO>> ListAsync()
        {
            return await Task.FromResult(new TodoListDTO[]
            {
                    new(1, "todo1", new[] { "tag1" }),
                    new(2, "todo2", new[] { "tag2" })
            });
        }
    }

    public class TodoRepositoryFake : ITodoRepository
    {
        public async Task<Todo> CreateAsync(Todo todo)
        {
            return await Task.FromResult(new Todo(new(3), "todo3", "description3"));
        }

        public async Task<Todo?> ReadAsync(TodoId todoId)
        {
            return await Task.FromResult(new Todo(new(4), "todo4", "description4"));
        }

        public async Task<bool> DeleteAsync(TodoId todo)
        {
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(Todo todo)
        {
            return await Task.FromResult(true);
        }
    }

    public class TodoRepositoryNotFoundFake : ITodoRepository
    {
        public Task<Todo> CreateAsync(Todo todo)
        {
            throw new NotImplementedException();
        }

        public async Task<Todo?> ReadAsync(TodoId todoId)
        {
            return await Task.FromResult(null as Todo);
        }

        public async Task<bool> DeleteAsync(TodoId todo)
        {
            return await Task.FromResult(false);
        }

        public async Task<bool> UpdateAsync(Todo todo)
        {
            return await Task.FromResult(false);
        }
    }

    public class TodoDaoFake : ITodoDao
    {
        public async Task<IEnumerable<TodoListDTO>> ListAsync()
        {
            return await Task.FromResult(new TodoListDTO[]
            {
                    new(5, "todo5", new[] { "tag3" }),
                    new(6, "todo6", new[] { "tag4" })
            });
        }

        public async Task<TodoDTO?> ReadAsync(int todoId)
        {
            return await Task.FromResult(new TodoDTO(5, "todo5", "description5"));
        }

        public async Task<TodoDTO> CreateAsync(TodoDTO todo)
        {
            return await Task.FromResult(new TodoDTO(6, "todo6", "description6"));
        }

        public async Task<bool> DeleteAsync(int todoId)
        {
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(TodoDTO todo)
        {
            return await Task.FromResult(true);
        }
    }

    public class LoggerFake<TCategoryName> : ILogger<TCategoryName>
    {
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
        }
    }
}
