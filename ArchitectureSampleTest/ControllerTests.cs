using ArchitectureSample.Application.Delete;
using ArchitectureSample.Application.Get;
using ArchitectureSample.Application.List;
using ArchitectureSample.Application.Update;
using ArchitectureSample.Domain.Todos;
using ArchitectureSample.Presentation.Controllers;
using ArchitectureSample.Presentation.Delete;
using ArchitectureSample.Presentation.Get;
using ArchitectureSample.Presentation.List;
using ArchitectureSample.Presentation.Update;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ArchitectureSampleTest
{
    /// <summary>
    /// コントローラーのテスト
    /// </summary>
    /// <remarks>ControllerBaseの派生の時点でフレームワーク側なので、処理少なめにしてテストも書かないっていう選択肢でもいいような気がする。</remarks>
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public async Task List()
        {
            var logger = new LoggerFake<ListController>();
            var query = new TodoQueryFake();
            var inputAdapter = new ListInputAdapter();
            var useCase = new ListUseCase(query);
            var presenter = new ListPresenter();
            var controller = new ListController(logger, inputAdapter, useCase, presenter);

            var result = await controller.Get() as Ok<ListViewModel>;

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Value!.ListData.Count());
            Assert.AreEqual(1, result.Value!.ListData.ElementAt(0).Id);
            Assert.AreEqual("todo1", result.Value!.ListData.ElementAt(0).Title);
            Assert.AreEqual(1, result.Value!.ListData.ElementAt(0).Tags.Count());
            Assert.AreEqual("tag1", result.Value!.ListData.ElementAt(0).Tags.ElementAt(0));
        }

        [TestMethod]
        public async Task Get()
        {
            var logger = new LoggerFake<GetController>();
            var repository = new TodoRepositoryFake();
            var service = new TodoService(repository);
            var inputAdapter = new GetInputAdapter();
            var useCase = new GetUseCase(service);
            var presenter = new GetPresenter();
            var controller = new GetController(logger, inputAdapter, useCase, presenter);

            var result = await controller.Get(1) as Ok<GetViewModel>;

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Value!.Todo.Id.Value);
            Assert.AreEqual("todo4", result.Value!.Todo.Title);
            Assert.AreEqual("description4", result.Value!.Todo.Description);
        }

        [TestMethod]
        public async Task Get_NotFound()
        {
            var logger = new LoggerFake<GetController>();
            var repository = new TodoRepositoryNotFoundFake();
            var service = new TodoService(repository);
            var inputAdapter = new GetInputAdapter();
            var useCase = new GetUseCase(service);
            var presenter = new GetPresenter();
            var controller = new GetController(logger, inputAdapter, useCase, presenter);

            var result = await controller.Get(1) as NotFound;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Update()
        {
            var logger = new LoggerFake<UpdateController>();
            var repository = new TodoRepositoryFake();
            var service = new TodoService(repository);
            var inputAdapter = new UpdateInputAdapter();
            var useCase = new UpdateUseCase(service);
            var controller = new UpdateController(logger, inputAdapter, useCase);

            var result = await controller.Put(1, new("todo1", "description1")) as Ok;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Update_NotFound()
        {
            var logger = new LoggerFake<UpdateController>();
            var repository = new TodoRepositoryNotFoundFake();
            var service = new TodoService(repository);
            var inputAdapter = new UpdateInputAdapter();
            var useCase = new UpdateUseCase(service);
            var controller = new UpdateController(logger, inputAdapter, useCase);

            var result = await controller.Put(1, new("todo1", "description1")) as NotFound;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Delete()
        {
            var logger = new LoggerFake<DeleteController>();
            var repository = new TodoRepositoryFake();
            var service = new TodoService(repository);
            var inputAdapter = new DeleteInputAdapter();
            var useCase = new DeleteUseCase(service);
            var controller = new DeleteController(logger, inputAdapter, useCase);

            var result = await controller.Delete(1) as Ok;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Delete_NotFound()
        {
            var logger = new LoggerFake<DeleteController>();
            var repository = new TodoRepositoryNotFoundFake();
            var service = new TodoService(repository);
            var inputAdapter = new DeleteInputAdapter();
            var useCase = new DeleteUseCase(service);
            var controller = new DeleteController(logger, inputAdapter, useCase);

            var result = await controller.Delete(1) as NotFound;

            Assert.IsNotNull(result);
        }
    }
}
