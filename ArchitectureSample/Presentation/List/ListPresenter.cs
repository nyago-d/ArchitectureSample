using ArchitectureSample.Application.List;

namespace ArchitectureSample.Presentation.List
{
    /// <summary>
    /// List機能の出力用変換
    /// </summary>
    public class ListPresenter
    {
        public ListViewModel Present(ListOutputData outputData)
        {
            return new (outputData.ListData);
        }
    }
}
