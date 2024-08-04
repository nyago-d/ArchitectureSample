using ArchitectureSample.Application.Create;
using ArchitectureSample.Application.Get;
using ArchitectureSample.Application.List;
using ArchitectureSample.Domain.Todos;
using ArchitectureSample.Presentation.Create;
using ArchitectureSample.Presentation.Get;
using ArchitectureSample.Presentation.List;

namespace ArchitectureSampleTest
{
    /// <summary>
    /// 出力用変換のテスト
    /// </summary>
    [TestClass]
    public class PresenterTests
    {
        [TestMethod]
        public void List()
        {
            var data = new TodoListDTO[]             
            {
                new (1, "todo1", ["tag1"]),
                new (2, "todo2", ["tag2"])
            };
            var presenter = new ListPresenter();
            var outputData = new ListOutputData(data);

            var viewModel = presenter.Present(outputData);

            Assert.AreEqual(2, viewModel.ListData.Count());
            Assert.AreEqual(1, viewModel.ListData.ElementAt(0).Id);
            Assert.AreEqual("todo1", viewModel.ListData.ElementAt(0).Title);
            Assert.AreEqual(1, viewModel.ListData.ElementAt(0).Tags.Count());
            Assert.AreEqual("tag1", viewModel.ListData.ElementAt(0).Tags.ElementAt(0));
        }

        [TestMethod]
        public void Get()
        {
            var data = new Todo(new (1), "todo1", "description1");
            var presenter = new GetPresenter();
            var outputData = new GetOutputData(data);

            var viewModel = presenter.Present(outputData);

            Assert.AreEqual(1, viewModel.Todo.Id.Value);
            Assert.AreEqual("todo1", viewModel.Todo.Title);
            Assert.AreEqual("description1", viewModel.Todo.Description);
        }

        [TestMethod]
        public void Create()
        {
            var data = new Todo(new (1), "todo1", "description1");
            var presenter = new CreatePresenter();
            var outputData = new CreateOutputData(data);

            var viewModel = presenter.Present(outputData);

            Assert.AreEqual("/1", viewModel.Url);
            Assert.AreEqual(1, viewModel.Todo.Id.Value);
            Assert.AreEqual("todo1", viewModel.Todo.Title);
            Assert.AreEqual("description1", viewModel.Todo.Description);
        }
    }
}
