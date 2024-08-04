using ArchitectureSample.Application.Create;
using ArchitectureSample.Application.Delete;
using ArchitectureSample.Application.Get;
using ArchitectureSample.Application.List;
using ArchitectureSample.Application.Update;
using ArchitectureSample.Domain.Todos;

namespace ArchitectureSampleTest
{
    /// <summary>
    /// ユースケースのテスト
    /// </summary>
    [TestClass]
    public class UseCaseTests
    {
        [TestMethod]
        public async Task List()
        {
            var query = new TodoQueryFake();
            var useCase = new ListUseCase(query);
            var inputData = new ListInputData();

            var outputData = await useCase.Execute(inputData);

            Assert.AreEqual(2, outputData.ListData.Count());
            Assert.AreEqual(1, outputData.ListData.ElementAt(0).Id);
            Assert.AreEqual("todo1", outputData.ListData.ElementAt(0).Title);
            Assert.AreEqual(1, outputData.ListData.ElementAt(0).Tags.Count());
            Assert.AreEqual("tag1", outputData.ListData.ElementAt(0).Tags.ElementAt(0));
        }

        [TestMethod]
        public async Task Get()
        {
            var repository = new TodoRepositoryFake();
            var service = new TodoService(repository);
            var useCase = new GetUseCase(service);
            var inputData = new GetInputData(1);

            var outputData = await useCase.Execute(inputData);

            Assert.AreEqual(4, outputData.Todo!.Id.Value);
            Assert.AreEqual("todo4", outputData.Todo.Title);
            Assert.AreEqual("description4", outputData.Todo.Description);
        }

        [TestMethod]
        public async Task Create()
        {
            var repository = new TodoRepositoryFake();
            var service = new TodoService(repository);
            var useCase = new CreateUseCase(service);
            var inputData = new CreateInputData("todo3", "description3");

            var outputData = await useCase.Execute(inputData);

            Assert.AreEqual(3, outputData.Todo.Id.Value);
            Assert.AreEqual("todo3", outputData.Todo.Title);
            Assert.AreEqual("description3", outputData.Todo.Description);
        }

        [TestMethod]
        public async Task Update()
        {
            var repository = new TodoRepositoryFake();
            var service = new TodoService(repository);
            var useCase = new UpdateUseCase(service);
            var inputData = new UpdateInputData(5, "todo5", "description5");

            var outputData = await useCase.Execute(inputData);

            Assert.IsTrue(outputData.Exists);
        }

        [TestMethod]
        public async Task Delete()
        {
            var repository = new TodoRepositoryFake();
            var service = new TodoService(repository);
            var useCase = new DeleteUseCase(service);
            var inputData = new DeleteInputData(6);

            var outputData = await useCase.Execute(inputData);

            Assert.IsTrue(outputData.Exists);
        }
    }
}
