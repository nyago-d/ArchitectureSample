namespace ArchitectureSample.Domain.Todos
{
    /// <summary>
    /// TODOのエンティティ
    /// </summary>
    public class Todo
    {
        public TodoId Id { get; }
        public string Title { get; }
        public string? Description { get; }

        public Todo(TodoId id, string title, string? description)
        {
            Id = id;
            Title = title;
            Description = description;
        }
    }
}
