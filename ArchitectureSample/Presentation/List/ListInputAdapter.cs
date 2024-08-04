using ArchitectureSample.Application.List;

namespace ArchitectureSample.Presentation.List
{
    /// <summary>
    /// List機能の入力用変換
    /// </summary>
    /// <remarks>
    /// ConverterでもMapperでもなんでもいいけどAdapterにしてみる。
    /// リクエストから受け取るものが何も無いのでインスタンスだけ生成。
    /// </remarks>
    public class ListInputAdapter
    {
        public ListInputData Adapt()
        {
            return new ();
        }
    }
}
