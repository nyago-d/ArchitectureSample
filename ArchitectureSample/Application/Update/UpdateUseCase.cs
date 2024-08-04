using ArchitectureSample.Domain.Todos;

namespace ArchitectureSample.Application.Update
{
    public class UpdateUseCase
    {
        private readonly TodoService service;

        public UpdateUseCase(TodoService service)
        {
            this.service = service;
        }

        public async Task<UpdateOutputData> Execute(UpdateInputData inputData)
        {
            var todo = new Todo(new (inputData.Id), inputData.Title, inputData.Description);

            var result = await this.service.UpdateAsync(todo);

            return new(result);
        }
    }
}
