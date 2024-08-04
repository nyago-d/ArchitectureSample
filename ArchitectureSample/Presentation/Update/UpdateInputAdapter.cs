using ArchitectureSample.Application.Update;

namespace ArchitectureSample.Presentation.Update
{
    public class UpdateInputAdapter
    {
        public UpdateInputData Adapt(int id, UpdateParameter parameter)
        {
            return new(id, parameter.Title, parameter.Description);
        }
    }
}
