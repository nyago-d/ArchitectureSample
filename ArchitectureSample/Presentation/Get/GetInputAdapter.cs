using ArchitectureSample.Application.Get;

namespace ArchitectureSample.Presentation.Get
{
    public class GetInputAdapter
    {
        public GetInputData Adapt(int id)
        {
            return new (id);
        }
    }
}
