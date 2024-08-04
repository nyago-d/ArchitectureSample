using ArchitectureSample.Domain.Todos;

namespace ArchitectureSample.Application.Delete
{
    public class DeleteUseCase
    {
        private readonly TodoService service;

        public DeleteUseCase(TodoService service)
        {
            this.service = service;
        }

        public async Task<DeleteOutputData> Execute(DeleteInputData inputData)
        {
            var result = await this.service.DeleteAsync(new(inputData.Id));

            return new(result);
        }
    }
}
