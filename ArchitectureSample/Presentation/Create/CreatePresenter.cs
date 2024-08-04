using ArchitectureSample.Application.Create;

namespace ArchitectureSample.Presentation.Create
{
    public class CreatePresenter
    {
        public CreateViewModel Present(CreateOutputData outputData)
        {
            return new($"/{outputData.Todo.Id.Value}", outputData.Todo);
        }
    }
}
