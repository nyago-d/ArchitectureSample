namespace ArchitectureSample.Application.List
{
    /// <summary>
    /// List機能のユースケース
    /// </summary>
    /// <remarks>
    /// データ引っ張ってくるだけなのでQueryを呼ぶだけで終わっているけれど、ユースケースの実現のために好きなことをしていい。
    /// やることが多い場合はApplicationService（SubUseCase）に切り出すのもわかりやすくていいと思う。
    /// </remarks>
    public class ListUseCase
    {
        private readonly ITodoQuery query;

        public ListUseCase(ITodoQuery query)
        {
            this.query = query;
        }

        public async Task<ListOutputData> Execute(ListInputData inputData)
        {
            var todos = await query.ListAsync();

            return new ListOutputData(todos);
        }
    }
}
