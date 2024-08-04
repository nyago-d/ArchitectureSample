using ArchitectureSample.Presentation.Create;
using ArchitectureSample.Presentation.Delete;
using ArchitectureSample.Presentation.Get;
using ArchitectureSample.Presentation.List;
using ArchitectureSample.Presentation.Update;

namespace ArchitectureSampleTest
{
    /// <summary>
    /// 入力用変換のテスト
    /// </summary>
    [TestClass]
    public class InputAdapterTests
    {
        [TestMethod]
        public void List()
        {
            var adapter = new ListInputAdapter();

            var inputData = adapter.Adapt();

            Assert.IsNotNull(inputData);
        }

        [TestMethod]
        public void Get()
        {
            var adapter = new GetInputAdapter();

            var inputData = adapter.Adapt(1);

            Assert.AreEqual(1, inputData.Id);
        }

        [TestMethod]
        public void Create()
        {
            var adapter = new CreateInputAdapter();
            var parameter = new CreateParameter("title", "description");

            var inputData = adapter.Adapt(parameter);

            Assert.AreEqual("title", inputData.Title);
            Assert.AreEqual("description", inputData.Description);
        }

        [TestMethod]
        public void Update()
        {
            var adapter = new UpdateInputAdapter();
            var parameter = new UpdateParameter("title", "description");

            var inputData = adapter.Adapt(1, parameter);

            Assert.AreEqual(1, inputData.Id);
            Assert.AreEqual("title", inputData.Title);
            Assert.AreEqual("description", inputData.Description);
        }

        [TestMethod]
        public void Delete()
        {
            var adapter = new DeleteInputAdapter();

            var inputData = adapter.Adapt(1);

            Assert.AreEqual(1, inputData.Id);
        }
    }
}