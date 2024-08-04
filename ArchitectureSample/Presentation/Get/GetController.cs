using ArchitectureSample.Application.Get;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectureSample.Presentation.Get
{
    /// <summary>
    /// Get機能のコントローラ
    /// </summary>
    [ApiController]
    [Route("{id}")]
    public class GetController : ControllerBase
    {
        private readonly ILogger<GetController> logger;
        private readonly GetInputAdapter inputAdapter;
        private readonly GetUseCase useCase;
        private readonly GetPresenter presenter;

        public GetController(ILogger<GetController> logger, GetInputAdapter inputAdapter, GetUseCase useCase, GetPresenter presenter)
        {
            this.logger = logger;
            this.inputAdapter = inputAdapter;
            this.useCase = useCase;
            this.presenter = presenter;
        }

        [HttpGet]
        public async Task<IResult> Get(int id)
        {
            this.logger.LogInformation("GetController.Get");

            var inputData = inputAdapter.Adapt(id);
            var outputData = await useCase.Execute(inputData);
            if (outputData.Todo is null)
            {
                return TypedResults.NotFound();
            }
            else
            {
                var viewModel = presenter.Present(outputData);
                return TypedResults.Ok(viewModel);
            }
        }
    }
}
