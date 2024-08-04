using ArchitectureSample.Application.Create;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectureSample.Presentation.Create
{
    [ApiController]
    [Route("")]
    public class CreateController : ControllerBase
    {
        private readonly ILogger<CreateController> logger;
        private readonly CreateInputAdapter inputAdapter;
        private readonly CreateUseCase useCase;
        private readonly CreatePresenter presenter;

        public CreateController(ILogger<CreateController> logger, CreateInputAdapter inputAdapter, CreateUseCase useCase, CreatePresenter presenter)
        {
            this.logger = logger;
            this.inputAdapter = inputAdapter;
            this.useCase = useCase;
            this.presenter = presenter;
        }

        [HttpPost]
        public async Task<IResult> Post(CreateParameter parameter)
        {
            this.logger.LogInformation("CreateController.Post");

            var inputData = inputAdapter.Adapt(parameter);
            var outputData = await useCase.Execute(inputData);
            var viewModel = presenter.Present(outputData);

            return TypedResults.Created(viewModel.Url, viewModel.Todo);
        }
    }
}
