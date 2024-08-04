using ArchitectureSample.Domain.Todos;
using ArchitectureSample.Infrastructure.Todos;

namespace ArchitectureSampleTest
{
    /// <summary>
    /// リポジトリのテスト
    /// </summary>
    /// <remarks>Infrastructure層だけど、外部依存をDaoに逃がしているのでテストが書ける。</remarks>
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public async Task Read()
        {
            var dao = new TodoDaoFake();
            var repository = new TodoRepository(dao);

            var data = await repository.ReadAsync(new (5));

            Assert.AreEqual(5, data!.Id.Value);
            Assert.AreEqual("todo5", data.Title);
            Assert.AreEqual("description5", data.Description);
        }

        [TestMethod]
        public async Task Create()
        {
            var dao = new TodoDaoFake();
            var repository = new TodoRepository(dao);
            var todo = new Todo(new (3), "todo3", "description3");

            var data = await repository.CreateAsync(todo);

            Assert.AreEqual(6, data.Id.Value);
            Assert.AreEqual("todo6", data.Title);
            Assert.AreEqual("description6", data.Description);
        }

        [TestMethod]
        public async Task Update()
        {
            var dao = new TodoDaoFake();
            var repository = new TodoRepository(dao);
            var todo = new Todo(new (5), "todo5", "description5");

            var result = await repository.UpdateAsync(todo);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task Delete()
        {
            var dao = new TodoDaoFake();
            var repository = new TodoRepository(dao);

            var result = await repository.DeleteAsync(new (5));

            Assert.IsTrue(result);
        }
    }
}
