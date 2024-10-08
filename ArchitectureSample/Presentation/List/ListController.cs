using ArchitectureSample.Application.List;
using ArchitectureSample.Presentation.List;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectureSample.Presentation.Controllers
{
    /// <summary>
    /// List機能のコントローラ
    /// </summary>
    [ApiController]
    [Route("")]
    public class ListController : ControllerBase
    {
        private readonly ILogger<ListController> logger;
        private readonly ListInputAdapter inputAdapter;
        private readonly ListUseCase useCase;
        private readonly ListPresenter presenter;

        public ListController(ILogger<ListController> logger, ListInputAdapter inputAdapter, ListUseCase useCase, ListPresenter presenter)
        {
            this.logger = logger;
            this.inputAdapter = inputAdapter;
            this.useCase = useCase;
            this.presenter = presenter;
        }

        [HttpGet]
        public async Task<IResult> Get()
        {
            this.logger.LogInformation("ListController.Get");

            var inputData = inputAdapter.Adapt();
            var outputData = await useCase.Execute(inputData);
            var viewModel = presenter.Present(outputData);

            return TypedResults.Ok(viewModel);
        }
    }
}
