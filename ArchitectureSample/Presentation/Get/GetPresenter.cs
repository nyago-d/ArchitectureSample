using ArchitectureSample.Application.Get;

namespace ArchitectureSample.Presentation.Get
{
    public class GetPresenter
    {
        public GetViewModel Present(GetOutputData outputData)
        {
            return new(outputData.Todo!);
        }
    }
}
