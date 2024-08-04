using ArchitectureSample.Domain.Todos;

namespace ArchitectureSample.Application.Create
{
    public class CreateUseCase
    {
        private readonly TodoService service;

        public CreateUseCase(TodoService service)
        {
            this.service = service;
        }

        public async Task<CreateOutputData> Execute(CreateInputData inputData)
        {
            var todo = new Todo(new(default), inputData.Title, inputData.Description);
            
            var result = await this.service.CreateAsync(todo);
            
            return new(result);
        }
    }
}
