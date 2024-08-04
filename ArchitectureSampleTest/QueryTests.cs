using ArchitectureSample.Infrastructure.Todos;

namespace ArchitectureSampleTest
{
    /// <summary>
    /// クエリのテスト
    /// </summary>
    [TestClass]
    public class QueryTests
    {
        [TestMethod]
        public async Task List()
        {
            var dao = new TodoDaoFake();
            var query = new TodoQuery(dao);

            var data = await query.ListAsync();

            Assert.AreEqual(2, data.Count());
            Assert.AreEqual(5, data.ElementAt(0).Id);
            Assert.AreEqual("todo5", data.ElementAt(0).Title);
            Assert.AreEqual(1, data.ElementAt(0).Tags.Count());
            Assert.AreEqual("tag3", data.ElementAt(0).Tags.ElementAt(0));
        }
    }
}
