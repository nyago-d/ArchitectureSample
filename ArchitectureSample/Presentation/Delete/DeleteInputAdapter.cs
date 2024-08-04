using ArchitectureSample.Application.Delete;

namespace ArchitectureSample.Presentation.Delete
{
    public class DeleteInputAdapter
    {
        public DeleteInputData Adapt(int id)
        {
            return new(id);
        }
    }
}
