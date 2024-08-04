using ArchitectureSample.Domain.Todos;

namespace ArchitectureSample.Application.Get
{
    public class GetUseCase
    {
        private readonly TodoService service;

        public GetUseCase(TodoService service)
        {
            this.service = service;
        }

        public async Task<GetOutputData> Execute(GetInputData inputData)
        {
            var todo = await this.service.ReadAsync(new (inputData.Id));

            return new (todo);
        }
    }
}
