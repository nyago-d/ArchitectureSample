using ArchitectureSample.Application.Create;

namespace ArchitectureSample.Presentation.Create
{
    public class CreateInputAdapter
    {
        public CreateInputData Adapt(CreateParameter parameter)
        {
            return new(parameter.Title, parameter.Description);
        }
    }
}
